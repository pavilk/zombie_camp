using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public static bool introSeen = false;
    public static List<string> Triggers = new List<string>();
    public static bool HadLastPaper = false;
    public static Vector3 SpawnPosition = new Vector3(0, 0, 0);
}
