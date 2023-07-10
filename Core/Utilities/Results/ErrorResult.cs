using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string massege) : base(false, massege)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
