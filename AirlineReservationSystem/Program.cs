using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 *Author: Md Mamunur Rahman 
 * Student ID: 300872772  
 * 
 * Date: July 13, 2016 
 * Description: This program demonstrates an Airline Reservation System  
 *  
 * Version: 0.0.1 - added all instance variable, display menu methods
 */
namespace AirlineReservationSystem
{
    /**
    * <summary>
    * This is the driver class for Airline Reservation System project
    * </summary>
    * 
    * @class Program
    */

    class Program
    {
        //MAIN MATHOD+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * The main method for our driver class Program
        * </summary>
        * @method Main
        * @param {sting[]} args
        * @returns {void}
        */
        static void Main(string[] args)
        {

            _programMenu();
        }

        private static void _programMenu()
        {
            string choice;

            do
            {
                DisplayMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("First class");
                        break;
                    case "2":
                        Console.WriteLine("Economy Class") ;
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using this program");
                        break;
                    default:
                        Console.WriteLine("Error in entry");
                        break;

                }

            } while (choice != "3");


        }

        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=============Airline Reservation Systems==================");
            Console.WriteLine("|         1. First Class                                 |");
            Console.WriteLine("|         2. Economy Class                               |");
            Console.WriteLine("|         3. End program                                 |");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("==========================================================\n");
            Console.Write("{0,15}", "Enter the number of your choice ->");

        }

    }
}
