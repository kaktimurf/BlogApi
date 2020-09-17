using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }

       

    }
}
