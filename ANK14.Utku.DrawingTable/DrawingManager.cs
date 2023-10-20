using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ANK14.Utku.DrawingTable
{
    public class DrawingManager
    {
        private bool again;

        public DrawingManager()
        {
            again = true;
        }

        public void ManageDrawing()
        {
            while(again) 
            {
                Console.Clear();

                Console.Write("Tablo için 1-27 aralığında bir satır (row) ve 1-70 aralığında bir sütun (column) değeri giriniz (Örn: 2x4): ");
                var processNums = CheckInputValidity(Console.ReadLine());

                if (processNums[0] != 0 && processNums[1] != 0)
                {
                    DrawTable(processNums[0], processNums[1]);

                    if(CheckAgain())
                    {
                        again = true;
                    }
                    else
                    {
                        again = false;
                    }
                }
            }
        }

        private int[] CheckInputValidity(string input)
        {
            int[] output = { 0, 0 };

            if (input.Length > 0 && Char.IsDigit(input[0]) && input.Where(c => c == 'x').Count() == 1)
            {
                var supposedNums = input.Split("x");
              
                int rowNum;
                int columnNum;

                for (int i = 0; i < output.Length; i++)
                {
                    if (i == 0 && int.TryParse(supposedNums[i], out rowNum) && 0 < rowNum && rowNum < 28)
                    {
                        output[i] = rowNum;
                    }
                    if (i == 1 && int.TryParse(supposedNums[i], out columnNum) && 0 < columnNum && columnNum < 71)
                    {
                        output[i] = columnNum;
                    }
                }

                return output;
            }
            else
            {
                return output;
            }
        }

        private void DrawTable(int rowNum, int columnNum)
        {
           for (int i = 0; i < rowNum; i++) 
            { 
                for(int j = 0; j < columnNum; j++)
                {
                    Console.Write("+--");
                }
                Console.WriteLine("+");

                for (int j = 0; j < columnNum; j++)
                {
                    Console.Write("|  ");
                }
                Console.WriteLine("|");
            }

            for (int j = 0; j < columnNum; j++)
            {
                Console.Write("+--");
            }
            Console.WriteLine("+");
        }

        private bool CheckAgain()
        {
            bool again = true;
            bool output = false;

            while(again)
            {
                Console.Write("Tekrar denemek için 'E' ya da çıkmak için 'H' yazınız: ");
                var keyInfo = Console.ReadKey();
                
                if(keyInfo.KeyChar == 'E')
                {
                    output = true;
                    again = false;
                }
                else if(keyInfo.KeyChar == 'H')
                {
                    output = false;
                    again = false;
                }

                Console.Clear();
            }


            return output;
            
        }
    }
}
