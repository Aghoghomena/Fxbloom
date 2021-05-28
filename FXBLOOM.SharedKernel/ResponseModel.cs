using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.SharedKernel
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}
