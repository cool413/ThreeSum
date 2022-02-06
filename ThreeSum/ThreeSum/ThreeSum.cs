using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeSum
{
    public class ThreeSum
    {
        public static IList<IList<int>> GetAnswer(int[] nums)
        {
            var result = new List<IList<int>>();

            if (!IsValid(nums)) { return result; }

            var sortedNums = nums.OrderBy(x => x).ToArray();
            
            for (var i = 0; i < sortedNums.Length - 2; i++)
            {
                var firstIndex = i;
                var secondIndex = i + 1;
                var thirdIndex = sortedNums.Length - 1;

                if (IsSameAsPreviousNum(sortedNums, firstIndex))
                {
                    continue;
                }

                while (secondIndex < thirdIndex)
                {
                    if (secondIndex > firstIndex + 1 &&
                        IsSameAsPreviousNum(sortedNums, secondIndex))
                    {
                        secondIndex++;
                        continue;
                    }

                    var sum = sortedNums[firstIndex] + sortedNums[secondIndex] + sortedNums[thirdIndex];
                    if (sum == 0)
                    {
                        result.Add(new[]
                        {
                            sortedNums[firstIndex],
                            sortedNums[secondIndex],
                            sortedNums[thirdIndex]
                        });

                        secondIndex++;
                        thirdIndex--;
                    }
                    else if (sum < 0)
                    {
                        secondIndex++;
                    }
                    else if (sum > 0)
                    {
                        thirdIndex--;
                    }
                }
            }

            return result;
        }

        private static bool IsSameAsPreviousNum(int[] nums, int index)
        {
            if (index - 1 < 0) { return false; }
            
            return nums[index] == nums[index - 1];
        }

        private static bool IsValid(int[] nums)
        {
            if (nums == null ||
                nums.Length < 3)
            {
                return false;
            }

            return true;
        }
    }
}