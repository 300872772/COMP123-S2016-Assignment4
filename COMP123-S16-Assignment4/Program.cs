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
 * Version: 0.0.3 - added sum of rolling and display functionality
 */
namespace COMP123_S16_Assignment4
{
    class Program
    {
        private static Random _random;
        private static int _dice;
        private const int _defaultCount = 36000;
        private static List<int[]> _diceCount = new List<int[]>();



        static void Main(string[] args)
        {
            _initialization();

            Console.ReadKey();
        }

        public static int Dice
        {
            get
            {
                _dice = _random.Next(1, 7);
                return _dice;
            }
        }



        private static void _initialization(int count = 2)
        {
            _random = new System.Random();

            for (int i = 0; i < count; i++)
            {
                _diceCount.Add(_diceRoll());
            }

            _buildDisplay();
        }

        private static int[] _diceRoll(int count = _defaultCount)
        {
            int[] diceRoll = new int[count];

            for (int i = 0; i < count; i++)
            {
                diceRoll[i] = Program.Dice;
            }
            return diceRoll;
        }

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


        private static void _buildDisplay(int count = _defaultCount)
        {
            int[,] displaTable = new int[6, 6];


            for (int i = 0; i < 6; i++)
            {
                for (int ii = 0; ii < 6; ii++)
                {

                    displaTable[i, ii] = i + 1 + ii + 1;

                }

            }


            int[,] indexSum = new int[6, 6];
            int[,] repeatTime = new int[6, 6];

            foreach (int value in _sumOfDicesResults(count))
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int ii = 0; ii < 6; ii++)
                    {

                        if (displaTable[i, ii] == value)
                        {
                            //indexSum[i,ii] += displaTable.ElementAt(i)[ii];
                            repeatTime[i, ii]++;
                        }

                    }

                }

            }

            _display(displaTable, repeatTime);

        }

        private static void _display(int[,] indexSum, int[,] repeatTime)
        {
            Console.WriteLine("        1                2                3                4                5                6   ");


            for (int i = 0; i < 6; i++)
            {
                for (int ii = 0; ii < 6; ii++)
                {
                    if (indexSum[i, ii] > 9 && repeatTime[i, ii] > 9)
                    {
                        Console.Write(i + " " + indexSum[i, ii] + ", " + repeatTime[i, ii] + " Roll| ");

                    }
                    else if (indexSum[i, ii] > 9 && repeatTime[i, ii] < 10)
                    {
                        Console.Write(i + " " + indexSum[i, ii] + ",  " + repeatTime[i, ii] + " Roll| ");
                    }
                    else if (indexSum[i, ii] < 10 && repeatTime[i, ii] > 9)
                    {
                        Console.Write(i + "  " + indexSum[i, ii] + ", " + repeatTime[i, ii] + " Roll| ");

                    }
                    else if (indexSum[i, ii] < 10 && repeatTime[i, ii] < 10)
                    {
                        Console.Write(i + "  " + indexSum[i, ii] + ",  " + repeatTime[i, ii] + " Roll| ");

                    }

                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

    }
}
