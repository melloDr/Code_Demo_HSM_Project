using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace ConnectExternalAPI
{
    internal class Program
    {
        public static string StateIndex()
        {
            var responseString = ApiCall.GetApi("https://sign-hn1.vin-hsm.com/api/v2/pdf/sign/originaldata");

            object o = JsonConvert.DeserializeObject(@"E:\Study\Capstone\Code\Code_Demo_HSM\ConnectExternalAPI\SignXML.postman_collection.json");
            string rootobject = JsonConvert.SerializeObject(o, Formatting.Indented);
            //var rootobject = new JavaScriptSerializer().Deserialize<List<DataRecei>>(responseString);
            return rootobject;
        }
        static void Main(string[] args)
        {
            string result = StateIndex();
            Console.WriteLine(result);
        }
    }
}
