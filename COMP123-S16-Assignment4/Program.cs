using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 *Author: Md Mamunur Rahman 
 * Student ID: 300872772  
 * 
 * Date: July 11, 2016 
 * Description: This program demonstrates a Dice Rolling Simulation  
 *  
 * Version: 0.0.4 - added all comments
 */
namespace COMP123_S16_Assignment4
{
    /**
    * <summary>
    * This is the driver class for Dice Rolling Simulation project
    * </summary>
    * 
    * @class Program
    */

    class Program
    {
        //PRIVATE INSTANCE VARIABLE+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static Random _random;
        private static int _dice;
        private const int _defaultCount = 36000;
        private static List<int[]> _diceCount = new List<int[]>();

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
            _initialization();

            Console.ReadKey();
        }

        //PUBLIC PROPERTIES+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /**
         * <summary>
        * The property retun randon value of dice rolling
        * </summary>
        * @property Dice
        * @returns {int}
        */
        public static int Dice
        {
            get
            {
                _dice = _random.Next(1, 7);
                return _dice;
            }
        }

        /**
        * <summary>
        * The private static void initial method adds number of dices 
        * and initialise random object
        * </summary>
        * @method _initialization
        * @param {int} count
        * @returns {void}
        */
        private static void _initialization(int count = 2)
        {
            _random = new System.Random();

            //add number of dices
            for (int i = 0; i < count; i++)
            {
                _diceCount.Add(_diceRoll());
            }

            _buildDisplay();
        }
        /**
        * <summary>
        * The private static integer array method adds value of dices rolling
        * in array
        * </summary>
        * @method _diceRoll
        * @field {int[]} diceRoll
        * @param {int} count
        * @returns {int[]}
        */
        private static int[] _diceRoll(int count = _defaultCount)
        {
            int[] diceRoll = new int[count];

            for (int i = 0; i < count; i++)
            {
                diceRoll[i] = Program.Dice;
            }
            return diceRoll;
        }
        /**
        * <summary>
        * The private static integer array method make summation from the value of dices rolling
        * </summary>
        * @method _sumOfDicesResults
        * @field {int[]} result
        * @param {int} count
        * @returns {int[]}
        */
        private static int[] _sumOfDicesResults(int count = _defaultCount)
        {
            int[] result = new int[count];

            for (int i = 0; i < count; i++)
            {
                foreach (int[] item in _diceCount)
                {
                    result[i] += item[i];
                }


            }

            return result;
        }
        /**
         * <summary>
         * The private static void method build display dice result
         * </summary>
         * @method _buildDisplay
         * @field {int[,]} displaTable
         * @field {int[,]} repeatTime
         * @param {int} count
         * @returns {void}
         */

        private static void _buildDisplay(int count = _defaultCount)
        {
            //create display array of possible all sum value
            int[,] displaTable = new int[6, 6];


            for (int i = 0; i < 6; i++)
            {
                for (int ii = 0; ii < 6; ii++)
                {

                    displaTable[i, ii] = i + 1 + ii + 1;

                }

            }

            //create display array of actual all sum value
            int[,] repeatTime = new int[6, 6];

            foreach (int value in _sumOfDicesResults(count))
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int ii = 0; ii < 6; ii++)
                    {

                        if (displaTable[i, ii] == value)
                        {

                            repeatTime[i, ii]++;
                        }

                    }

                }

            }

            _display(displaTable, repeatTime);

        }
        /**
         * <summary>
         * The private static void method display dice result to console
         * </summary>
         * @method _display
         * @param {int[,]} indexSum
         * @param {int[,]} repeatTime
         * @returns {void}
         */
        private static void _display(int[,] indexSum, int[,] repeatTime)
        {
            Console.WriteLine("        1                2                3                4                5                6   ");


            for (int i = 0; i < 6; i++)
            {
                for (int ii = 0; ii < 6; ii++)
                {
                    if (indexSum[i, ii] > 9 && repeatTime[i, ii] > 9)
                    {
                        Console.Write((i+1) + " " + indexSum[i, ii] + ", " + repeatTime[i, ii] + " Roll| ");

                    }
                    else if (indexSum[i, ii] > 9 && repeatTime[i, ii] < 10)
                    {
                        Console.Write((i + 1) + " " + indexSum[i, ii] + ",  " + repeatTime[i, ii] + " Roll| ");
                    }
                    else if (indexSum[i, ii] < 10 && repeatTime[i, ii] > 9)
                    {
                        Console.Write((i + 1) + "  " + indexSum[i, ii] + ", " + repeatTime[i, ii] + " Roll| ");

                    }
                    else if (indexSum[i, ii] < 10 && repeatTime[i, ii] < 10)
                    {
                        Console.Write((i + 1) + "  " + indexSum[i, ii] + ",  " + repeatTime[i, ii] + " Roll| ");

                    }

                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

    }
}
