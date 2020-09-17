using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.FileHelper;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsConnroller : ControllerBase
    {
        private IFileServices _fileService;
        private IPostService _postService;


        public PostsConnroller(IPostService postService, IFileServices fileService)
        {
            _postService = postService;
            _fileService = fileService;

        }
        [HttpPost("add")]
        public IActionResult Add(Post post)
        {

            var result = _postService.Add(post);


            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);

        }

        [HttpPost("update")]
        public IActionResult Update(Post post)
        {
            var result = _postService.Update(post);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }




        [HttpPost("delete")]
        public IActionResult Delete(Post post)
        {
            var result = _postService.Delete(post);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }




        //Yüklenen dosya wwwroot/postName/postImageName.jpg veya png olarak tutulur
        [HttpPost("FileOperation")]
        public IActionResult UploadFile([FromForm(Name = "files")] List<IFormFile> files,bool isUpdated,bool isDeleted, bool isFileGet,string postImageName)
        {
          
            try
            {
                if (isUpdated)
                {
                    _fileService.UpdateFİle(files, postImageName);
                    return Ok(new { files.Count, Size = _fileService.FileSize(files.Sum(f => f.Length)), _fileService.ImagePath });
                }
                else if (isDeleted)
                {
                    _fileService.DeleteFile(postImageName);
                    return Ok();
                }
                else if (isDeleted)
                {
                    _fileService.FileGet(postImageName);
                    return Ok();
                }
                _fileService.SaveFile(files, postImageName);
                return Ok(new { files.Count, Size = _fileService.FileSize(files.Sum(f => f.Length)), _fileService.ImagePath });

                
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }

        
       
    }
}
