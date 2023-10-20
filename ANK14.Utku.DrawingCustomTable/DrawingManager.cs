using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANK14.Utku.DrawingCustomTable
{
    public class DrawingManager
    {
        private bool again;
        private bool wh;

        int[] rowAndColumnNums;
        int[] widthAndHeighNums;

        public DrawingManager()
        {
            again = true;

            rowAndColumnNums = new int[2];
            widthAndHeighNums = new int[2];
        }

        public void ManageDrawing()
        {
            while (again)
            {
                Console.Clear();

                if (!wh)
                {
                    Console.Write("Tablo için bir satır (row) ve bir sütun (column) değeri giriniz (Örn: 2x4): ");
                    rowAndColumnNums = CheckInputValidity(Console.ReadLine());
                    if((rowAndColumnNums[0] != 0 && rowAndColumnNums[1] != 0))
                    {
                        wh = true;
                    }
                }
                else
                {
                    Console.Write("Tablo için bir satır genişliği (width) ve bir sütun yüksekliği (height) değeri giriniz (Örn: 2x4): ");
                    widthAndHeighNums = CheckInputValidity(Console.ReadLine(), rowAndColumnNums);
                    if ((widthAndHeighNums[0] != 0 && widthAndHeighNums[1] != 0))
                    {
                        wh = false;
                    }
                }
                

                if (rowAndColumnNums[0] != 0 && rowAndColumnNums[1] != 0 && widthAndHeighNums[0] != 0 && widthAndHeighNums[1] != 0)
                {
                    DrawTable(rowAndColumnNums[0], rowAndColumnNums[1], widthAndHeighNums[0], widthAndHeighNums[1]);

                    if (CheckAgain())
                    {
                        again = true;
                        rowAndColumnNums = new int[2];
                        widthAndHeighNums = new int[2];

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

        private int[] CheckInputValidity(string input, int[] arr)
        {
            int[] output = { 0, 0 };

            int rowNum;
            int columnNum;

            var supposedNums = input.Split("x");

            if (input.Length > 0 && Char.IsDigit(input[0]) && input.Where(c => c == 'x').Count() == 1 && int.TryParse(supposedNums[0], out rowNum) && int.TryParse(supposedNums[1], out columnNum))
            {

                for (int i = 0; i < output.Length; i++)
                {
                    if (0 < rowNum && rowNum < 210 / arr[1])
                    {
                        output[i] = rowNum;
                    }
                    if (0 < columnNum && columnNum < 54/ arr[0])
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

        private void DrawTable(int rowNum, int columnNum, int rowWidth, int columnHeight)
        {
            for (int i = 0; i < rowNum; i++)
            {

                for (int j = 0; j < columnNum; j++)
                {
                    Console.Write("+");

                    for (int l = 0; l < rowWidth; l++)
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine("+");

                for (int j = 0; j < columnHeight; j++)
                {
                    for (int k = 0; k < columnNum; k++)
                    {
                        Console.Write("|");
                        for (int l = 0; l < rowWidth; l++)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("|");
                }   
            }

            for (int j = 0; j < columnNum; j++)
            {
                Console.Write("+");

                for (int l = 0; l < rowWidth; l++)
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine("+");
        }

        private bool CheckAgain()
        {
            bool again = true;
            bool output = false;

            while (again)
            {
                Console.Write("Tekrar denemek için 'E' ya da çıkmak için 'H' yazınız: ");
                var keyInfo = Console.ReadKey();

                if (keyInfo.KeyChar == 'E')
                {
                    output = true;
                    again = false;
                }
                else if (keyInfo.KeyChar == 'H')
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
