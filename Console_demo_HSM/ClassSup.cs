namespace Console_demo_HSM
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
