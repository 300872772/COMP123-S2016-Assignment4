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
 * Version: 0.0.2 - added Dice property, _diceRoll and _initialization methods
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

    }
}
