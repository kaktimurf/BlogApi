using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public interface IFileServices
    {
        void SaveFile (List<IFormFile> files, string postImageNames);
        string FileSize(long bytes);
        public string ImagePath { get; set; }

        void UpdateFİle(List<IFormFile> files, string postImageName);
        void DeleteFile(string postImageName);
        string FileGet(string postImageName);
    }
}
