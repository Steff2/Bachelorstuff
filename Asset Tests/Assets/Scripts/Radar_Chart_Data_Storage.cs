using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Radar_Chart_Data_Storage {

    private static int abweichung, dauer, nadelspitzenGenauigkeit, abweichung_von_Plan_zu_Risikostrukturen;

    public static int Abweichung
    {
        get
        {
            return abweichung;
        }
        set
        {
            abweichung = value;
        }
    }

    public static int Dauer
    {
        get
        {
            return dauer;
        }
        set
        {
            dauer = value;
        }
    }

    public static int NadelspitzenGenauigkeit
    {
        get
        {
            return nadelspitzenGenauigkeit;
        }
        set
        {
            nadelspitzenGenauigkeit = value;
        }
    }

    public static int Abweichung_von_Plan_zu_Risikostrukturen
    {
        get
        {
            return abweichung_von_Plan_zu_Risikostrukturen;
        }
        set
        {
            abweichung_von_Plan_zu_Risikostrukturen = value;
        }
    }

}
