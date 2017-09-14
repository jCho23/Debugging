﻿using System;
using System.Collections.Generic;

namespace Debugging
{
    public class DefensiveProgramming
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2,};
            var smallests = GetSmallests(numbers, 3);

            foreach (var number in numbers)
                Console.WriteLine(number);
        }

        //We are putting the conditional statement here to fix the source of the problem
        public static List<int> GetSmallests(List<int> list, int count)
        {
            //Here, we are checking the count of the numbers in the list
            //Notice that we put a detailed message here so that if there is an exception, 
            //we know where the problem is
            if (count > list.Count)
                throw new ArgumentOutOfRangeException("count", "Count cannot be greater than the numbers in the list.");

            var buffer = new List<int>(list);

            var smallests = new List<int>();

            while (smallests.Count < count)
            {
                
                var min = GetSmallest(buffer);
                smallests.Add(min);
              
                buffer.Remove(min);
            }

            return smallests;
        }

        public static int GetSmallest(List<int> list)
        {
            var min = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] < min)
                    min = list[i];
            }

            return min;
        }

    }
}
