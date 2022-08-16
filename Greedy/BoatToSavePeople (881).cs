using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class BoatToSavePeople__881_
    {
        public static int NumRescueBoats(int[] people, int limit)
        {
            int boatCOunt = 0;
            Array.Sort(people);
            var left = 0;
            var right = people.Length - 1;
            while (left < right)
            {
                if (people[left] + people[right] <= limit)
                {
                    boatCOunt++;
                    left++;
                    right--;
                }
                else
                {
                    boatCOunt++;
                    right--;
                }
            }
            if (left == right)
            {
                boatCOunt++;
            }
            return boatCOunt;
        }
    }
}
