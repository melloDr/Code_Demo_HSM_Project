using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPMAWSV4Sign
{
    public class ClassSup
    {
        //private const string DATA = @"{""object"":{""name"":""Name""}}";


        public static string getData()
        {
            string base64PDF = ClassSup.convertObjToBase64(@"E:\Study\Capstone\Code\Code_Demo_HSM\Console_demo_HSM\sample.pdf");
            string base64Images = ClassSup.convertObjToBase64(@"E:\Study\Capstone\Code\Code_Demo_HSM\Console_demo_HSM\sampleImg.jpg");

            string result2 = "{ \n" +
                "\"base64pdf\": \"" + base64PDF + "\", \n" +
                "\"base64image\": \"" + base64Images + "\", \n" +
                "\"hashalg\": \"SHA1\", \n" +
                "\"height\": 60, \n " +
                "\"pagesign\": 1, \n " +
                "\"signaturename\": \"Mello\", \n" +
                "\"textout\": \"Hello\", \n" +
                "\"typesignature\": 3, \n" +
                "\"width\": 60, \n " +
                "\"xpoint\": 60, \n " +
                "\"ypoint\": 60 \n" +
                "}";

            return result2;
        }
        public static string getDataXml()
        {
            string base64XML = "PFRLaGFpPg0KCTxETFRLaGFpIElkPSJTaWduaW5nRGF0YSI+DQoJCTxUVENodW5nPg0KCQkJPFBCYW4+Mi4wLjA8L1BCYW4+DQoJCQk8TVNvPjAxL8SQS1TEkC1IxJDEkFQ8L01Tbz4NCgkJCTxUZW4+VOG7nSBraGFpIMSRxINuZyBrw70vdGhheSDEkeG7lWkgdGjDtG5nIHRpbiBz4butIGThu6VuZyBow7NhIMSRxqFuIMSRaeG7h24gdOG7rTwvVGVuPg0KCQkJPEhUaHVjPjE8L0hUaHVjPg0KCQkJPFROTlQ+Q8OUTkcgVFkgQ+G7lCBQSOG6pk4gVOG6rFAgxJBPw4BOIMSQ4bqmVSBUxq8gUEjDgVQgVFJJ4buCTiBI4bqgIFThuqZORyBOR1VZw4pOIFbFqCBUQ1ZOPC9UTk5UPg0KCQkJPE1TVD4wMTA4ODE5NDUwPC9NU1Q+DQoJCQk8Q1FUUUx5PkPhu6VjIFRodeG6vyBUaMOgbmggUGjhu5EgSMOgIE7hu5lpPC9DUVRRTHk+DQoJCQk8TUNRVFFMeT4xMDEwMDwvTUNRVFFMeT4NCgkJCTxOTEhlPk5HdXnhu4VuIFRyxrDhu51uZyBHaWFuZzwvTkxIZT4NCgkJCTxEQ0xIZT5UaMO0biBMacOqbiBNaW5oLCBYw6MgVGjhu6V5IEFuLCBIdXnhu4duIEJhIFbDrCwgVGjDoG5oIHBo4buRIEjDoCBO4buZaSwgVmnhu4d0IE5hbTwvRENMSGU+DQoJCQk8RENURFR1PmhhaW50Nzg1QGdtYWlsLmNvbTwvRENURFR1Pg0KCQkJPERUTEhlPjA3NzIyMzc5Nzk8L0RUTEhlPg0KCQkJPEREYW5oPkjDoCBO4buZaTwvRERhbmg+DQoJCQk8TkxhcD4yMDIxLTEyLTE1PC9OTGFwPg0KCQk8L1RUQ2h1bmc+DQoJCTxORFRLaGFpPg0KCQkJPEhUSERvbj4NCgkJCQk8Q01hPjE8L0NNYT4NCgkJCQk8S0NNYT4wPC9LQ01hPg0KCQkJPC9IVEhEb24+DQoJCQk8SFRHRExIRERUPg0KCQkJCTxOTlREQktLaGFuPjA8L05OVERCS0toYW4+DQoJCQkJPE5OVEtURE5VQk5EPjA8L05OVEtURE5VQk5EPg0KCQkJCTxDRExUVERDUVQ+MDwvQ0RMVFREQ1FUPg0KCQkJCTxDRExRVENUTj4wPC9DRExRVENUTj4NCgkJCTwvSFRHRExIRERUPg0KCQkJPFBUaHVjPg0KCQkJCTxDRER1PjE8L0NERHU+DQoJCQkJPENCVEhvcD4wPC9DQlRIb3A+DQoJCQk8L1BUaHVjPg0KCQkJPExIRFNEdW5nPg0KCQkJCTxIREdUR1Q+MTwvSERHVEdUPg0KCQkJCTxIREJIYW5nPjA8L0hEQkhhbmc+DQoJCQkJPEhEQlRTQ29uZz4wPC9IREJUU0Nvbmc+DQoJCQkJPEhEQkhEVFFHaWE+MDwvSERCSERUUUdpYT4NCgkJCQk8SERLaGFjPjA8L0hES2hhYz4NCgkJCQk8Q1R1PjA8L0NUdT4NCgkJCTwvTEhEU0R1bmc+DQoJCQk8RFNDVFNTRHVuZz4NCgkJCQk8Q1RTPg0KCQkJCQk8U1RUPjE8L1NUVD4NCgkJCQkJPFRUQ2h1Yz5FRlktQ0E8L1RUQ2h1Yz4NCgkJCQkJPFNlcmk+NTQwMTAxMTBBRjEzMjk4MjAzREExQ0ZEQ0E4MTJCRUM8L1Nlcmk+DQoJCQkJCTxUTmdheT4yMDE5LTA3LTMwVDEwOjIxOjAxPC9UTmdheT4NCgkJCQkJPEROZ2F5PjIwMjItMDctMjlUMTA6MjE6MDE8L0ROZ2F5Pg0KCQkJCQk8SFRodWM+MTwvSFRodWM+DQoJCQkJPC9DVFM+DQoJCQk8L0RTQ1RTU0R1bmc+DQoJCTwvTkRUS2hhaT4NCgk8L0RMVEtoYWk+DQo8L1RLaGFpPg0KCQ==";
            string result2 = "{ \n" +
                "\"base64xml\": \"" + base64XML + "\", \n" +    
                "\"hashalg\": \"SHA1\"" +
                "}";
            return result2;
        }
       

            public static string convertObjToBase64(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(bytes);

            return base64;
        }

        public static void convertBase64ToPDF(string base64BinaryStr)
        {
            byte[] bytes = Convert.FromBase64String(base64BinaryStr);
            System.IO.FileStream stream = new FileStream(@"E:\Study\Capstone\Code\Code_Demo_HSM\Console_demo_HSM\fileSigned.pdf", FileMode.CreateNew);
            System.IO.BinaryWriter writer =
                new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
        }


    }
}
