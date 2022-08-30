using System;
using UnityEngine;

/// <summary>
/// Class in charge of handling the <see cref="LevelConfig"/> data section of the <see cref="Level"/> class.
/// <b>Note: this class is intended to only be used through <see cref="LevelController"/>.</b>
/// </summary>
public class LevelControllerConfig
{
    private LevelConfig _levelConfig;
    
    private const int _maxLevelNameStringLength = 30;
    private const int _maxAuthorNameStringLength = 20;
    private const int _maxSongNameStringLength = 30;
    private const int _maxLevelDescriptionStringLength = 120;
    
    private const string _invalidBpmError = "The bpm you entered is not valid.";
    private const string _invalidSongOffset = "The song offset provided is not valid.";
    private const string _invalidTimeSignature = "The time signature provided is invalid.";

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
    /// Changes the level name to the given value. If a string exceeds the max length it will be cropped.
    /// </summary>
    /// <param name="levelName">the new level name.</param>
    public void SetLevelName(string levelName)
    {
        if (levelName.Length > _maxLevelNameStringLength)
        {
            levelName = levelName.Substring(0, _maxLevelNameStringLength);
        }
        
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
    /// Changes the level author to the given value. If a string exceeds the max length it will be cropped.
    /// </summary>
    /// <param name="authorName">the new author's name.</param>
    public void SetLevelAuthor(string authorName)
    {
        if (authorName.Length > _maxAuthorNameStringLength)
        {
            authorName = authorName.Substring(0, _maxAuthorNameStringLength);
        }
        _levelConfig.AuthorName = authorName;
    }

    /// <summary>
    /// Returns the current level description.
    /// </summary>
    /// <returns>A string representing the current level description.</returns>
    public string GetLevelDescription()
    {
        return _levelConfig.LevelDescription;
    }

    /// <summary>
    /// Sets the level description to the provided string. If a string exceeds the max length it will be cropped.
    /// </summary>
    /// <param name="levelDescription">A string representing the level description.</param>
    public void SetLevelDescription(string levelDescription)
    {
        if (levelDescription.Length > _maxLevelDescriptionStringLength)
        {
            levelDescription = levelDescription.Substring(0, _maxLevelDescriptionStringLength);
        }

        _levelConfig.LevelDescription = levelDescription;
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
    /// Changes the song's name to the given value. If a string exceeds the max length it will be cropped.
    /// </summary>
    /// <param name="songName">the new son's name.</param>
    public void SetSongName(string songName)
    {
        if (songName.Length > _maxSongNameStringLength)
        {
            songName = songName.Substring(0, _maxSongNameStringLength);
        }
        
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
        if (bpm <= 0) throw new Exception(_invalidBpmError);
        
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
        if (offset < 0) throw new Exception(_invalidSongOffset);
        
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
        if (timeSignature.Nominator <= 0 || timeSignature.Denominator <= 0) throw new Exception(_invalidTimeSignature);
        
        _levelConfig.InitialTimeSignature = timeSignature;
    }

    /// <summary>
    /// Returns the hex representation of the initial background color.
    /// </summary>
    /// <returns>A string representing the hex representation of the background color. (e.x. "#A72B27")</returns>
    public Color GetInitialBgColor()
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
    public void SetInitialBgColor(Color color)
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
