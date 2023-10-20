namespace ANK14.Utku.CustomProgressBar
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            bool again = true;
            
            string EorH = "E";

            Helper helper = new Helper();

            while (again)
            {
                Console.Clear();

                if (EorH == "E") 
                {
                    helper.DrawProgressBar();
                    //ye
                }

                Console.Write("Tekrar denemek için 'E', çıkmak için 'H' yazınız: ");

                EorH = Console.ReadKey().KeyChar.ToString(); 
                     
                if (EorH == "E" || EorH == "H")
                {
                    switch (EorH)
                    {
                        case "E":
                            again = true;
                            break;
                        case "H":
                            again = false;
                            break;
                        default:
                            break;

                    }
                } 
            }

            

        }
    }
}