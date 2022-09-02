using System;
using System.Collections.Generic;

/// <summary>
/// Class in charge of handling the data of <see cref="Level"/>.
/// </summary>
public class LevelController
{
    private Level _level;
    public LevelControllerConfig Config;
    public LevelControllerData Data;

    /// <summary>
    /// Basic constructor for <see cref="LevelController"/>.
    /// Creates a new empty <see cref="Level"/> and inits <see cref="LevelControllerConfig"/> and <see cref="LevelControllerData"/> with the appropriate data.
    /// </summary>
    public LevelController()
    {
        //TODO: Think about how to init data?
        InitEmptyLevel();
        
        Config = new LevelControllerConfig(_level.LevelConfig);
        Data = new LevelControllerData(_level.LevelData);
    }

    /// <summary>
    /// Creates a new empty <see cref="Level"/>. Initializes all aspect of <see cref="LevelData"/> so that nothing points to null, but they are all empty.
    /// </summary>
    private void InitEmptyLevel()
    {
        _level = new Level();

        _level.LevelConfig = new LevelConfig();
        _level.LevelData = new LevelData();
        
        // Set Up Level Config
        SetDefaultConfigSetUp(_level.LevelConfig);

        // Set Up Level Data
        SetDefaultLevelDataSetUp(_level.LevelData);
    }

    /// <summary>
    /// Loads a single empty measure into Level Data. Will remove <i>all</i> previous existing data.
    /// </summary>
    /// <param name="levelData"><see cref="LevelData"/> to which to load the default level set up.</param>
    private void SetDefaultLevelDataSetUp(LevelData levelData)
    {
        // Init List
        levelData.Measures = new List<Measure>();

        // Empty measure to add
        Measure newMeasure = new Measure();
        newMeasure.Triggers = new Dictionary<int, List<Trigger>>();
        newMeasure.RhythmicValues = new Dictionary<int, RhythmicValue>();
        newMeasure.TimeSignature = DefaultLevelValues.InitialTimeSignature;
        
        // Add Measure
        levelData.Measures.Add(newMeasure);
    }

    /// <summary>
    /// Loads the default level config into <see cref="LevelConfig"/>. It will remove <i>all</i> previous existing data.
    /// </summary>
    /// <param name="config"><see cref="LevelConfig"/> to which to load the default config set up.</param>
    private void SetDefaultConfigSetUp(LevelConfig config)
    {
        config.InitialBpm = DefaultLevelValues.InitialBpm;
        config.InitialTimeSignature = DefaultLevelValues.InitialTimeSignature;
        config.LevelName = DefaultLevelValues.LevelName;
        config.AuthorName = DefaultLevelValues.AuthorName;
        config.SongName = DefaultLevelValues.SongName;
        config.SongOffset = DefaultLevelValues.SongOffset;
        config.InitialBgColor = DefaultLevelValues.InitialBgColor;
        config.LevelDescription = DefaultLevelValues.LevelDescription;
    }
}