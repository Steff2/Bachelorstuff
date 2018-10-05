using UnityEngine;
using UnityEditor;
using System.IO;

public class HandleScoreTextFile : MonoBehaviour {

    public static void WriteString()
    {
        string path = "Assets/Scores.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Take" + FeedbackStorage.callCounter);
        writer.WriteLine("Danger Radius = " + FeedbackStorage.DangerRadiusTriggered);
        writer.WriteLine("Outer Radius = " + FeedbackStorage.LessDangerousRadiusTriggered);
        writer.WriteLine("Duration to Entrypoint = " + FeedbackStorage.DurationToEntry);
        writer.WriteLine("Duration after Entrypoint = " + FeedbackStorage.DurationAfterEntry);
        writer.WriteLine("Distance to Surface = " + FeedbackStorage.DistanceToSurface);
        writer.WriteLine(" ");
        writer.Close();

    }

    static void ReadString()
    {
        string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    void Update()
    {
        if (Input.GetKeyUp("b"))
        {
            WriteString();
        }
    }

}
