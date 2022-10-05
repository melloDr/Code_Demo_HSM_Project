// See https://aka.ms/new-console-template for more information

using Console_demo_HSM;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.PortableExecutable;

public class Program
{
    private const string URL = "https://sign-hn1.vin-hsm.com/api/v2/pdf/sign/originaldata";
    static string DATA = "";

    static void Main(string[] args)
    {
        string result = ClassSup.getData();
        Console.WriteLine(result);
        File.WriteAllText(@"E:\Study\Capstone\Code\Code_Demo_HSM\Console_demo_HSM\out.txt", result);
    }

    private static void CreateObject()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = DATA.Length;
        StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        requestWriter.Write(DATA);
        requestWriter.Close();

        try
        {
            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            string response = responseReader.ReadToEnd();
            Console.Out.WriteLine(response);
            responseReader.Close();
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("-----------------");
            Console.Out.WriteLine(e.Message);
        }

    }
}

