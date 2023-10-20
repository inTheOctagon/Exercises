namespace ANK14.Utku.DrawingBox.HeightWidth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            bool inputIsValid = false;

            bool gPart;
            double g;
            double y;

            int gLen;
            int yLen;

            string EorH = "";

            while (again)
            {
                Console.Write("Çizilecek kutu için genişlik ve yükseklik değerlerini giriniz (Örn: 6x7): ");

                var input = Console.ReadLine();

                g = 0;
                y = 0;
                gLen = -1;
                yLen = -1;
                gPart = true;

                foreach (var c in input) 
                { 
                    if(Char.IsDigit(c))
                    {
                        if(gPart)
                        {
                            gLen++;
                        }
                        else
                        {
                            yLen++;
                            inputIsValid = true;
                        }
                    }
                    else if(c != 'x')
                    {
                        inputIsValid = false;
                        break;
                    }
                    else
                    {
                        gPart = false;
                    }
                }

                gPart = true;

                if(inputIsValid)
                {
                    foreach (var c in input)
                    {
                        if (Char.IsDigit(c))
                        {
                            if (gPart)
                            {
                                g += int.Parse(c.ToString()) * Math.Pow(10, gLen);
                                gLen--;
                            }
                            else
                            {
                                y += int.Parse(c.ToString()) * Math.Pow(10, yLen);
                                yLen--;
                            }
                        }
                        else
                        {
                            gPart = false;
                        }
                    }
                }

                if (inputIsValid)
                {
                    if ((0 < g && g <= 209) && (0 < y && y <= 54))
                    {
                        DrawBox(g, y);
                        while (EorH != "E" && EorH != "H")
                        {
                            Console.WriteLine("Mekanizmayı tekrar denetmek için 'E', programı kapatmak için 'H' yazınız: ");
                            EorH = Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Kenar yüksekliği(Width) için girebileceğiniz değerler [1,54] arasıdır.");
                        Console.WriteLine("Kenar genişliği(Width) için girebileceğiniz değerler [1,209] arasıdır.");
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

            void DrawBox(double g, double y)
            {
                Console.Write("+");
                for (int i = 0; i < g; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("+");

                for (int i = 0; i < y; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < g; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("|");
                }

                Console.Write("+");
                for (int i = 0; i < g; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("+");
            }
        }
    }

}