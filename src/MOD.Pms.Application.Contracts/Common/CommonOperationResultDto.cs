using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Pms.Common
{
    public class CommonOperationResultDto<T>
    {
        public CommonOperationResultDto(string message, bool isSuccessfull)
        {
            Message = message;
            IsSuccessfull = isSuccessfull;
        }
        public string Message { get; set; }
        public bool IsSuccessfull { get; set; }
        public Dictionary<string, object> ExtraProperties { get; set; }
        public T   Object { get; set; }
    }
}