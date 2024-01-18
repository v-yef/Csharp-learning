using System;

namespace Task_1
{
    public static class ArrayExtension
    {
        public static float Product(this float[]? array)
        {
            if (array is null)
            {
                return float.NaN;
            }

            float product = 1.0f;

            foreach (var item in array)
            {
                if (float.IsNormal(item))
                {
                    product *= item;
                }
                else
                {
                    product = float.NaN;
                    break;
                }
            }

            return product;
        }

        public static float EvenIndexSum(this float[]? array)
        {
            if (array is null)
            {
                return float.NaN;
            }

            float sum = 0.0f;

            for (int i = 0; i < array.Length; i += 2)
            {
                if (float.IsNormal(array[i]))
                {
                    sum += array[i];
                }
                else
                {
                    sum = float.NaN;
                    break;
                }
            }

            return sum;
        }

        public static float MaxTwoDim(this float[,]? array)
        {
            if (array is null)
            {
                return float.NaN;
            }

            float maxNum = array[0, 0];

            foreach (var num in array)
            {
                if ((float.IsNormal(num)) && (num.CompareTo(maxNum) > 0))
                {
                    maxNum = num;
                }
            }

            return maxNum;
        }

        public static float MinTwoDim(this float[,]? array)
        {
            if (array is null)
            {
                return float.NaN;
            }

            float maxNum = array[0, 0];

            foreach (var num in array)
            {
                if ((float.IsNormal(num)) && (num.CompareTo(maxNum) < 0))
                {
                    maxNum = num;
                }
            }

            return maxNum;
        }

        public static float SumTwoDim(this float[,]? array)
        {
            if (array is null)
            {
                return float.NaN;
            }

            float sum = 0.0f;

            foreach (var item in array)
            {
                if (float.IsNormal(item))
                {
                    sum += item;
                }
                else
                {
                    sum = float.NaN;
                    break;
                }
            }

            return sum;
        }

        public static float ProductTwoDim(this float[,]? array)
        {
            if (array is null)
            {
                return float.NaN;
            }

            float product = 1.0f;

            foreach (var item in array)
            {
                if (float.IsNormal(item))
                {
                    product *= item;
                }
                else
                {
                    product = float.NaN;
                    break;
                }
            }

            return product;
        }

        public static float OddColumnSum(this float[,]? array)
        {
            if (array is null)
            {
                return float.NaN;
            }

            float sum = 0.0f;
            int firstDimLen = array.GetLength(0);
            int secondDimLen = array.GetLength(1);

            for (int i = 0; i < firstDimLen; i++)
            {
                // Odd columns begin from index 1.
                for (int j = 1; j < secondDimLen; j += 2)
                {
                    if (float.IsNormal(array[i, j]))
                    {
                        sum += array[i, j];
                    }
                    else
                    {
                        sum = float.NaN;
                        break;
                    }
                }
            }

            return sum;
        }
    }
}
