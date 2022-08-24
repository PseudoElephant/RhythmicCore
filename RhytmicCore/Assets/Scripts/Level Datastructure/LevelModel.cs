using System;
using System.Collections.Generic;

public class LevelModel
{
    private Level _level;
    
    public void AddTrigger(Trigger.TriggerType type, int position)
    {
        throw new NotImplementedException();
    }

    public void RemoveTrigger(int position)
    {
        throw new NotImplementedException();
    }

    public Dictionary<int, Trigger> GetTriggers(int measureId)
    {
        return _level.LevelData.Measures[measureId].Triggers;
    }

    public Trigger GetTriggerAtPosition(int position)
    {
        throw new NotImplementedException();
    }
    
    public void AddRhythmicValue(RhythmicValue.RhythmicValueType value, int position)
    {
        throw new NotImplementedException();
    }

    public void RemoveRhythmicValue(int position)
    {
        throw new NotImplementedException();
    }

    public Dictionary<int, RhythmicValue> GetRhythmicValues(int measureId)
    {
        return _level.LevelData.Measures[measureId].RhythmicValues;
    }
    
    public RhythmicValue GetRhythmicValueAtPosition(int position)
    {
        throw new NotImplementedException();
    }

    public TimeSignature GetTimeSignature(int measureId)
    {
        return _level.LevelData.Measures[measureId].TimeSignature;
    }

    public void ChangeTimeSignature(int measureId, TimeSignature newTimeSignature)
    {
        _level.LevelData.Measures[measureId].TimeSignature = newTimeSignature;
        ///TODO: Think properly if you have to reorganize all _rhythmic values and triggers here
    }

    public bool IsEmpty()
    {
        throw new NotImplementedException();
    }

    public bool HasNoRhythmicValues()
    {
        throw new NotImplementedException();
    }

    public bool HasNoTriggers()
    {
        throw new NotImplementedException();
    }
}