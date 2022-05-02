using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Speed_Conveter;

namespace SpeedConveter
{
    public class Calculator
    {
        //determinates the prefix depending on user input.
        public static string Prefix(char input1, char input2)
        {
            string prefix1 = "", prefix2 = "";

            //chooses prefix for input.
            switch (input1)
            {
                case '1':
                    prefix1 = "m/s";
                    break;
                case '2':
                    prefix1 = "km/h";
                    break;
                case '3':
                    prefix1 = "mph";
                    break;
                case '4':
                    prefix1 = "knots";
                    break;
                default:
                    prefix1 = "Prefix Error 1";
                    break;
            }

            //chooses prefix for output.
            switch (input2)
            {
                case '1':
                    prefix2 = "m/s";
                    break;
                case '2':
                    prefix2 = "km/h";
                    break;
                case '3':
                    prefix2 = "mph";
                    break;
                case '4':
                    prefix2 = "knots";
                    break;
                default:
                    prefix2 = "Prefix Error 2";
                    break;
            }
           return ($"{prefix1}-{prefix2}");
        }

        //Calculated the correct speed to the users choice.
        public static double SpeedCalculator1(double speed1, double speed2, char input1, char input2)
        {
            //pulls from Prefix and puts it in prefix string before splitting into string array, and assigning array 0 to prefix1 and array 1 to prefix2.
            string prefix = Calculator.Prefix(input1, input2);
            string[] split = prefix.Split('-');
            string prefix1 = split[0], prefix2 = split[1];

            //preset error message.
            string errmsg = $"You can't convert {prefix1} to {prefix2}";

            //what prefix is speed1
            switch (input1)
            {
                //meters pr. sec. m/s.
                case '1':
                    //what prefix is speed2.
                    switch (input2)
                    {
                        //m/s -> km/h.
                        case '2':
                            speed2 = speed1 * 3.6;
                            break;

                        //m/s -> mph.
                        case '3':
                            speed2 = speed1 / 0.4470;
                            break;

                        //m/s -> knots.
                        case '4':
                            speed2 = speed1 * 1.9438;
                            break;
                    }
                    break;

                //kilometers pr. hour km/h.
                case '2':
                    //what prefix is speed2.
                    switch (input2)
                    {
                        //km/h -> m/s.
                        case '1':
                            speed2 = speed1 / 3.6;
                            break;

                        //km/h -> mph.
                        case '3':
                            speed2 = speed1 * 0.6214;
                            break;

                        //km/h -> knots.
                        case '4':
                            speed2 = speed1 * 1.852;
                            break;
                    }
                    break;

                //miles pr. hour mph.
                case '3':
                    //what prefix is speed2.
                    switch (input2)
                    {
                        //mph -> m/s.
                        case '1':
                            speed2 = speed1 * 0.4470;
                            break;

                        //mph -> km/h.
                        case '2':
                            speed2 = speed1 * 1.6093;
                            break;

                        //mph -> knots.
                        case '4':
                            speed2 = speed1 / 1.1508;
                            break;
                    }
                    break;

                //knots.
                case '4':
                    //what prefix is speed2.
                    switch (input2)
                    {
                        //knots -> m/s.
                        case '1':
                            speed2 = speed1 * 0.5144;
                            break;

                        //knots -> km/h.
                        case '2':
                            speed2 = speed1 * 0.54;
                            break;

                        //knots -> mph.
                        case '3':
                            speed2 = speed1 * 1.1508;
                            break;
                    }
                    break;

                //Error message.
                default:
                    Console.Write(errmsg);
                    break;
            }
            return speed2;
        }
    }
}
