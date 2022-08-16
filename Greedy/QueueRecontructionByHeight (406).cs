using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class QueueRecontructionByHeight__406_
    {
        public static int[][] ReconstructQueue(int[][] people)
        {

            List<int[]> res = new List<int[]>();

            var sortedPeople = people.ToList().OrderByDescending(x => x[0]).ThenBy(x => x[1]);
            foreach (var p in sortedPeople)
                res.Insert(p[1], p);

            return res.ToArray();
        }
    }
}
