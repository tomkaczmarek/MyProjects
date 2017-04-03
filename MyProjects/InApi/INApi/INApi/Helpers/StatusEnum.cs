using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INApi.Helpers
{
    public sealed class StatusEnum
    {
        private readonly string _status;

        public static readonly StatusEnum Valid = new StatusEnum("VALID");
        public static readonly StatusEnum Error = new StatusEnum("ERROR");

        private StatusEnum(string statusName)
        {
            _status = statusName;
        }

        public override string ToString()
        {
            return _status;
        }

    }
}
