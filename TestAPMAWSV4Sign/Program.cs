using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace TestAPMAWSV4Sign
{
    /// <summary>
    /// Full process as described here. https://docs.aws.amazon.com/general/latest/gr/sigv4-create-canonical-request.html
    /// Supports query strings on request Uri.
    /// </summary>
    public class Program
    {
        #region Variables

        //public static string url = "https://aws-url-host.com/v1/employees";
        // With query string - as example

        public static string url = "https://sign-hn1.vin-hsm.com/api/v2/xml/sign/defaultdata";
        public static string accessKey = "4288161d272f4622b23e52697346ad8d";
        public static string secretkey = "eHi3x+c4nQZYuVQRZV3d1WcB46aCzMQhNR4KcSpY";
        public static string awsRegion = "hn1";
        public static string awsServiceName = "sign";
        //public static string xApiKey = "APIKEY-TOCALLAWSFUNCTION-IFNEEDED";
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public static void Main(string[] args)
        {
            // 0. Prepare request message.
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, url);
            msg.Headers.Host = msg.RequestUri.Host;


            // Get and save dates ready for further use.
            DateTimeOffset utcNowSaved = DateTimeOffset.UtcNow;
            string amzLongDate = utcNowSaved.ToString("yyyyMMddTHHmmssZ");
            string amzShortDate = utcNowSaved.ToString("yyyyMMdd");

            // Add to headers. 
            msg.Headers.Add("x-amz-date", amzLongDate);
            msg.Headers.Add("x-amz-content-sha256", "beaead3198f7da1e70d03ab969765e0821b24fc913697e929e726aeaebf0eba3");
            // Add body
            /*var dataBody = new DataBody();
            dataBody.base64xml = ClassSup.getDataXml();
            dataBody.hashalg = "SHA1";
            var json = JsonConvert.SerializeObject(dataBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");*/

            msg.Content = new StringContent(JsonConvert.SerializeObject(ClassSup.getDataXml()), Encoding.UTF8, "application/json");
            Console.WriteLine("msg.Content: " + msg.Content);
            //msg.Headers.Add("x-api-key", xApiKey); // My API call needs an x-api-key passing also for function security.

            // **************************************************** SIGNING PORTION ****************************************************
            // 1. Create Canonical Request            
            var canonicalRequest = new StringBuilder();
            canonicalRequest.Append(msg.Method + "\n");
            canonicalRequest.Append(string.Join("/", msg.RequestUri.AbsolutePath.Split('/').Select(Uri.EscapeDataString)) + "\n");

            canonicalRequest.Append(GetCanonicalQueryParams(msg) + "\n"); // Query params to do.

            var headersToBeSigned = new List<string>();
            foreach (var header in msg.Headers.OrderBy(a => a.Key.ToLowerInvariant(), StringComparer.OrdinalIgnoreCase))
            {
                canonicalRequest.Append(header.Key.ToLowerInvariant());
                canonicalRequest.Append(":");
                canonicalRequest.Append(string.Join(",", header.Value.Select(s => s.Trim())));
                canonicalRequest.Append("\n");
                headersToBeSigned.Add(header.Key.ToLowerInvariant());
            }
            canonicalRequest.Append("\n");

            var signedHeaders = string.Join(";", headersToBeSigned);
            canonicalRequest.Append(signedHeaders + "\n");
            canonicalRequest.Append("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855"); // Signature for empty body.
            //Hash(msg.Content.ReadAsByteArrayAsync().Result);
            var content1 = msg.Headers;
            var content = msg.Content;

            // 2. String to sign.            
            string stringToSign = "AWS4-HMAC-SHA256" + "\n" + amzLongDate + "\n" + amzShortDate + "/" + awsRegion + "/" + awsServiceName + "/aws4_request" + "\n" + Hash(Encoding.UTF8.GetBytes(canonicalRequest.ToString()));

            // 3. Signature with compounded elements.
            var dateKey = HmacSha256(Encoding.UTF8.GetBytes("AWS4" + secretkey), amzShortDate);
            var dateRegionKey = HmacSha256(dateKey, awsRegion);
            var dateRegionServiceKey = HmacSha256(dateRegionKey, awsServiceName);
            var signingKey = HmacSha256(dateRegionServiceKey, "aws4_request");

            var signature = ToHexString(HmacSha256(signingKey, stringToSign.ToString()));

            // **************************************************** END SIGNING PORTION ****************************************************

            // Add the Header to the request.
            var credentialScope = amzShortDate + "/" + awsRegion + "/" + awsServiceName + "/aws4_request";


            msg.Headers.TryAddWithoutValidation("Authorization", "AWS4-HMAC-SHA256 Credential=" + accessKey + "/" + credentialScope + ", SignedHeaders=" + signedHeaders + ", Signature=" + signature);
            Console.WriteLine( "AWS4-HMAC-SHA256 Credential=" + accessKey + "/" + credentialScope + ", SignedHeaders=" + signedHeaders + ", Signature=" + signature);
            Console.WriteLine("Header1: ");
            // Invoke the request with HttpClient.
            HttpClient client = new HttpClient();
            HttpResponseMessage result = client.SendAsync(msg).Result;
            if (result.IsSuccessStatusCode)
            {
                // Inspect the result and payload returned.
                Console.WriteLine("Header: " + result.Headers);
                Console.WriteLine("Content: "+result.Content.ReadAsStringAsync().Result);
                // Wait on user.
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Gets the query string parameters.
        /// </summary>
        /// <param name="request">(HttpRequestMessage) Request with Headers in.</param>
        /// <returns>(string) Params in order.</returns>
        private static string GetCanonicalQueryParams(HttpRequestMessage request)
        {
            var values = new SortedDictionary<string, string>();

            var querystring = HttpUtility.ParseQueryString(request.RequestUri.Query);
            foreach (var key in querystring.AllKeys)
            {
                if (key == null)//Handles keys without values
                {
                    values.Add(Uri.EscapeDataString(querystring[key]), $"{Uri.EscapeDataString(querystring[key])}=");
                }
                else
                {
                    // Escape to upper case. Required.
                    values.Add(Uri.EscapeDataString(key), $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(querystring[key])}");
                }
            }
            // Put in order - this is important.
            var queryParams = values.Select(a => a.Value);
            return string.Join("&", queryParams);
        }

        /// <summary>
        /// SHA 265.
        /// </summary>
        /// <param name="bytesToHash"></param>
        /// <returns>(string) Hashed result.</returns>
        public static string Hash(byte[] bytesToHash)
        {
            return ToHexString(SHA256.Create().ComputeHash(bytesToHash));
        }

        /// <summary>
        /// To hex string.
        /// </summary>
        /// <param name="array"> Bytes to make hex.</param>
        /// <returns>(string) As Hex.</returns>
        private static string ToHexString(IReadOnlyCollection<byte> array)
        {
            var hex = new StringBuilder(array.Count * 2);
            foreach (var b in array)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        /// <summary>
        /// Encryption method for AWS.
        /// </summary>
        /// <param name="key">(Byte []) Key.</param>
        /// <param name="data">(string) Data.</param>
        /// <returns>(Byte []) Hmac result.</returns>
        private static byte[] HmacSha256(byte[] key, string data)
        {
            return new HMACSHA256(key).ComputeHash(Encoding.UTF8.GetBytes(data));
        }
    }
    #endregion
}
