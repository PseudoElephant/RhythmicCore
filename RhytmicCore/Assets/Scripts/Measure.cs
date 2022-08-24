using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Transactions;
using UnityEngine;

public class Measure
{
    private TimeSignature _timeSignature;
    private Dictionary<int, RhythmicValue> _rhythmicValues;
    private Dictionary<int, Trigger> _triggers;

    public Measure(TimeSignature timeSignature)
    {
        _timeSignature = timeSignature;
        _rhythmicValues = new Dictionary<int, RhythmicValue>();
        _triggers = new Dictionary<int, Trigger>();
    }

    public void AddTrigger(Trigger.TriggerType type, int position)
    {
        throw new NotImplementedException();
    }

    public void RemoveTrigger(int position)
    {
        throw new NotImplementedException();
    }

    public Dictionary<int, Trigger> GetTriggers()
    {
        return _triggers;
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

    public Dictionary<int, RhythmicValue> GetRhythmicValues()
    {
        return _rhythmicValues;
    }
    
    public RhythmicValue GetRhythmicValueAtPosition(int position)
    {
        throw new NotImplementedException();
    }

    public TimeSignature GetTimeSignature()
    {
        return _timeSignature;
    }

    public void ChangeTimeSignature(TimeSignature newTimeSignature)
    {
        _timeSignature = newTimeSignature;
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
