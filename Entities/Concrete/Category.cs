﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

    }
}
