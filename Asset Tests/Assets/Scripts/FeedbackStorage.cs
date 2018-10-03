﻿using UnityEngine;

public static class FeedbackStorage{

    public static float entryPrecision, durationToEntry, durationAfterEntry, needleAccuracy, needleAccuracyRiskyStructures;
    public static Vector3 entryPoint1, entryPoint2, entryPoint3, entryPoint4, entryPoint5;

    public static Vector3 tumorPoint;

    public static float EntryPrecision
    {
        get
        {
            return entryPrecision;
        }
        set 
            {
            entryPrecision = value;
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

    public static float NeedleAccuracy
    {
        get
        {
            return needleAccuracy;
        }
        set
        {
            needleAccuracy = value;
        }
    }

    public static float NeedleAccuracyRiskyStructures
    {
        get
        {
            return needleAccuracyRiskyStructures;
        }
        set
        {
            needleAccuracyRiskyStructures = value;
        }
    }

    public static Vector3 EntryPoints
    {
        get
        {
            return entryPoint1;
        }
    }

    public static Vector3 TumorPoint
    {
        get
        {
            return tumorPoint;
        }
    }

}
