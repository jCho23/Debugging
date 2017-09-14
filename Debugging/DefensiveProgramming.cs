using System;
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
            //This || "or" statment is here to defend a count that might be 0
            if (count > list.Count || count <=0)
                throw new ArgumentOutOfRangeException("count", "Count should be between 1 and the number of elements in the list");

            //What if the list is null?
            //We use another conditional statement to DEFEND and ensure the user asks the "right" question
            if (list == null)
                throw new ArgumentOutOfRangeException("list", "Count cannot be null");


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
