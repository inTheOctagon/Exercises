using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.Utku.CustomProgressBar
{
    public class Helper
    {

        public void DrawProgressBar()
        {
            int barSayisi;
            int barGenisligi;
            ConsoleKeyInfo cki;
            string barKarakteri;
            string barIslemMetni;
            string barIslemSonuMetni;
            int barMetinRengiNo = 0;
            ConsoleColor barMetinRengi;
            int barRengiNo = 0;
            ConsoleColor barRengi;

            //n
            Console.Write("Kaç adet Progress Bar oluşturulacak: ");
            if (!(Int32.TryParse(Console.ReadLine(), out barSayisi) && 0 < barSayisi && barSayisi <= 10))
            {
                barSayisi = 1;
            }


            //g
            Console.Write("Progress Bar Genişliği: ");
            if (!(Int32.TryParse(Console.ReadLine(), out barGenisligi) && 0 < barGenisligi && barGenisligi <= 50))
            {
                barGenisligi = 50;
            }


            //c
            Console.Write("Progress Bar Karakteri: ");
            cki = Console.ReadKey();
            
            
            
            if ((cki.KeyChar) != '\r' && !Char.IsDigit(cki.KeyChar))
            {
                barKarakteri = cki.KeyChar.ToString();
            }
            else
            {
                barKarakteri = "#";
            }

            Console.WriteLine();

            //işlem metni
            Console.Write("Progress Bar İşlem Metni: ");
            barIslemMetni = Console.ReadLine();
            if (barIslemMetni.Length > 30 || barIslemMetni.Length == 0)
            {
                barIslemMetni = "İndiriliyor...";
            }


            //işlem sonu metni
            Console.Write("Progress Bar İşlem Sonu Metni: ");
            barIslemSonuMetni = Console.ReadLine();
            if (barIslemSonuMetni.Length > 30 || barIslemMetni.Length == 0)
            {
                barIslemSonuMetni = "İndirildi.";
            }

            //bar metni rengi
            Console.Write("Progress Bar Metin Rengi [1-15]: ");
            if (Int32.TryParse(Console.ReadLine(), out barMetinRengiNo))
            {

                barMetinRengi = ChooseColor(barMetinRengiNo);
            }
            else
            {
                barMetinRengi = ChooseColor(15);
            }

            //bar rengi
            Console.Write("Progress Bar Rengi [1-15]: ");

            if (Int32.TryParse(Console.ReadLine(), out barRengiNo))
            {
                barRengi = ChooseColor(barRengiNo);
            }
            else
            {
                barRengi = ChooseColor(15);
            }

            Console.Clear();

            DrawBar(barSayisi, barGenisligi, barKarakteri, barIslemMetni, barIslemSonuMetni, barMetinRengi, barRengi);
        }

        private void DrawBar(int barSayisi, int barGenisligi, string barKarakteri, string barIslemMetni, string barIslemSonuMetni, ConsoleColor barMetinRengi, ConsoleColor barRengi)
        {
            int cursorPosX = 0;
            int cursorPosY = 0;

            double percentage = 0;

            

            for (int i = 0; i < barSayisi; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                cursorPosX += cursorPosX + 1;

                for (int j = 0; j < barGenisligi; j++)
                {
                    Console.ForegroundColor = barRengi;
                    Console.SetCursorPosition(cursorPosX, cursorPosY);
                    Console.Write(barKarakteri);
                    cursorPosX += 1;
                    Console.SetCursorPosition(barGenisligi + 2, cursorPosY);
                    percentage += 100 / barGenisligi;
                    Thread.Sleep(100);
                    Console.ForegroundColor = barMetinRengi;
                    Console.Write(percentage.ToString() + "% " + barIslemMetni);
                    Console.SetCursorPosition(cursorPosX, cursorPosY);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]");
                Console.SetCursorPosition(barGenisligi + 2, cursorPosY);
                Console.ForegroundColor = barMetinRengi;
                Console.Write("100" + "% " + barIslemSonuMetni);
                cursorPosY += 1;
                cursorPosX = 0;
                Console.SetCursorPosition(cursorPosX, cursorPosY);
                percentage = 0;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private ConsoleColor ChooseColor(int renkNo)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            switch (renkNo)
            {
                case 1:
                    return colors[1];
                case 2:
                    return colors[2];
                case 3:
                    return colors[3];
                case 4:
                    return colors[4];
                case 5:
                    return colors[5];
                case 6:
                    return colors[6];
                case 7:
                    return colors[7];
                case 8:
                    return colors[8];
                case 9:
                    return colors[9];
                case 10:
                    return colors[10];
                case 11:
                    return colors[11];
                case 12:
                    return colors[12];
                case 13:
                    return colors[13];
                case 14:
                    return colors[14];
                case 15:
                    return colors[15];
                default:
                    return colors[15];
            }
        }

    }
}
