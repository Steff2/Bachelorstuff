using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.ComponentModel;

/// <summary>
///saves the variables of the score in this class
/// <summary>
public static class FeedbackStorage{

    public static float durationToEntry, durationAfterEntry, needleAccuracy, distanceToSurface, adjustableSpeed;

    public static float CallCounter = 0;

    public static bool dangerRadiusTriggered, lessDangerousRadiusTriggered, Guiding_Assistance;



    public static bool DangerRadiusTriggered
    {
        get
        {
            return dangerRadiusTriggered;
        }
        set 
            {
            dangerRadiusTriggered = value;
            }
    }

    public static bool guiding_Assistance
    {
        get
        {
            return Guiding_Assistance;
        }
        set
        {
            Guiding_Assistance = value;
        }
    }

    public static bool LessDangerousRadiusTriggered
    {
        get
        {
            return lessDangerousRadiusTriggered;
        }
        set
        {
            lessDangerousRadiusTriggered = value;
        }
    }

    public static float callCounter
    {
        get
        {
            return CallCounter;
        }
        set
        {
            CallCounter = value;
        }
    }

    public static float DurationToEntry
    {
        get
        {
            return durationToEntry;
        }
        set
        {
            durationToEntry = value;
        }
    }

    public static float DurationAfterEntry
    {
        get
        {
            return durationAfterEntry;
        }
        set
        {
            durationAfterEntry = value;
        }
    }

    public static float DistanceToSurface
    {
        get
        {
            return distanceToSurface;
        }
        set
        {
            distanceToSurface = value;
        }
    }

    public static float AdjustableSpeed
    {
        get
        {
            return adjustableSpeed;
        }
        set
        {
            adjustableSpeed = value;
        }
    }
    //Calculates the score with all the variables
    public static float CalculateScore()
    {
        float Score;

        Score = DurationAfterEntry - DistanceToSurface;

        if(LessDangerousRadiusTriggered && !DangerRadiusTriggered)
        {
            Score -= 30;
        }

        if (LessDangerousRadiusTriggered && DangerRadiusTriggered)
        {
            Score -= 60;
        }

        return Score;
    }
}
