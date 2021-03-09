using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class ApiResult<T>
    {
        public ApiResult() { }
        public ApiResult(T result)
        {
            Result = result;
        }
        public string Error { get; set; }
        public bool IsSuccessful { get; set; }
        public T Result { get; set; }
    }
}
