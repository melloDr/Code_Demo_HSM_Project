using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aws4RequestSigner
{
    public class Program
    {
        string CalculateSignature = AwsV4SignatureCalculator.CalculateSignature("https://sign-hn1.vin-hsm.com/api/v2/xml/sign/defaultdata", "","");
    }
}
