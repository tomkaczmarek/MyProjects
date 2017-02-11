using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Core.Operation
{
    public class OperationResult
    {
        public Status OperationStatus { get; set; }
        public string OperationMessage { get; set; }
        public string UrlRedirect { get; set; }
    }
}
