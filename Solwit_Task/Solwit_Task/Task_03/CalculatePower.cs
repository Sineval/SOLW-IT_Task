using System;
using System.Diagnostics;

namespace Solwit_Task.Task_03
{
    public class CalculatePower
    {
        Stopwatch timer = new Stopwatch();
        double result;

        public double CalculateRecursive(double theBase, double theExponent)
        {
            timer.Start();
            result = 1;

            if(theExponent == 0)
            {
                timer.Stop();
                return result;
            }
            else if(theExponent == 1)
            {
                timer.Stop();
                return theBase;
            }
            else
            {
                timer.Stop();
                return theBase * CalculateRecursive(theBase, theExponent - 1);
            }
        }

        public double CalculateIterative(double theBase, double theExponent)
        {
            timer.Start();
            result = 1;

            if (theExponent == 0)
            {
                timer.Stop();
                return result;
            }
            else if (theExponent == 1)
            {
                timer.Stop();
                return theBase;
            }
            else
            {
                for(int i = 0; i < theExponent; i++)
                {
                    result = result * theBase; 
                }
                timer.Stop();
                return result;
            }
        }

        public double CalculateSmartly(double theBase, double theExponent)
        {
            result = 1;
            timer.Start();
            result = Math.Pow(theBase, theExponent);
            timer.Stop();

            return result;
        }

        public long GetTime()
        {
            return timer.ElapsedMilliseconds;
        }
    }
}
