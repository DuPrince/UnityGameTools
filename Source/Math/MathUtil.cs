﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Util
{
    /// <summary>
    /// Additional math helper functions beyond what Unity provides.
    /// </summary>
    public class MathUtil
    {
        /// <summary>
        /// Snaps the given value to the nearest lower multiple of the step value.
        /// For example, given step of 5, values in [0, 5) will snap to 0; 
        /// values in [5, 10) will snap to 5, values in [-5, 0) will snap to -5, etc.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static float SnapDown (float value, float step) {
            return Mathf.Floor(value / step) * step;
        }

        /// <summary>
        /// Snaps the given value to the nearest lower multiple of the step value.
        /// For example, given step of 5, integer values in [0, 4] will snap to 0; 
        /// values in [5, 9] will snap to 5, values in [-5, -1] will snap to -5, etc.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static int SnapDown (int value, int step) {
            return Mathf.FloorToInt((float)value / step) * step;
        }

        /// <summary>
        /// Snaps the given value to the nearest higher multiple of the step value.
        /// For example, given step of 5, values in (0, 5] will snap to 5; 
        /// values in (5, 10] will snap to 10, values in (-5, 0] will snap to 0, etc.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static float SnapUp (float value, float step) {
            return Mathf.Ceil(value / step) * step;
        }

        /// <summary>
        /// Snaps the given value to the nearest lower multiple of the step value.
        /// For example, given step of 5, integer values in [1, 5] will snap to 5; 
        /// values in [6, 10] will snap to 10, values in [-4, 0] will snap to 0, etc.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static int SnapUp (int value, int step) {
            return Mathf.CeilToInt((float)value / step) * step;
        }

        /// <summary>
        /// Snaps the given value to the nearest higher multiple of the step value.
        /// For example, given step of 5, values in [2.5, 7.5) will snap to 5; 
        /// values in [7.5, 12.5) will snap to 10, etc.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static float SnapTo (float value, float step) {
            return Mathf.Round(value / step) * step;
        }

        /// <summary>
        /// Snaps the given value to the nearest multiple of the step value.
        /// For example, given step of 5, integer values in [1, 2] will snap to 0; 
        /// values in [3, 7] will snap to 5, etc.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static int SnapTo (int value, int step) {
            return Mathf.RoundToInt((float)value / step) * step;
        }

        /// <summary>
        /// Clamps the value to be within the range [min, max]
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Clamp (float value, float min, float max) {
            if (value < min) { return min; }
            if (value > max) { return max; }
            return value;
        }

        /// <summary>
        /// Clamps the value to be within the range [min, max]
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Clamp (int value, int min, int max) {
            if (value < min) { return min; }
            if (value > max) { return max; }
            return value;
        }

        /// <summary>
        /// Interpolates between two values. If p = 0, returns min,
        /// if p = 1, returns max, otherwise returns lerp of both.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Interpolate (float p, float min, float max) {
            return (1 - p) * min + p * max;
        }

        /// <summary>
        /// Finds position of q between two values a and b - an inverse of interpolation. 
        /// If q = min returns 0, if q = max, returns 1, otherwise returns a value proportional to 
		/// q's position between them. Throws a division by zero error if min = max.
        /// </summary>
        /// <param name="q"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Uninterpolate (float q, float min, float max) {
            return (q - min) / (max - min);
        }

        /// <summary>
        /// Converts a value from the range [amin, amax] to the range [bmin, bmax].
        /// Equivalent to uninterpolating in [amin, amax] and then re-interpoloating between [bmin, bmax].
        /// Throws a division by zero error if amin == amax.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="amin"></param>
        /// <param name="amax"></param>
        /// <param name="bmin"></param>
        /// <param name="bmax"></param>
        /// <returns></returns>
        public static float ConvertRange (float value, float amin, float amax, float bmin, float bmax) {
            float p = Uninterpolate(value, amin, amax);
            return Interpolate(p, bmin, bmax);
        }

        /// <summary>
        /// Modulus function, in in C# the % operator is not mod, it's actually a remainder, and can be negative.
        /// For example, Modulus(1, 3) == 1 and 1 % 3 == 1, but Modulus(-1, 3) == 2, while -1 % 3 == -1.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Modulus (float a, float b) {
            float r = a % b;
            return (r < 0) ? r + b : r;
        }

        /// <summary>
        /// Modulus function, in in C# the % operator is not mod, it's actually a remainder, and can be negative.
        /// For example, Modulus(1, 3) == 1 and 1 % 3 == 1, but Modulus(-1, 3) == 2, while -1 % 3 == -1.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Modulus (int a, int b) {
            int r = a % b;
            return (r < 0) ? r + b : r;
        }

        /// <summary>
        /// Given ranges of given size starting at 0, counts how many times the range boundary was crossed in the 
        /// interval between from and to. For example, given period of 5, the ranges would be [0, 5), [5, 10), [10, 15), etc.
        /// So if we take 1 as our from value, from 1 to 4 there are zero crossings, from 1 to 7 there is one (at 5), 
        /// from 1 to 13 there are two (at 5 and 10), and so on.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static int CountIntervals (int from, int to, int period) {
            int first = (int) Math.Floor((double)from / period);
            int last = (int) Math.Floor((double)to / period);
            return last - first;
        }

        /// <summary>
        /// Given ranges of given size starting at 0, counts how many times the range boundary was crossed in the 
        /// interval between from and to. For example, given period of 5, the ranges would be [0, 5), [5, 10), [10, 15), etc.
        /// So if we take 1 as our from value, from 1 to 4.999 there are zero crossings, from 1 to 5 there is one (at 5), 
        /// from 1 to 13 there are two (at 5 and 10), and so on.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static int CountIntervals (float from, float to, float period) {
            int first = (int)Math.Floor((double)from / period);
            int last = (int)Math.Floor((double)to / period);
            return last - first;
        }

        /// <summary>
        /// Returns true if the given time is inside the half-open interval [from, to), 
        /// accounting for 24-hour wrapping. For example, if from = 17 and to = 2 
        /// (so between 5pm and 2am), time = 1 is inside the interval, but 2 or 3 is not; 
        /// 16 is not inside the interval, but 17 and 18 are.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool InsideDailyInterval (float time, float from, float to) {

            bool sameday = (from < to);
            time = (time < 24) ? time : (time % 24);

            return sameday ?
                (from <= time && time < to) :
                (from <= time || time < to);
        }


        public static bool IsEven (int value) { return (value & 1) == 0; }
        public static bool IsEven (uint value) { return (value & 1) == 0; }
        public static bool IsEven (float value) { return ((int)value & 1) == 0; }

        public static bool IsOdd (int value) { return (value & 1) == 1; }
        public static bool IsOdd (uint value) { return (value & 1) == 1; }
        public static bool IsOdd (float value) { return ((int)value & 1) == 1; }
    }
}
