using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Debugging
{
	class RemovingSideEffects
	{
		public static void Main(string[] args)
		{
			var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
			var smallests = GetSmallests(numbers, 3);

			foreach (var number in numbers)
				Console.WriteLine(number);
		}

        //This Method currently returns a Side-Effect
		public static List<int> GetSmallests(List<int> list, int count)
		{
            //We are creating a variable here to do the processing of the list 
            var buffer = new List<int>(list);

			var smallests = new List<int>();

			while (smallests.Count < count)
			{
				var min = GetSmallest(list);
				smallests.Add(min);
                //Instead of removing the objects here from the original list
                list.Remove(min);
			}

			return smallests;
		}

		public static int GetSmallest(List<int> list)
		{
            //Assume the first number is the smallest
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
