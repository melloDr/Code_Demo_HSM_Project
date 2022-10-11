using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestAPMAWSV4Sign
{
    public class DataBody
    {
        public string base64xml { get; set; }
        public string hashalg { get; set; }

        public override string ToString()
        {
            return $"{base64xml}: {hashalg}";
        }
    }
}
