using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhalanxCommon.Entities
{
    public class CTSRestExecutorSpRequest
    {
        public string spName { get; set; }
        public List<SpParam> @params { get; set; }
    }

    public class SpParam
    {
        public string name { get; set; }
        public int dataType { get; set; }
        public string value { get; set; }
        public int ioType { get; set; }
    }
}
