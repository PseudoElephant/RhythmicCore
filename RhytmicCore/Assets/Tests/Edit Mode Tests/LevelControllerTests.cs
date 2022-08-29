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

        Assert.AreEqual(120, _levelControllerControl.Config.GetInitialBpm());
        Assert.AreEqual(new TimeSignature() {Denominator = 4, Nominator = 4} , _levelControllerControl.Config.GetInitialTimeSignature());
        Assert.AreEqual(0f, _levelControllerControl.Config.GetSongOffset());
        Assert.AreEqual("#000000",_levelControllerControl.Config.GetInitialBgColor());
        Assert.AreEqual("Song Name",_levelControllerControl.Config.GetSongName());
        Assert.AreEqual("New Level",_levelControllerControl.Config.GetLevelName());
        Assert.AreEqual("Author Name",_levelControllerControl.Config.GetLevelAuthor());
    
    
        Assert.AreEqual(1, _levelControllerControl.Data.GetMeasures().Length);
    
        Measure measure = _levelControllerControl.Data.GetMeasures()[0];
        Assert.AreEqual(0, measure.Triggers.Count);
        Assert.AreEqual(0, measure.RhythmicValues.Count);
        Assert.AreEqual(new TimeSignature() {Denominator = 4, Nominator = 4} , measure.TimeSignature);
    }
}
