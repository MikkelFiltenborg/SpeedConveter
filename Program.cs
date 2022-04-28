using SpeedConveter;

namespace Speed_Conveter
{
    public class WsCon
    {
        public static void Main(string[] args)
        {
            char input1 = ' ', input2 = ' ';
            double speed1 = 0, speed2 = 0;
            bool parser;

            //clear, followed header.
            Console.Clear();
            Console.WriteLine("\n    Windspeede Converter" +
                              "\n    It is not possible to convert from and to the same prefix.");
            do
            {
                Console.Clear();

                //menu.
                Console.WriteLine("\n    Which of the following do you wish to convert from");
                Console.WriteLine("\n    m/s    [ 1 ]" +
                                  "\n    Km/t   [ 2 ]" +
                                  "\n    mph    [ 3 ]" +
                                  "\n    knots  [ 4 ]");

                //recieves chosen user input prefix.
                Console.SetCursorPosition(4, 10);
                input1 = Console.ReadKey().KeyChar;
                Console.SetCursorPosition(4, 10);
                Console.WriteLine(" ");

                //constrolls user only inputs valid response.
                if (input1 == '1' || input1 == '2' || input1 == '3' || input1 == '4')
                {
                    parser = true;
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("You can only choose between the given prefix options.");
                    Thread.Sleep(1500);
                    parser = false;
                }
            } while (!parser);

            do
            {
                Console.Clear();
                //recieves user input speed value.
                Console.SetCursorPosition(4, 5);
                Console.WriteLine($"Please enter the speed value");
                Console.SetCursorPosition(4, 6);
                parser = double.TryParse(Console.ReadLine(), out speed1);

                //error message.
                if (!parser)
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("Error. No value set.");
                    Thread.Sleep(1500);
                }
            } while (!parser);

            do
            {
                Console.Clear();

                //menu.
                Console.WriteLine("\n    Which of the following do you wish to convert to");
                Console.WriteLine("\n    m/s    [ 1 ]" +
                                  "\n    Km/t   [ 2 ]" +
                                  "\n    mph    [ 3 ]" +
                                  "\n    knots  [ 4 ]");

                //recieves chosen user output prefix.
                Console.SetCursorPosition(4, 11);
                Console.WriteLine("                            \n                             ");
                Console.SetCursorPosition(4, 10);
                input2 = Console.ReadKey().KeyChar;
                Console.SetCursorPosition(4, 10);
                Console.WriteLine(" ");
                Console.Clear();

                if (input2 != input1)
                {
                    //constrolls user only inputs valid response.
                    if (input2 == '1' || input2 == '2' || input2 == '3' || input2 == '4')
                    {
                        parser = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(5, 5);
                        Console.WriteLine("You can only choose between the given prefix options.");
                        Thread.Sleep(1500);
                        parser = false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("You cannot chose the same ooutput prefix as your input prefix.");
                    Thread.Sleep(1500);
                    parser = false;
                }

            } while (!parser);

            //pulls from Prefix and puts it in prefix string before splitting into string array, and assigning array 0 to prefix1 and array 1 to prefix2.
            string prefix = Calculator.Prefix(input1, input2);
            string[] split = prefix.Split('-');
            string prefix1 = split[0], prefix2 = split[1];

            //pulls the sum of the output speed value.
            speed2 = Calculator.SpeedCalculator1(speed1, speed2, input1, input2);


            //outputs written result to user.
            Console.WriteLine($"{speed1} {prefix1} = {speed2} {prefix2}");
        }
    }
}