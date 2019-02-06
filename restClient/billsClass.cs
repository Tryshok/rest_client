using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restClient
{
    class billsClass
    {
        public string description { get; set; }
        public string client { get; set; }
        public List<string> products { get; set; }
    }
}