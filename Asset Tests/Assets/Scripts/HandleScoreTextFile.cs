using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

/// <summary>
/// Handles the visualization of the score and the comparison
/// <summary>
public class HandleScoreTextFile : MonoBehaviour {

    public Text ScoreText;
    public GameObject ScoreTextObject;

    public static void WriteString(Text ScoreText, GameObject ScoreTextObject)
    {
        ScoreTextObject.GetComponent<Text>().enabled = true;
        string path = "Assets/Scores.txt";

        //Writes text to a score file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("take " + FeedbackStorage.callCounter);
        writer.WriteLine("outer_Radius " + FeedbackStorage.LessDangerousRadiusTriggered);
        writer.WriteLine("danger_Radius " + FeedbackStorage.DangerRadiusTriggered);

        //Writes the scores into the Text object while writing into file
        if(FeedbackStorage.DangerRadiusTriggered)
        {
            ScoreText.text = "You came too close to risky structures" + "\n";
        }

        if (!FeedbackStorage.DangerRadiusTriggered && FeedbackStorage.LessDangerousRadiusTriggered)
        {
            ScoreText.text = "You managed to avoid danger radius but still got too close" + "\n";
        }

        if (!FeedbackStorage.DangerRadiusTriggered && !FeedbackStorage.LessDangerousRadiusTriggered)
        {
            ScoreText.text = "You managed to avoid any risky structures" + "\n";
        }

        writer.WriteLine("duration_to_Entrypoint " + FeedbackStorage.DurationToEntry);

        ScoreText.text += "Your time until the needle entered the skin: " + FeedbackStorage.DurationToEntry + "s" + "\n";

        writer.WriteLine("duration_after_Entrypoint " + FeedbackStorage.DurationAfterEntry);

        ScoreText.text += "Your time until the seed was placed: " + FeedbackStorage.DurationAfterEntry + "s" + "\n";

        writer.WriteLine("distance_to_Surface " + FeedbackStorage.DistanceToSurface);

        ScoreText.text += "The Distance from Surface to end position is: " + FeedbackStorage.DistanceToSurface + "\n";

        writer.Close();

    }

    static void ReadString(Text ScoreText)
    {
        string path = "Assets/Scores.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);

        int lineCount = File.ReadAllLines(@"Assets/Scores.txt").Length;
        int takeCounter = 0;
        int LineStopper = 0;

        string line;
        //Reads the lines out of the score files, every 8th line is a new set of value for a new round played
        while ((line = reader.ReadLine()) != null)
        {
            Debug.Log("Line says: " + line);
            if (line == "take 0")
            {
                takeCounter++;
            }
            //since this compares the current entry values with the ones from the round before
            //skip while there is less than two rounds played (14 lines)
            Debug.Log("TakeCounter: " + takeCounter);
            Debug.Log("lineCount / 6 - 1: " + (lineCount / 6 - 1));
            if (lineCount / 6 < 2)
            {
                continue;
            }

            else if (takeCounter == lineCount / 6 - 1)
            {
                //split the name/value pair
                Debug.Log("Actual line: " + line);
                string[] splitString = line.Split(new string[] { " " }, StringSplitOptions.None);

                Debug.Log("String[0]: " + splitString[0]);
                if (splitString[0] == "outer_Radius")
                {
                    Debug.Log(bool.Parse(splitString[1]));
                    Debug.Log(FeedbackStorage.LessDangerousRadiusTriggered);
                    if (FeedbackStorage.LessDangerousRadiusTriggered == true && FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Again too close to risky structures (30)" + "\n";
                    }

                    if (FeedbackStorage.LessDangerousRadiusTriggered == false && FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Managed to avoid risky structures again (30)" + "\n";
                    }

                    if (FeedbackStorage.LessDangerousRadiusTriggered == true && !FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Too close to risky structures this time (30)" + "\n";
                    }

                    if (FeedbackStorage.LessDangerousRadiusTriggered == false && !FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Managed to avoid risky structures (30)" + "\n";
                    }
                }
                if (splitString[0] == "danger_Radius")
                {
                    if (FeedbackStorage.DangerRadiusTriggered == true && FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Again way too close to risky structures (15)" + "\n";
                    }

                    if (FeedbackStorage.DangerRadiusTriggered == false && FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Managed to avoid very risky structures again (15)" + "\n";
                    }

                    if (FeedbackStorage.DangerRadiusTriggered == true && !FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Way too close to risky structures this time (15)" + "\n";
                    }

                    if (FeedbackStorage.DangerRadiusTriggered == false && !FeedbackStorage.LessDangerousRadiusTriggered == bool.Parse(splitString[1]))
                    {
                        ScoreText.text += "Managed to avoid very risky structures (15)" + "\n";
                    }
                }
                if (splitString[0] == "duration_to_Entrypoint")
                {
                    if (FeedbackStorage.DurationToEntry < float.Parse(splitString[1]))
                    {
                        ScoreText.text += "In your last attempt your time before entering was: " + splitString[1] + "s" + "\n";
                    }
                    if (FeedbackStorage.DurationToEntry > float.Parse(splitString[1]))
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
                        ScoreText.text += "In your last attempt your time after entering was: " + splitString[1] + "s" + "\n";
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
                        ScoreText.text += "In your last attempt your needles distance to the surface was: " + splitString[1] + "\n";
                    }
                    if (FeedbackStorage.DistanceToSurface > float.Parse(splitString[1]))
                    {

                    }
                    if (FeedbackStorage.DistanceToSurface == float.Parse(splitString[1]))
                    {

                    }
                }
                LineStopper++;
            }
        }
        reader.Close();
    }

    void Start()
    {
        ScoreTextObject.GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyUp("b"))
        {
            WriteString(ScoreText, ScoreTextObject);
            ReadString(ScoreText);
        }
    }

}
