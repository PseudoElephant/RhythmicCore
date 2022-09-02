using UnityEngine;

public struct DefaultLevelValues
{
    public static int InitialBpm = 120;
    public static TimeSignature InitialTimeSignature = new TimeSignature() {Denominator = 4, Nominator = 4};
    public static string LevelName = "New Level";
    public static string AuthorName = "Author Name";
    public static string LevelDescription = "Level Description";
    public static string SongName = "Song Name";
    public static float SongOffset = 0f;
    public static Color InitialBgColor = new Color(0,0,0);    
}

