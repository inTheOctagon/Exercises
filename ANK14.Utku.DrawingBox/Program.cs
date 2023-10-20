using System.Security.Cryptography.X509Certificates;

namespace ANK14.Utku.DrawingBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            int n;
            string EorH = "";

            while (again) 
            {
                Console.Write("Çizilecek kutu için bir kenar sayısı veriniz: ");
                
                if (Int32.TryParse(Console.ReadLine(), out n))
                {
                    if( 0 < n && n <= 54 ) 
                    {
                        DrawBox(n);
                        while(EorH != "E" && EorH != "H")
                        {
                            Console.WriteLine("Mekanizmayı tekrar denetmek için 'E', programı kapatmak için 'H' yazınız: ");
                            EorH = Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("1-54 aralığında bulunan bir tam sayı değerini giriniz.");
                        EorH = "E";
                    }
                }
                else
                {
                    EorH = "E";
                    Console.Clear();
                }
                    switch (EorH)
                    {
                        case "E":
                            again = true;
                            EorH = "";
                            break;
                        case "H":
                            again = false;
                            EorH = "";
                            break;
                        default:
                            break;
                    }
                }   
            
            void DrawBox(int n)
            {
                Console.Write("+");
                for (int i = 0; i < n; i++) 
                {
                    Console.Write("-");
                }
                Console.WriteLine("+");

                for (int i = 0; i < n; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("|");
                }

                Console.Write("+");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("+");
            }
        }
    }
}