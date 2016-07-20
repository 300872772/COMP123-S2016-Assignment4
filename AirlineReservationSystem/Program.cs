﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 *Author: Md Mamunur Rahman 
 * Student ID: 300872772  
 * 
 * Date last modified: July 19, 2016 
 * Description: This program demonstrates an Airline Reservation System  
 *  
 * Version: 0.0.4 - added all comments
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

        private static List<string> _assignedSeats = new List<string>();
        private static List<List<String>> _seatingChart = new List<List<String>>();


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
            _initialized();
            _programMenu();
        }


        //PRIVATE MATHODS+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
        * <summary>
        * This method creates option to select program menue
        * </summary>
        * @method _programMenu
        * @field {sting} choice
        * @returns {void}
        */
        private static void _programMenu()
        {
            string choice;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                _displayMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _showSeats(0);
                        _selectSeats(0);
                        break;
                    case "2":
                        _showSeats(1);
                        _selectSeats(1);
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
        /**
        * <summary>
        * This method display program menue
        * </summary>
        * @method _displayMenu
        * @returns {void}
        */
        private static void _displayMenu()
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

        /**
         * <summary>
         * This method initialized the value of variable or objects
         * </summary>
         * @method _initialized
         * @returns {void}
         */
        private static void _initialized()
        {
            //adding seat data
            _seatingChart.Add(new List<string>());
            _seatingChart.Add(new List<string>());

            for (int i = 0; i < 5; i++)
            {
                _seatingChart[0].Add("Economy " + (i + 1));
                _seatingChart[1].Add("First Class " + (i + 1));
            }


        }
        /**
        * <summary>
        * This method show available seats according to menue selected
        * </summary>
        * @method _showSeats
        * @param {int} seatType
        * @returns {void}
        */
        private static void _showSeats(int seatType)
        {
            if (seatType == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine();
            Console.WriteLine("-------Available Seats-------");
            if (_seatingChart[seatType].Count != 0)
            {
                foreach (string seat in _seatingChart[seatType])
                {
                    Console.WriteLine(seat);
                }
            }
            else
            {
                Console.WriteLine("*****EMPTY*****");
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
        }

        /**
         * <summary>
         * This method execute all the functionalities of seat selection
         * </summary>
         * @method _selectSeats
         * @param {int} seatType
         * @fields {string} yesNo
         * @fields {string} seatNumberEntryString
         * @fields {char} seatNumberEntryChar
         * @fields {int} seatNumberEntry
         * @fields {string} seatNumber
         * @fields {string} forwardClassName
         * @returns {void}
         */
        private static void _selectSeats(int seatType)
        {
            //string variable for yes/no input
            string yesNo = "Y";

            //looping for repeated seat selection untill inter 'N'
            do
            {   //condition for whether seat is avaialble in a class according to seatType parameter
                if (_seatingChart[seatType].Count != 0)
                {
                    //seat selection entry
                    Console.Write("Select your seat number(only number), for Exit press X: ");
                    string seatNumberEntryString = Console.ReadLine().ToString();

                    //condition, if seat number entry is not null
                    if (seatNumberEntryString != "")
                    {
                        char seatNumberEntryChar = Convert.ToChar(seatNumberEntryString.ToUpper());

                        //X for exit entry from seat selection
                        if (seatNumberEntryChar == 'X')
                        {
                            break;
                        }
                        //if the entry is not a number
                        else if ((int)seatNumberEntryChar > 57 || (int)seatNumberEntryChar < 48)
                        {
                            Console.WriteLine("You can not enter other than number, try again");
                        }
                        //if the entry is a number
                        else
                        {
                            int seatNumberEntry = Convert.ToInt32(seatNumberEntryString);

                            //if the particuler seat number is not available
                            if (seatNumberEntry > _seatingChart[seatType].Count && seatNumberEntry < 1)
                            {
                                Console.WriteLine("Invalid Seat Number, try again");
                            }
                            //if the particuler seat number is available
                            else
                            {
                                //searching for the entered seat number in the _seatingChart list
                                for (int i = 0; i < _seatingChart[seatType].Count; i++)
                                {
                                    string seatNumber = _seatingChart[seatType][i].Substring(_seatingChart[seatType][i].Length - 1, 1);

                                    if (Convert.ToInt32(seatNumber) == seatNumberEntry)
                                    {
                                        //if seat number is found, add in _assignedSeat list and remove the seat from _seatingChart
                                        _assignedSeats.Add(_seatingChart[seatType][i].ToString());
                                        _seatingChart[seatType].RemoveAt(i);
                                        break;
                                    }
                                    //if searching does not find the entered seat number available
                                    else if ((i + 1) == _seatingChart[seatType].Count)
                                    {
                                        Console.WriteLine("Particular seat you have selected is not available. ");
                                        break;
                                    }


                                }

                                //looping for further seat selection and showing seats
                                do
                                {
                                    Console.Write("\nThank you for booking seat. Do you want to book more? Y/N? ");
                                    yesNo = Console.ReadLine();

                                    if (yesNo.ToUpper() != "Y" && yesNo.ToUpper() != "N")
                                    {
                                        Console.WriteLine("Invalid entry");

                                    }
                                    else if (yesNo.ToUpper() == "Y")
                                    {
                                        _showSeats(seatType);
                                        break;
                                    }

                                } while (yesNo.ToUpper() != "N");
                            }



                        }
                    }
                    // if seat number entry is null, showing the message
                    else
                    {
                        Console.WriteLine("No seat has been selected ");
                    }
                }

                //if seat is not avaialble in a class, option to switch to another class
                else
                {
                    string forwardClassName = "";
                    if (seatType == 0) { forwardClassName = "First"; seatType = 1; }
                    else if (seatType == 1) { forwardClassName = "Economy"; seatType = 0; }

                    Console.WriteLine("No more seat available in this class ");
                    Console.Write("Do you want to book in {0} class? Y/N ", forwardClassName);
                    yesNo = Console.ReadLine();

                    if (yesNo.ToUpper() != "Y" && yesNo.ToUpper() != "N")
                    {
                        Console.WriteLine("Invalid entry");

                    }
                    if (yesNo.ToUpper() == "Y")
                    {
                        _showSeats(seatType);

                    }
                    else if (yesNo.ToUpper() == "N")
                    {
                        Console.WriteLine("Next	flight	leaves	in	3	hours");
                    }
                }

                //if there is no seat avaialble in any of the classes, exit from seat selection loop
                if (_seatingChart[0].Count == 0 && _seatingChart[1].Count == 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, No more seat available in this flight.");
                    Console.WriteLine("Next flight leaves in 3 hours");
                    break;
                }
            } while (yesNo.ToUpper() != "N");
        }
    }
}
