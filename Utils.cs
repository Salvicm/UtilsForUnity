using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Utils
{

    /// <summary>
    /// Get angle from a vector
    /// </summary>
    /// <param Vector X="_x"></param>
    /// <param Vector Y="_y"></param>
    /// <param Default value="_t"></param>
    ///      90º
    /// 180º    0º
    ///     270º
    /// <returns>Angle</returns>
    static public float GetAngle(float _x, float _y, float _t)
    {
        float x = _x;
        float y = _y;
        if (x == 0 && y == 0)
            return _t;
        else if (x == 0 && y != 0)
            if (y > 0)
                return 90.0f;
            else
                return -90.0f;
        else if(x != 0 && y == 0)
            if (x > 0)
                return 0f;
            else
                return 180f;
        else
            return Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    }
    /// <summary>
    /// Gets a number and returns nearest multiple of param
    /// </summary>
    /// <param Integer="_num"></param>
    /// <returns> closest divisor of param </returns>
    static public int CorrectAngle(float angle, int numberToMod)
    {
        float tmpNum = angle % numberToMod; 
        if (tmpNum < numberToMod /2) 
        {
            return (int)(angle - tmpNum); 
        }
        else
        {
            return (int)(angle - tmpNum) + numberToMod;
        }
    }
   
    static public float CorrectAnglePosition(float currentAngle, float newAngle, float speedMultiplier)
    {
        float auxAngle = newAngle;
        if (auxAngle > 360)
            auxAngle = auxAngle % 360;
        if (auxAngle < -360)
            auxAngle = auxAngle % -360;
        float difference = auxAngle - currentAngle;
        /*
         * if difference > pi(180 in this case)
         * Dif between angles must change sign
         * Examples:
         * ********************************************
         * If we use 175 and -175
         * 175 - -175= 350
         * Enter first IF
         * 350 - 360 = 10;
         * Difference is clockwise
         * ********************************************
         * */

        if (difference >= 180)
        {
            difference -= 360;
        }
        else if (difference <= -180)
        {
            difference += 360;
        }

        if (difference > 160)
        {
            float tmp = speedMultiplier * 2;
            if (tmp > 1)
                tmp = 1;
            return (currentAngle + (difference) * tmp);

        }
        else if (difference <= 3 && difference >= -3)
        {
            return auxAngle;
        }
        else
        {
            return (currentAngle + (difference) * speedMultiplier);
        }
    }

    /// <summary>
    /// Get a number between to values
    /// </summary>
    /// <param name="val"> Value to map </param>
    /// <param name="srcMin"> Source minimum </param>
    /// <param name="srcMax"> Source maximum </param>
    /// <param name="dstMin"> Destiny minimum </param>
    /// <param name="dstMax"> Destiny Maximum </param>
    /// <returns> Value mapped from one range to another</returns>
    static public float MapInterval(float val, float srcMin, float srcMax, float dstMin, float dstMax)
    {
        if (val >= srcMax) return dstMax;
        if (val <= srcMin) return dstMin;
        return dstMin + (val - srcMin) / (srcMax - srcMin) * (dstMax - dstMin);
    }
}
