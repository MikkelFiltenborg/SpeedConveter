using SpeedConveter;

namespace Speed_Conveter
{
    public class WsCon
    {
        public static void Main(string[] args)
        {
            int i = 0;
            char input1 = ' ', input2 = ' ';
            string tofrom = "";
            double speed1 = 0, speed2 = 0;
            bool parse;

            for (i = 0; i < 1; i++)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n    Windspeede Converter" +
                                    "\n    It is not possible to convert from and to the same prefix.");
                    if (i == 0)
                    {
                        tofrom = "from";
                    }
                    else if (i == 1)
                    {
                        tofrom = "to";
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                    Console.WriteLine($"\n    Which of the following do you wish to convert {tofrom}");
                    Console.WriteLine("\n    m/s    [ 1 ]" +
                                      "\n    Km/t   [ 2 ]" +
                                      "\n    mph    [ 3 ]" +
                                      "\n    knots  [ 4 ]");

                    Console.SetCursorPosition(4, 10);
                    input1 = Console.ReadKey().KeyChar;
                    Console.SetCursorPosition(4, 10);
                    Console.WriteLine(" ");

                    Console.SetCursorPosition(4, 11);
                    Console.WriteLine($"Please enter the speed value");
                    Console.SetCursorPosition(4, 12);
                    parse = double.TryParse(Console.ReadLine(), out speed1);

                    if (!parse)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(5, 5);
                        Console.WriteLine("Error. No value set.");
                        Thread.Sleep(1500);

                    }

                } while (!parse);


                Console.SetCursorPosition(4, 11);
                Console.WriteLine("                            \n                             ");
                Console.SetCursorPosition(4, 10);
                input2 = Console.ReadKey().KeyChar;
                Console.SetCursorPosition(4, 10);
                Console.WriteLine(" ");
                Console.Clear();
            }

            string prefix = Calculator.Prefix(input1, input2);
            string[] split = prefix.Split('-');
            string prefix1 = split[0], prefix2 = split[1];

            speed2 = Calculator.SpeedCalculator1(speed1, speed2, input1, input2);

            Console.WriteLine($"{speed1} {prefix1} = {speed2} {prefix2}");
        }
    }
}