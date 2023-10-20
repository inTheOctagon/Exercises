namespace ANK14.Utku.ProgressBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barCount = 0;

            bool again = true;

            string EorH = "";

            PrintMainStatement();

            while (again) 
            {
                if(Int32.TryParse(Console.ReadLine(), out barCount) )
                {
                    if(0 < barCount && barCount <= 10) 
                    {
                        DrawProgressBar(barCount);

                        EorH = "";

                        while(EorH != "E" && EorH != "H")
                        {
                            Console.Write("Tekrar denemek için 'E', çıkmak için 'H' yazınız: ");
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            Console.Clear();
                            switch (keyInfo.KeyChar)
                            {
                                case 'E':
                                    EorH = "E";
                                    again = true;
                                    PrintMainStatement();
                                    break;
                                case 'H':
                                    EorH = "H";
                                    again = false;
                                    break;
                                default:
                                    EorH = "";
                                    break;
                            }  
                        }   
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("1-10 aralığındaki bir tamsayı girmelisiniz: ");
                    }
                }
                else
                {
                    Console.Clear();
                    PrintMainStatement();
                }
            }

           void PrintMainStatement()
            {
                Console.Write("Kaç tane progress bar oluşturulacağını seçiniz: ");
            }
           void DrawProgressBar(int barCount)
            {
                int cursorPosX = 0;
                int cursorPosY = 1;

                int percentage = 0;

                for (int i = 0; i < barCount; i++)
                {
                    Console.Write("[");
                    cursorPosX += cursorPosX + 1;
                    for (int j = 0; j < 50; j++)
                    {
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        Console.Write("#");
                        cursorPosX += 1;
                        Console.SetCursorPosition(53, cursorPosY);
                        percentage += 2;
                        Thread.Sleep(100);
                        Console.Write(percentage.ToString()+"% Downloading.");
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                    }
                    Console.Write("]");
                    Console.SetCursorPosition(53, cursorPosY);
                    Console.Write(percentage.ToString() + "% Downloaded.");
                    cursorPosY += 1;
                    cursorPosX = 0;
                    Console.SetCursorPosition(cursorPosX, cursorPosY);
                    percentage = 0;
                }
            }
        }
    }
}