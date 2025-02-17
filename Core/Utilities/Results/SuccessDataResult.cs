﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult() : base(default, true)
        {
        }

        public SuccessDataResult(T data,string massage):base(data,true,massage)
        {
                
        }
        public SuccessDataResult(string message):base(default,true,message)
        {

        }
    }
}
