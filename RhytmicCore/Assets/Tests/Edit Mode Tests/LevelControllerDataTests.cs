using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class LevelControllerDataTests
{
    private LevelController _levelController;
    private String _subBeatOutOfBounds = "The sub-beat lies outside the measure.";
    private String _measureOutOfBounds = "The measure ID provided does not reference an existing measure. Measure out of bounds.";
    
    [SetUp]
    public void LevelDataSetup()
    {
        _levelController = new LevelController();
    }

    #region Trigger Tests

    [Test]
    public void AddTriggersTest()
    {
        // Add triggers
        Trigger trigger = _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.BgChange);
        Assert.AreEqual(trigger,_levelController.Data.GetTriggersAtPosition(0, 0)[0]);
        
        Trigger trigger2 = _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.Shader);
        Assert.AreEqual(trigger2,_levelController.Data.GetTriggersAtPosition(0, 0)[1]);
    }

    [Test]
    public void RemoveTriggersTest()
    {
        // Add triggers
        Trigger trigger = _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.BgChange);
        Trigger trigger2 = _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.Shader);
        
        // Remove real triggers
        Assert.IsTrue(_levelController.Data.RemoveTrigger(0, 0, trigger2.TriggerID));
        Assert.AreEqual(1, _levelController.Data.GetTriggersAtPosition(0,0).Count);

        Assert.IsTrue(_levelController.Data.RemoveTrigger(0, 0, trigger.TriggerID));
        Assert.AreEqual(0,_levelController.Data.GetTriggersAtPosition(0,0).Count);
        
        // Remove non existent trigger
        Assert.IsFalse(_levelController.Data.RemoveTrigger(0, 0, trigger.TriggerID));
    }

    [Test]
    public void GetTriggersTest()
    {
        // Add triggers
        Trigger trigger = _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.BgChange);
        Trigger trigger2 = _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.Shader);
        Trigger trigger3 = _levelController.Data.AddTrigger(0, 1, Trigger.TriggerType.Bpm);

        // Get Triggers On Measure
        Dictionary<int, List<Trigger>> howItShouldLook = new Dictionary<int, List<Trigger>>();
        List<Trigger> list = new List<Trigger>();
        list.Add(trigger); list.Add(trigger2);
        howItShouldLook.Add(0, list);

        List<Trigger> list2 = new List<Trigger>();
        list2.Add(trigger3);
        howItShouldLook.Add(1, list2);
        
        // Triggers on measure
        Assert.AreEqual(howItShouldLook, _levelController.Data.GetTriggersOnMeasure(0));
        
        // Triggers at position
        Assert.AreEqual(trigger,_levelController.Data.GetTriggersAtPosition(0, 0)[0]);
        Assert.AreEqual(trigger2,_levelController.Data.GetTriggersAtPosition(0, 0)[1]);
        Assert.AreEqual(trigger3,_levelController.Data.GetTriggersAtPosition(0, 1)[0]);
    }
    
    [Test]
    public void TriggerExceptionsTest()
    {
        // Add
        Exception exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddTrigger(1, 0, Trigger.TriggerType.Shader));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddTrigger(0, 120, Trigger.TriggerType.Shader));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddTrigger(-1, 0, Trigger.TriggerType.Shader));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddTrigger(0, -120, Trigger.TriggerType.Shader));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        
        // Remove
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveTrigger(0, 120, new Guid()));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveTrigger(1, 0, new Guid()));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveTrigger(0, -120, new Guid()));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveTrigger(-1, 0, new Guid()));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        
        // Get on Position
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTriggersAtPosition(1, 0));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTriggersAtPosition(0, 120));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTriggersAtPosition(-1, 0));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTriggersAtPosition(0, -120));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        
        // Get On Measure
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTriggersOnMeasure(1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTriggersOnMeasure(-1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
    }
    
    #endregion

    #region Time Signature

    [Test]
    public void GetTimeSignatureTest()
    {
        Assert.AreEqual(new TimeSignature() {Denominator = 4, Nominator = 4}, 
            _levelController.Data.GetTimeSignatureOfMeasure(0));
    }

    [Test]
    public void ChangeTimeSignatureTest()
    {
        // Proper signature change
        Assert.IsTrue(_levelController.Data.ChangeTimeSignatureOfMeasure(0, new TimeSignature() {Nominator = 3, Denominator = 8}));
        Assert.AreEqual(new TimeSignature() {Nominator = 3, Denominator = 8},
            _levelController.Data.GetTimeSignatureOfMeasure(0));
        
        // Add trigger so changing time signature should not happen
        _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.Bpm);
        Assert.IsFalse(_levelController.Data.ChangeTimeSignatureOfMeasure(0, new TimeSignature() {Nominator = 4, Denominator = 4}));
        Assert.AreEqual(new TimeSignature() {Nominator = 3, Denominator = 8},
            _levelController.Data.GetTimeSignatureOfMeasure(0));
    }
    
    [Test]
    public void TimeSignatureExceptionTest()
    {
        // Get 
        Exception exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTimeSignatureOfMeasure(1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetTimeSignatureOfMeasure(-1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        
        // Change
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.ChangeTimeSignatureOfMeasure(1, new TimeSignature() {Nominator = 3, Denominator = 8}));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.ChangeTimeSignatureOfMeasure(-1, new TimeSignature() {Nominator = 3, Denominator = 8}));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
    }

    #endregion

    #region Rhythmic Values

    [Test]
    public void AddRhythmicValuesTest()
    {
        // Adding a note
        RhythmicValue note = _levelController.Data.AddRhythmicValue(0,0, RhythmicValue.RhythmicValueType.WholeNote);
        Assert.AreEqual(note, _levelController.Data.GetRhythmicValueAtPosition(0,0));
        
        // Adding different note should replace it
        RhythmicValue note2 = _levelController.Data.AddRhythmicValue(0,0, RhythmicValue.RhythmicValueType.HalfNote);
        Assert.AreEqual(note2, _levelController.Data.GetRhythmicValueAtPosition(0,0));
    }

    [Test]
    public void RemoveRhythmicValuesTest()
    {
        // Add note 
        _levelController.Data.AddRhythmicValue(0,0, RhythmicValue.RhythmicValueType.WholeNote);
        
        // Remove
        Assert.IsTrue(_levelController.Data.RemoveRhythmicValue(0, 0));
        Assert.IsNull( _levelController.Data.GetRhythmicValueAtPosition(0,0));

        // Remove non-existent note
        Assert.IsFalse(_levelController.Data.RemoveRhythmicValue(0, 0));
    }

    [Test]
    public void GetRhythmicValuesTest()
    {
        // Add notes
        RhythmicValue note = _levelController.Data.AddRhythmicValue(0, 0, RhythmicValue.RhythmicValueType.EightNote);
        RhythmicValue note2 = _levelController.Data.AddRhythmicValue(0, 2, RhythmicValue.RhythmicValueType.EightNote);
        RhythmicValue note3 = _levelController.Data.AddRhythmicValue(0, 4, RhythmicValue.RhythmicValueType.WholeNote);
        
        // How it should look like
        Dictionary<int, RhythmicValue> howItShouldLookLike = new Dictionary<int, RhythmicValue>();
        howItShouldLookLike.Add(0, note); howItShouldLookLike.Add(2, note2); howItShouldLookLike.Add(4, note3);
        
        // Get Measure Values
        Assert.AreEqual(howItShouldLookLike, _levelController.Data.GetRhythmicValuesOnMeasure(0));
        
        // Get at Position
        Assert.AreEqual(note, _levelController.Data.GetRhythmicValueAtPosition(0,0));
        Assert.AreEqual(note2, _levelController.Data.GetRhythmicValueAtPosition(0,2));
        Assert.AreEqual(note3, _levelController.Data.GetRhythmicValueAtPosition(0,4));
    }

    [Test]
    public void ChangeRhythmicAttributesTest()
    {
        RhythmicValue note = _levelController.Data.AddRhythmicValue(0, 0, RhythmicValue.RhythmicValueType.EightNote);
        
        // Is Dotted Setter
        Assert.IsFalse(note.IsDotted);
        _levelController.Data.SetRhythmicValueIsDottedAtPosition(0,0,true);
        Assert.IsTrue(note.IsDotted);
        _levelController.Data.SetRhythmicValueIsDottedAtPosition(0,0,false);
        Assert.IsFalse(note.IsDotted);
        
        // Has Tie Setter
        Assert.IsFalse(note.HasTie);
        _levelController.Data.SetRhythmicValueHasTieAtPosition(0,0,true);
        Assert.IsTrue(note.HasTie);
        _levelController.Data.SetRhythmicValueHasTieAtPosition(0,0,false);
        Assert.IsFalse(note.HasTie);
    }

    [Test]
    public void RhythmicValueExceptionsTest()
    {
        // Add
        Exception exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddRhythmicValue(1,0, RhythmicValue.RhythmicValueType.WholeNote));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddRhythmicValue(-1,0, RhythmicValue.RhythmicValueType.WholeNote));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddRhythmicValue(0,120, RhythmicValue.RhythmicValueType.WholeNote));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.AddRhythmicValue(0,-120, RhythmicValue.RhythmicValueType.WholeNote));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        
        // Remove
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveRhythmicValue(0,120));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveRhythmicValue(0,-120));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveRhythmicValue(1,0));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.RemoveRhythmicValue(-1,0));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        
        // Get on Measure
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetRhythmicValuesOnMeasure(1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetRhythmicValuesOnMeasure(-1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        // Get on Position
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetRhythmicValueAtPosition(1,0));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetRhythmicValueAtPosition(-1,0));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetRhythmicValueAtPosition(0,120));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.GetRhythmicValueAtPosition(0,-120));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        // Setters has Tie
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueHasTieAtPosition(0,120,true));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueHasTieAtPosition(0,-120,true));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueHasTieAtPosition(1,0,true));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueHasTieAtPosition(-1,0,true));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        
        // Setters is dotted
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueIsDottedAtPosition(1,0,true));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueIsDottedAtPosition(-1,0,true));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueIsDottedAtPosition(0,120,true));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.SetRhythmicValueIsDottedAtPosition(0,-120,true));
        
        Assert.That(exception.Message, Is.EqualTo(_subBeatOutOfBounds));
    }

    #endregion

    #region Measures

    [Test]
    public void AddMeasureTest()
    {
        // Check it adds it properly
        _levelController.Data.AddEmptyMeasure();
        Assert.AreEqual(2, _levelController.Data.GetMeasures().Length);
        _levelController.Data.AddEmptyMeasure();
        Assert.AreEqual(3, _levelController.Data.GetMeasures().Length);

        // Check it has the same time signature as the previous measure
        Assert.AreEqual(_levelController.Data.GetTimeSignatureOfMeasure(0),_levelController.Data.GetTimeSignatureOfMeasure(1));
    }

    [Test]
    public void RemoveMeasureTest()
    {
        // Add and remove empty measure
        _levelController.Data.AddEmptyMeasure();
        Assert.IsTrue(_levelController.Data.RemoveEmptyMeasure());
        Assert.AreEqual(1, _levelController.Data.GetMeasures().Length);
        
        // Try to remove last measure (should not allow)
        Assert.IsFalse(_levelController.Data.RemoveEmptyMeasure());
        Assert.AreEqual(1, _levelController.Data.GetMeasures().Length);
        
        // Add measure and make it not empty try to remove
        _levelController.Data.AddEmptyMeasure();
        _levelController.Data.AddTrigger(1, 0, Trigger.TriggerType.Bpm);
        Assert.IsFalse(_levelController.Data.RemoveEmptyMeasure());
        Assert.AreEqual(2, _levelController.Data.GetMeasures().Length);
    }

    [Test]
    public void MeasureAttributesTest()
    {
        Assert.IsTrue(_levelController.Data.MeasureIsEmpty(0));
        
        // Has Triggers
        Assert.IsTrue(_levelController.Data.MeasureHasNoTriggers(0));
        _levelController.Data.AddTrigger(0, 0, Trigger.TriggerType.Bpm);
        Assert.IsFalse(_levelController.Data.MeasureHasNoTriggers(0));
        
        Assert.IsFalse(_levelController.Data.MeasureIsEmpty(0));
        
        // Has Rhythmic values
        Assert.IsTrue(_levelController.Data.MeasureHasNoRhythmicValues(0));
        _levelController.Data.AddRhythmicValue(0, 0, RhythmicValue.RhythmicValueType.EightNote);
        Assert.IsFalse(_levelController.Data.MeasureHasNoRhythmicValues(0));
        
        Assert.IsFalse(_levelController.Data.MeasureIsEmpty(0));
    }

    [Test]
    public void MeasureExceptionsTest()
    {
        // Has Trigger
        Exception exception = Assert.Throws<Exception>(
            () => _levelController.Data.MeasureHasNoTriggers(1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.MeasureHasNoTriggers(-1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        // Has Rhythmic Values
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.MeasureHasNoRhythmicValues(1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.MeasureHasNoRhythmicValues(-1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        // Is Empty
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.MeasureIsEmpty(1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
        
        exception = Assert.Throws<Exception>(
            () => _levelController.Data.MeasureIsEmpty(-1));
        
        Assert.That(exception.Message, Is.EqualTo(_measureOutOfBounds));
    }

    #endregion
}
