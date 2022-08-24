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
        throw new NotImplementedException();
    }
}