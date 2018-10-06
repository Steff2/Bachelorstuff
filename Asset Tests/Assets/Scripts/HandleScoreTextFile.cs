using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class HandleScoreTextFile : MonoBehaviour {

    public static void WriteString()
    {
        string path = "Assets/Scores.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("take " + FeedbackStorage.callCounter);
        writer.WriteLine("danger_Radius " + FeedbackStorage.DangerRadiusTriggered);
        writer.WriteLine("outer_Radius " + FeedbackStorage.LessDangerousRadiusTriggered);
        writer.WriteLine("duration_to_Entrypoint " + FeedbackStorage.DurationToEntry);
        writer.WriteLine("duration_after_Entrypoint " + FeedbackStorage.DurationAfterEntry);
        writer.WriteLine("distance_to_Surface " + FeedbackStorage.DistanceToSurface);
        writer.WriteLine(" ");
        writer.Close();

    }

    static void ReadString()
    {
        string path = "Assets/Scores.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);

        int lineCount = File.ReadAllLines(@"Assets/Scores.txt").Length;
        int SkipLinesCounter = 0;

        string line;
        string text;

        while ((line = reader.ReadLine()) != null)
        {
            if (SkipLinesCounter > (lineCount - 2 * 7))
            {
                continue;
            }

            else
            {
                text = reader.ReadLine();
                string[] splitString = text.Split(new string[] { " " }, StringSplitOptions.None);

                if (splitString[0] == "outer_radius")
                {
                    if(FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {

                    }
                    else
                    {

                    }
                }
                if (splitString[0] == "danger_Radius")
                {
                    if(FeedbackStorage.DangerRadiusTriggered == bool.Parse(splitString[1]))
                    {

                    }
                    else
                    {

                    }
                }
                if (splitString[0] == "duration_to_Entrypoint")
                {
                    if(FeedbackStorage.DurationToEntry < float.Parse(splitString[1]))
                    {

                    }
                    if(FeedbackStorage.DurationToEntry > float.Parse(splitString[1]))
                    {

                    }
                    if (FeedbackStorage.DurationToEntry == float.Parse(splitString[1]))
                    {

                    }
                }
                if (splitString[0] == "duration_after_Entrypoint")
                {
                    if (FeedbackStorage.DurationAfterEntry < float.Parse(splitString[1]))
                    {

                    }
                    if (FeedbackStorage.DurationAfterEntry > float.Parse(splitString[1]))
                    {

                    }
                    if (FeedbackStorage.DurationAfterEntry == float.Parse(splitString[1]))
                    {

                    }
                }
                if (splitString[0] == "distance_to_Surface")
                {
                    if (FeedbackStorage.DistanceToSurface < float.Parse(splitString[1]))
                    {

                    }
                    if (FeedbackStorage.DistanceToSurface > float.Parse(splitString[1]))
                    {

                    }
                    if (FeedbackStorage.DistanceToSurface == float.Parse(splitString[1]))
                    {

                    }
                }
                SkipLinesCounter++;
            }
            reader.Close();
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("b"))
        {
            WriteString();
            ReadString();
        }
    }

}
