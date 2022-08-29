using System;
using NUnit.Framework;

public class LevelControllerConfigTests
{
    private LevelController _levelControllerControl;

    [SetUp]
    public void LevelDataSetup()
    {
        _levelControllerControl = new LevelController();
    }

    [Test]
    public void LevelNameTests()
    {
        Assert.AreEqual(DefaultLevelValues.LevelName, _levelControllerControl.Config.GetLevelName());
        _levelControllerControl.Config.SetLevelName("Hellaven");
        Assert.AreEqual("Hellaven", _levelControllerControl.Config.GetLevelName());
    }

    [Test]
    public void LevelAuthorTests()
    {
        Assert.AreEqual(DefaultLevelValues.AuthorName, _levelControllerControl.Config.GetLevelAuthor());
        _levelControllerControl.Config.SetLevelAuthor("Clasi");
        Assert.AreEqual("Clasi", _levelControllerControl.Config.GetLevelAuthor());
    }

    [Test]
    public void SongNameTests()
    {
        Assert.AreEqual(DefaultLevelValues.SongName, _levelControllerControl.Config.GetSongName());
        _levelControllerControl.Config.SetSongName("Heaven");
        Assert.AreEqual("Heaven", _levelControllerControl.Config.GetSongName());
    }

    [Test]
    public void InitialBpmTests()
    {
        Assert.AreEqual(DefaultLevelValues.InitialBpm, _levelControllerControl.Config.GetInitialBpm());
        _levelControllerControl.Config.SetInitialBpm(69);
        Assert.AreEqual(69, _levelControllerControl.Config.GetInitialBpm());
    }

    [Test]
    public void SongOffsetTests()
    {
        Assert.AreEqual(DefaultLevelValues.SongOffset, _levelControllerControl.Config.GetSongOffset());
        _levelControllerControl.Config.SetSongOffset(20f);
        Assert.AreEqual(20f, _levelControllerControl.Config.GetSongOffset());
    }

    [Test]
    public void TimeSignatureTests()
    {
        Assert.AreEqual(DefaultLevelValues.InitialTimeSignature, _levelControllerControl.Config.GetInitialTimeSignature());
        _levelControllerControl.Config.SetInitialTimeSignature(new TimeSignature(){Nominator = 3, Denominator = 8});
        Assert.AreEqual(new TimeSignature(){Nominator = 3, Denominator = 8}, _levelControllerControl.Config.GetInitialTimeSignature());
    }

    [Test]
    public void InitialBgColorTests()
    {
        Assert.AreEqual("#000000", _levelControllerControl.Config.GetInitialBgColor());
        _levelControllerControl.Config.SetInitialBgColor("#272727");
        Assert.AreEqual("#272727", _levelControllerControl.Config.GetInitialBgColor());
    }

    [Test]
    public void GetLevelConfigTest()
    {
        LevelConfig config = _levelControllerControl.Config.GetLevelConfig();
        
        Assert.AreEqual(DefaultLevelValues.InitialBpm, config.InitialBpm);
        Assert.AreEqual(DefaultLevelValues.InitialTimeSignature, config.InitialTimeSignature);
        Assert.AreEqual(DefaultLevelValues.SongOffset, config.SongOffset);
        Assert.AreEqual(DefaultLevelValues.InitialBgColor,config.InitialBgColor);
        Assert.AreEqual(DefaultLevelValues.SongName,config.SongName);
        Assert.AreEqual(DefaultLevelValues.LevelName,config.LevelName);
        Assert.AreEqual(DefaultLevelValues.AuthorName,config.AuthorName);
    }
}