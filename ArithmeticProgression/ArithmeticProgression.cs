using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticProgression
{
    public class ArithmeticProgression
    {
        public int[] FindTheMissing(int[] progression)
        {
            if (progression.Length < 3) throw new ArithmeticProgressionTooSmallException();

            int progressionIncrement = GetProgressionIncrement(progression);

            if (progressionIncrement == 0) return new int[] { };

            List<int> cleanProgression = GetCleanProgression(progression[0],
                                                             progression[progression.Length - 1],
                                                             progressionIncrement);

            return cleanProgression.Except(progression).ToArray();
        }

        private int GetProgressionIncrement(int[] progression)
        {
            int progressionIncrement = progression[1] - progression[0];

            for(int i = 2; i < progression.Length; i++)
            {
                int differenceToPreviousNum = progression[i] - progression[i - 1];

                if (Math.Abs(differenceToPreviousNum) < Math.Abs(progressionIncrement)) progressionIncrement = differenceToPreviousNum;
            }

            return progressionIncrement;
        }

        private List<int> GetCleanProgression(int startValue, int endValue, int increment)
        {
            return Enumerable.Range(0, (endValue - startValue) / increment + 1)
                                .Select(x => startValue + x * increment)
                                .ToList();
        }
    }
}
