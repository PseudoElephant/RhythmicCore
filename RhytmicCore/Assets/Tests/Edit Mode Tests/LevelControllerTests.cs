using NUnit.Framework;

public class LevelControllerTests
{
    private LevelController _levelControllerControl;

    [SetUp]
    public void LevelDataSetup()
    {
        _levelControllerControl = new LevelController();
    }

    [Test]
    public void InitEmptyLevelTest()
    {
        Assert.NotNull(_levelControllerControl.Config);
        Assert.NotNull(_levelControllerControl.Data);

        Assert.AreEqual(DefaultLevelValues.InitialBpm, _levelControllerControl.Config.GetInitialBpm());
        Assert.AreEqual(DefaultLevelValues.InitialTimeSignature, _levelControllerControl.Config.GetInitialTimeSignature());
        Assert.AreEqual(DefaultLevelValues.SongOffset, _levelControllerControl.Config.GetSongOffset());
        Assert.AreEqual(DefaultLevelValues.InitialBgColor,_levelControllerControl.Config.GetInitialBgColor());
        Assert.AreEqual(DefaultLevelValues.SongName,_levelControllerControl.Config.GetSongName());
        Assert.AreEqual(DefaultLevelValues.LevelName,_levelControllerControl.Config.GetLevelName());
        Assert.AreEqual(DefaultLevelValues.AuthorName,_levelControllerControl.Config.GetLevelAuthor());
        Assert.AreEqual(DefaultLevelValues.LevelDescription, _levelControllerControl.Config.GetLevelDescription());
        
        Assert.AreEqual(1, _levelControllerControl.Data.GetMeasures().Length);
    
        Measure measure = _levelControllerControl.Data.GetMeasures()[0];
        Assert.AreEqual(0, measure.Triggers.Count);
        Assert.AreEqual(0, measure.RhythmicValues.Count);
        Assert.AreEqual(DefaultLevelValues.InitialTimeSignature, measure.TimeSignature);
    }
}
