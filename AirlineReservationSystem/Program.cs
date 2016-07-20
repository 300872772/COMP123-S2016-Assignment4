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
 * Version: 0.0.2 - added all seat display and selection system
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
        //PRIVATE INSTANCE VARIABLE+++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // private static List<string> _seatingChart = new List<string>();
        private static List<string> _assignedSeats = new List<string>();
        private static List<List<String>> _seatingChart = new List<List<String>>();
        //PROPERTIES




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
            Initialized();
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
                        ShowSeats(0);
                        SelectSeats(0);
                        break;
                    case "2":
                        ShowSeats(1);
                        SelectSeats(1);
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
            Console.Write("{0,15}", "Enter the number of your choice -> ");

        }


        static void Initialized()
        {
            //adding seat data
            _seatingChart.Add(new List<string>());
            _seatingChart.Add(new List<string>());

            for (int i = 0; i < 5; i++)
            {
                _seatingChart[0].Add("Economy " + (i + 1));
                _seatingChart[1].Add("Firat Class " + (i + 1));
            }


        }

        static void ShowSeats(int seatType)
        {

            foreach (var seat in _seatingChart[seatType])
            {
                Console.WriteLine(seat);
            }




        }

        static void SelectSeats(int seatType)
        {
            string yesNo = "Y";
            do
            {
                Console.Write("Select your seat number(only number), for Exit press X: ");
                string seatNumberEntryString = Console.ReadLine().ToString();

                if (seatNumberEntryString != "")
                {
                   // int seatNumberEntry;
                    char seatNumberEntryChar = Convert.ToChar(seatNumberEntryString.ToUpper());

                    if (seatNumberEntryChar == 'X')
                    {
                        break;
                    }
                    else if ((int)seatNumberEntryChar > 57 || (int)seatNumberEntryChar < 48)
                    {
                        Console.WriteLine("You can not enter other than number, try again");
                    }

                    else
                    {
                       int seatNumberEntry = Convert.ToInt32(seatNumberEntryString);


                        if (seatNumberEntry > _seatingChart[seatType].Count && seatNumberEntry < 1)
                        {
                            Console.WriteLine("Invalid Seat Number, try again");
                        }

                        else
                        {
                            for (int i = 0; i < _seatingChart[seatType].Count; i++)
                            {
                                string seatNumber = _seatingChart[seatType][i].Substring(_seatingChart[seatType][i].Length - 1, 1);
                                
                                if (Convert.ToInt32(seatNumber) == seatNumberEntry)
                                {
                                    _assignedSeats.Add(_seatingChart[seatType][i].ToString());
                                    _seatingChart[seatType].RemoveAt(i);
                                    break;
                                }
                                else if((i+1) == _seatingChart[seatType].Count)
                                {
                                    
                                 Console.WriteLine("Particular seat you have selected is not available. ");
                                    break;
                                }

                            }



                            do
                            {
                                Console.Write("Thank you for booking seat. Do you want to book more? Y/N? ");
                                yesNo = Console.ReadLine();

                                if (yesNo.ToUpper() != "Y" && yesNo.ToUpper() != "N")
                                {
                                    Console.WriteLine("Invalid entry");

                                }
                                else if (yesNo.ToUpper() == "Y")
                                {
                                    ShowSeats(seatType);
                                    break;
                                }

                            } while (yesNo.ToUpper() != "N");
                        }
                    }
                }
            } while (yesNo.ToUpper() != "N");
        }
    }
}
