using SpeedConveter;

namespace Speed_Conveter
{
    public class WsCon
    {
        public static void Main(string[] args)
        {
            char input1 = ' ', input2 = ' ', input3 = ' ';
            double speed1 = 0, speed2 = 0;
            bool parser = false, check = true, repeat = false;

            do
            {
                //clear, followed by header.
                Console.Clear();
                Console.WriteLine("\n    Windspeede Converter" +
                                  "\n    It is not possible to convert from and to the same prefix.");

                //UserInput1.
                input1 = WsCon.UserInput1(input1, parser);

                //SpeedValueInput.
                speed1 = WsCon.SpeedValueInput(speed1, parser);

                //UserInput2.
                input2 = WsCon.UserInput2(input2, input1, parser);

                //pulls from Prefix and puts it in prefix string before splitting into string array, and assigning array 0 to prefix1 and array 1 to prefix2.
                string prefix = Calculator.Prefix(input1, input2);
                string[] split = prefix.Split('-');
                string prefix1 = split[0], prefix2 = split[1];

                //pulls the sum of the output speed value.
                speed2 = Calculator.SpeedCalculator1(speed1, speed2, input1, input2);

                //UserInput3.
                WsCon.UserInput3(input3, speed1, speed2, prefix1, prefix2, repeat, check);

            } while (!repeat);
        }

        //returns the users input value for which value to covert from.
        public static char UserInput1(char input1, bool parser)
        {
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

                parser = WsCon.InputValid(input1, parser);

            } while (!parser);
            return input1;
        }

        //returns the users input for which value to convert to.
        public static char UserInput2(char input2, char input1, bool parser)
        {
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

                parser = WsCon.InputCheck(input1, input2, parser);

            } while (!parser);
            return input2;
        }

        //checks the users input2 for validity.
        public static bool InputCheck(char input1, char input2, bool parser)
        {
            //checks if input1 and input2 are different.
            if (input2 != input1)
            {
                parser = WsCon.InputValid(input2, parser);
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("You cannot chose the same output prefix as your input prefix.");
                Thread.Sleep(1500);
                parser = false;
            }
            return parser;
        }

        public static bool InputValid(char input, bool parser)
        {
            //constrolls user only inputs valid response.
            if (input == '1' || input == '2' || input == '3' || input == '4')
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
            return parser;
        }

        //returns the users choice to eithe quit or return to menu.
        public static bool UserInput3(char input3, double speed1, double speed2, string prefix1, string prefix2, bool repeat, bool check)
        {
            do
            {
                check = true;
                //outputs written result to user.
                Console.WriteLine($"{speed1} {prefix1} = {speed2} {prefix2}");

                Console.WriteLine("\nIf you wish you return to the main menu press [ R ]\nIf you wish to exit this program, press [ Q ]");
                input3 = Console.ReadKey().KeyChar;
                Console.SetCursorPosition(1, 5);
                Console.Write(" ");

                if (input3 == 'r' || input3 == 'R')
                {
                    repeat = false;
                }
                else if (input3 == 'q' || input3 == 'Q')
                {
                    repeat = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n   Error. Invalid input");
                    Thread.Sleep(1500);
                    check = false;
                }
                Console.Clear();
            } while (!check);
            return repeat;
        }

        //returns the users speed value input.
        public static double SpeedValueInput(double speed1, bool parser)
        {
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
            return speed1;
        }
    }
}