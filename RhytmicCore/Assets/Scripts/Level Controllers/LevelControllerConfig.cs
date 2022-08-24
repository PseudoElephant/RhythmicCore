/// <summary>
/// Class in charge of handling the <see cref="LevelConfig"/> data section of the <see cref="Level"/> class.
/// <b>Note: this class is intended to only be used through <see cref="LevelController"/>.</b>
/// </summary>
public class LevelControllerConfig
{
    private LevelConfig _levelConfig;

    /// <summary>
    /// Initializes <see cref="LevelControllerConfig"/> with the current <see cref="LevelConfig"/> data.
    /// </summary>
    /// <param name="levelConfig">The current <see cref="LevelConfig"/> of the level.</param>
    public LevelControllerConfig(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;
    }

    #region Methods
    
    /// <summary>
    /// Returns the current level name.
    /// </summary>
    /// <returns>A string representing the level's name.</returns>
    public string GetLevelName()
    {
        return _levelConfig.LevelName;
    }

    /// <summary>
    /// Changes the level name to the given value.
    /// </summary>
    /// <param name="levelName">the new level name.</param>
    public void SetLevelName(string levelName)
    {
        _levelConfig.LevelName = levelName;
    }

    /// <summary>
    /// Returns the level author.
    /// </summary>
    /// <returns>A string representing the author's name.</returns>
    public string GetLevelAuthor()
    {
        return _levelConfig.AuthorName;
    }

    /// <summary>
    /// Changes the level author to the given value.
    /// </summary>
    /// <param name="authorName">the new author's name.</param>
    public void SetLevelAuthor(string authorName)
    {
        _levelConfig.AuthorName = authorName;
    }

    /// <summary>
    /// Returns the song's name.
    /// </summary>
    /// <returns>A string representing the name of the song.</returns>
    public string GetSongName()
    {
        return _levelConfig.SongName;
    }

    /// <summary>
    /// Changes the song's name to the given value.
    /// </summary>
    /// <param name="songName">the new son's name.</param>
    public void SetSongName(string songName)
    {
        _levelConfig.SongName = songName;
    }

    /// <summary>
    /// Returns the initial level's bpm.
    /// </summary>
    /// <returns>An int representing the initial bpm of the level.</returns>
    public int GetInitialBpm()
    {
        return _levelConfig.InitialBpm;
    }

    /// <summary>
    /// Changes the initial bpm of the level.
    /// </summary>
    /// <param name="bpm">the new bpm of the level.</param>
    public void SetInitialBpm(int bpm)
    {
        _levelConfig.InitialBpm = bpm;
    }

    /// <summary>
    /// Returns the amount of seconds the song is offset by. 
    /// </summary>
    /// <returns>A float representing the seconds of offset.</returns>
    public float GetSongOffset()
    {
        return _levelConfig.SongOffset;
    }

    /// <summary>
    /// Changes the amount of seconds the song is offset by. 
    /// </summary>
    /// <param name="offset">the new offset amount, in seconds.</param>
    public void SetSongOffset(float offset)
    {
        _levelConfig.SongOffset = offset;
    }

    /// <summary>
    /// Returns the initial time signature of the level.
    /// </summary>
    /// <returns>The <see cref="TimeSignature"/> of the level.</returns>
    public TimeSignature GetInitialTimeSignature()
    {
        return _levelConfig.InitialTimeSignature;
    }

    /// <summary>
    /// Changes the initial <see cref="TimeSignature"/> of the level.
    /// </summary>
    /// <param name="timeSignature">the new initial <see cref="TimeSignature"/> of the level.</param>
    public void SetInitialTimeSignature(TimeSignature timeSignature)
    {
        _levelConfig.InitialTimeSignature = timeSignature;
    }

    /// <summary>
    /// Returns the hex representation of the initial background color.
    /// </summary>
    /// <returns>A string representing the hex representation of the background color. (e.x. "#A72B27")</returns>
    public string GetInitialBgColor()
    {
        return _levelConfig.InitialBgColor;
    }

    /// <summary>
    /// Changes the initial background color.
    /// </summary>
    /// <example>
    /// For example:
    /// <code>LevelController.Data.SetInitialBgColor("#FFFFFF");</code>
    /// This sets the initial background color to white.
    /// </example>
    /// <param name="color">A string of the hex representation of a color.</param>
    public void SetInitialBgColor(string color)
    {
        _levelConfig.InitialBgColor = color;
    }

    /// <summary>
    /// Returns the entire <see cref="LevelConfig"/> object.
    /// </summary>
    /// <returns>The current <see cref="LevelConfig"/> for the level.</returns>
    public LevelConfig GetLevelConfig()
    {
        return _levelConfig;
    }
    
    #endregion
}
