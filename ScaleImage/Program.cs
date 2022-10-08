using ScaleImage;
using System;
using System.Drawing;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Image image1 = Image.FromFile("E:\\Study\\Capstone\\Code\\Code_Demo_HSM\\Console_demo_HSM\\sampleImg.jpg");
            image1 = ClassSup.ScaleImg(image1, 600, 600);
            image1.Save("E:\\Study\\Capstone\\Code\\Code_Demo_HSM\\ScaleImage\\ResultImgScaled.jpg");
        }


    }
}