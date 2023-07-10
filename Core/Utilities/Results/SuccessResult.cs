using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string massege) : base(true, massege)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
