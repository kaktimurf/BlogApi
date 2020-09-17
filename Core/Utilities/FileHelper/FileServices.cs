using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileServices:IFileServices
    {
        public string ImagePath { get; set; }
        public string[] ImageName;
        public string target = Path.Combine(@"C:\Users\kakti\source\repos\Blog\BlogAPI\wwwroot\Files\Images\");
        public string txttarget = Path.Combine(@"C:\Users\kakti\source\repos\Blog\BlogAPI\wwwroot\Files\", "Txt");


        public void SaveFile(List<IFormFile> files,string postImageNames)
        {
           
            files.ForEach(item => { ImageName = item.FileName.Split('.'); });

            Directory.CreateDirectory(target);
            Directory.CreateDirectory(txttarget);
            files.ForEach(async file =>
            {

                if (file.Length <= 0) return;
                var filePath = Path.Combine(target, postImageNames + "." + "png");
                ImagePath = target + postImageNames +"." + "png";
                using (var stream = new FileStream(filePath, FileMode.OpenOrCreate,FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(stream);
                    WriteToTxt(stream);
                }

               
            });

          
        }


        public void UpdateFİle(List<IFormFile> files, string postImageNames)
        {
            files.ForEach(item => { ImageName = item.FileName.Split('.'); });  
            var filePath = Path.Combine(target, postImageNames + "." + "png");
            ImagePath = target + postImageNames + "." + "png";
            File.Delete(target + postImageNames);
            files.ForEach(async file =>
            {
                using (var stream=new FileStream(filePath,FileMode.OpenOrCreate,FileAccess.ReadWrite))
                {

                    StreamWriter sw = new StreamWriter(stream);
                 

                    await file.CopyToAsync(stream);
                    WriteToTxt(stream);

                }

            });
            
        }


        public void DeleteFile(string postImageNames)
        {
            
            var filePath = Path.Combine(target, postImageNames + "." + "png");
            File.Delete(filePath);
        }

        public string FileGet(string postImageNames)
        {
            return  Path.Combine(target, postImageNames + "." + "png");
        }




        public void WriteToTxt(FileStream stream)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(txttarget, "FileDirectory.txt"));

            sw.WriteLine(ImagePath);
            sw.Flush();
            sw.Close();
            stream.Close();
        }


        public  string FileSize(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return "1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }

        
    }
}
