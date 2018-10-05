using UnityEngine;

public static class FeedbackStorage{

    public static float durationToEntry, durationAfterEntry, needleAccuracy, needleAccuracyRiskyStructures, distanceToSurface;

    public static bool dangerRadiusTriggered, lessDangerousRadiusTriggered;

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
