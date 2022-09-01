using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSums__Medium_
{
    public static  class Asteroid_Collision__735_
    {
		public static int[] AsteriodCollision(int[] asteroid)
		{
			Stack<int> steck = new Stack<int>();
			foreach(var ass in asteroid)
            {
                bool isAlive = true;
                while (steck.Count > 0 && steck.Peek() > 0 && ass < 0)
                {
                    
                    if (steck.Peek() == ass*-1)
                    {
                        steck.Pop();
                        isAlive = false;
                        break;
                    }
                    else if (steck.Peek()< ass*-1)
                    {
                        steck.Pop();
                        isAlive = true;
                        continue;
                    }
                    else if (steck.Peek()>ass*-1)
                    {
                        isAlive = false;
                        break;
                    }
				
                }
                if (isAlive || ass > 0) steck.Push(ass);
            }
            List<int> result = new List<int>();
            while (steck.Count > 0)
            {
                result.Insert(0, steck.Pop());
            }
            return result.ToArray();
		}

        public static int[] OptAsteroidCollision(int[] asteroids)
        {
            Stack<int> st = new Stack<int>();
            foreach (int asteroid in asteroids)
            {
                bool isExploded = false;
                while (st.Count > 0 && asteroid < 0 && st.Peek() > 0)
                {
                    int top = st.Peek();
                    if (top < -asteroid)
                    {
                        st.Pop();
                    }
                    else
                    {
                        isExploded = true;
                        if (top == -asteroid)
                        {
                            st.Pop();
                        }
                        break;
                    }
                }
                if (!isExploded)
                    st.Push(asteroid);
            }
            List<int> result = new List<int>();
            while (st.Count > 0)
            {
                result.Insert(0, st.Pop());
            }
            return result.ToArray();
        }
    }
}
