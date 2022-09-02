using System;
using System.Collections.Generic;

/// <summary>
/// Class in charge of handling the <see cref="LevelData"/> data section of the <see cref="Level"/> class.
/// <b>Note: this class is intended to only be used through <see cref="LevelController"/>.</b>
/// </summary>
public class LevelControllerData
{
    private LevelData _levelData;
    
    //Exception strings
    private String _subBeatOutOfBounds = "The sub-beat lies outside the measure.";
    private String _measureOutOfBounds = "The measure ID provided does not reference an existing measure. Measure out of bounds.";

    /// <summary>
    /// Initializes <see cref="LevelControllerData"/> with the current <see cref="LevelData"/> data.
    /// </summary>
    /// <param name="levelData">The current <see cref="LevelData"/> of the level.</param>
    public LevelControllerData(LevelData levelData)
    {
        _levelData = levelData;
    }

    #region Methods

    #region Triggers
    
    /// <summary>
    /// Adds a trigger of the given type, at the specified sub-beat and measure, to the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to add the trigger.</param>
    /// <param name="subBeat">An int representing the sub-beat of the trigger within the measure.</param>
    /// <param name="type">The <see cref="Trigger.TriggerType"/> representing the type of trigger.</param>
    public Trigger AddTrigger(int measureId, int subBeat, Trigger.TriggerType type)
    {
        //TODO: Note, may be useful to return a copy of the trigger object instead and ask for a trigger instead of a type
        
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);
        
        Dictionary<int, List<Trigger>> triggers = _levelData.Measures[measureId].Triggers;

        Trigger newTrigger = new Trigger();
        newTrigger.Type = type;
        
        if (!triggers.ContainsKey(subBeat)) // If there is no list initialized
        {
            List<Trigger> newList = new List<Trigger>();
            newList.Add(newTrigger);
            triggers.Add(subBeat, newList);
            return newTrigger;
        }
        
        triggers[subBeat].Add(newTrigger);
        return newTrigger;
    }

    /// <summary>
    /// Removes the specified trigger of the given type, at the specified sub-beat and measure, from the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to remove the trigger.</param>
    /// <param name="subBeat">An int representing the sub-beat of the trigger within the measure.</param>
    /// <param name="triggerID">The <see cref="Trigger.TriggerID"/> representing the trigger.</param>
    /// <returns>True if the trigger is successfully removed, false otherwise</returns>
    public bool RemoveTrigger(int measureId, int subBeat, Guid triggerID)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);
        
        Dictionary<int, List<Trigger>> triggers = _levelData.Measures[measureId].Triggers;

        for (int i = 0; i < triggers[subBeat]?.Count; i++)
        {
            if (triggers[subBeat][i].TriggerID != triggerID) continue;
            
            triggers[subBeat].RemoveAt(i);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Returns a dictionary with all the triggers on the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the trigger.</param>
    /// <returns>A Dictionary containing all of the triggers. The key is the sub-beat, and the value is a list of type <see cref="Trigger"/> which contains the triggers at the specified sub-beat. </returns>
    public Dictionary<int, List<Trigger>> GetTriggersOnMeasure(int measureId)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        
        return _levelData.Measures[measureId].Triggers;
    }

    /// <summary>
    /// Returns a list of all the triggers at the specified measure and sub-beat. If there are no triggers it returns null.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the trigger.</param>
    /// <param name="subBeat">An in representing the sub-beat of the trigger(s) within the measure.</param>
    /// <returns>A list of type <see cref="Trigger"/> with all the triggers at the specified sub-beat.</returns>
    public List<Trigger> GetTriggersAtPosition(int measureId, int subBeat)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);

        return _levelData.Measures[measureId].Triggers[subBeat];
    }
    
    #endregion

    #region RhythmicValues
    
    /// <summary>
    /// Adds a RhythmicValue of the given type, at the specified measure and sub-beat, to the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to add the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <param name="type">The <see cref="RhythmicValue.RhythmicValueType"/> representing the type of rhythmic value.</param>
    public RhythmicValue AddRhythmicValue(int measureId, int subBeat, RhythmicValue.RhythmicValueType type)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);
        
        Dictionary<int, RhythmicValue> rhythmicValues = _levelData.Measures[measureId].RhythmicValues;

        RhythmicValue newRhythmicValue = new RhythmicValue();
        newRhythmicValue.Type = type;
        
        if (!rhythmicValues.ContainsKey(subBeat)) // If there is no prev note
        {
            rhythmicValues.Add(subBeat, newRhythmicValue);
            return newRhythmicValue;
        }

        rhythmicValues[subBeat] = newRhythmicValue;
        return newRhythmicValue;
    }

    /// <summary>
    /// Removes the RhythmicValue at the specified measure and sub-beat. Returns true if removed, else false.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to remove the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <returns>True if removed, otherwise false.</returns>
    public bool RemoveRhythmicValue(int measureId, int subBeat)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);
        
        Dictionary<int, RhythmicValue> rhythmicValues = _levelData.Measures[measureId].RhythmicValues;

        return rhythmicValues.Remove(subBeat);
    }

    /// <summary>
    /// Returns a dictionary with all the RhythmicValues on the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the rhythmic value.</param>
    /// <returns>A Dictionary containing all of the rhythmic values. The key is the sub-beat, and the value is <see cref="RhythmicValue"/>. </returns>
    public Dictionary<int, RhythmicValue> GetRhythmicValuesOnMeasure(int measureId)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        
        return _levelData.Measures[measureId].RhythmicValues;
    }

    /// <summary>
    /// Returns the RhythmicValue at the specified measure and sub-beat. Returns null if there is none.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <returns>A <see cref="RhythmicValue"/> representing the note or rest at the given measure and sub-beat.</returns>
    public RhythmicValue GetRhythmicValueAtPosition(int measureId, int subBeat)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);

        Dictionary<int, RhythmicValue> rhythmicValues = _levelData.Measures[measureId].RhythmicValues;
        
        if (!rhythmicValues.ContainsKey(subBeat))
        {
            return null;
        }

        return rhythmicValues[subBeat];
    }
    
    /// <summary>
    /// Sets the IsDotted property of the <see cref="RhythmicValue"/> at the given measure and sub-beat.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <param name="isDotted">A bool representing if the value is to be dotted or not.</param>
    public void SetRhythmicValueIsDottedAtPosition(int measureId, int subBeat, bool isDotted)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);
            
        RhythmicValue rhythmicValue = _levelData.Measures[measureId].RhythmicValues[subBeat];

        if (rhythmicValue != null)
        {
            rhythmicValue.IsDotted = isDotted;
        }
    }

    /// <summary>
    /// Sets the HasTie property of the <see cref="RhythmicValue"/> at the given measure and sub-beat.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <param name="hasTie">A bool representing if the value is to be tied to the next note or not.</param>
    public void SetRhythmicValueHasTieAtPosition(int measureId, int subBeat, bool hasTie)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        if (!IsProperSubBeat(measureId, subBeat)) throw new Exception(_subBeatOutOfBounds);
            
        RhythmicValue rhythmicValue = _levelData.Measures[measureId].RhythmicValues[subBeat];

        if (rhythmicValue != null)
        {
            rhythmicValue.HasTie = hasTie;
        }
    }

    #endregion

    #region TimeSignature
    
    /// <summary>
    /// Returns the <see cref="TimeSignature"/> of the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure.</param>
    /// <returns>A <see cref="TimeSignature"/>.</returns>
    public TimeSignature GetTimeSignatureOfMeasure(int measureId)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);

        return _levelData.Measures[measureId].TimeSignature;
    }

    /// <summary>
    /// Changes the time signature of a measure, returns true if changed successfully. <b>Will only change time signature if measure is empty.</b>
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to change the time signature.</param>
    /// <param name="newTimeSignature">A <see cref="TimeSignature"/> specifying the new time signature.</param>
    /// <returns>True if time signature is successfully changed, otherwise false.</returns>
    public bool ChangeTimeSignatureOfMeasure(int measureId, TimeSignature newTimeSignature)
    {
        if (!MeasureIsEmpty(measureId)) return false; //This handles measureId outOfBounds error.
        
        _levelData.Measures[measureId].TimeSignature = newTimeSignature;
        return true;
    }
    
    #endregion

    #region Measures
    
    /// <summary>
    /// Returns a Measure array with all measure on the level.
    /// </summary>
    /// <returns>An array of type <see cref="Measure"/></returns>
    public Measure[] GetMeasures()
    {
        Measure[] measures = new Measure[_levelData.Measures.Count];
        _levelData.Measures.CopyTo(measures);

        return measures;
    }
    
    /// <summary>
    /// Adds a new empty measure at the end of the last existing measure.
    /// </summary>
    public void AddEmptyMeasure()
    {
        // Empty measure to add
        Measure newMeasure = new Measure();
        newMeasure.Triggers = new Dictionary<int, List<Trigger>>();
        newMeasure.RhythmicValues = new Dictionary<int, RhythmicValue>();
        newMeasure.TimeSignature = _levelData.Measures[_levelData.Measures.Count - 1].TimeSignature;
        
        // Add Measure
        _levelData.Measures.Add(newMeasure);
    }

    /// <summary>
    /// Removes the rightmost measure, note that it must be empty. Returns true if removed successfully, otherwise false. It will not remove the measure if it is the only measure in the level.
    /// </summary>
    /// <returns>True if measure is removed successfully, otherwise false.</returns>
    public bool RemoveEmptyMeasure()
    {
        if (_levelData.Measures.Count == 1) return false; // If it's the last measure
        if (!MeasureIsEmpty(_levelData.Measures.Count - 1)) return false; // If it's not empty
        
        _levelData.Measures.RemoveAt(_levelData.Measures.Count -1);
        return true;
    }
    
    /// <summary>
    /// Returns <c>true</c> if there are <b>no</b> triggers <i>and</i> rhythmic values on the measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to check.</param>
    /// <returns>A bool representing if its empty or not.</returns>
    public bool MeasureIsEmpty(int measureId)
    {
        return MeasureHasNoTriggers(measureId) && MeasureHasNoRhythmicValues(measureId);
    }

    /// <summary>
    /// Returns <c>true</c> if there are <b>no</b> rhythmic values on the measure. 
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to check.</param>
    /// <returns>A bool representing if it has rhythmic values or not.</returns>
    public bool MeasureHasNoRhythmicValues(int measureId)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        
        return _levelData.Measures[measureId].RhythmicValues.Count == 0;
    }

    /// <summary>
    /// Returns <c>true</c> if there are <b>no</b> triggers on the measure. 
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to check.</param>
    /// <returns>A bool representing if it has triggers or not.</returns>
    public bool MeasureHasNoTriggers(int measureId)
    {
        if (!IsProperMeasure(measureId)) throw new Exception(_measureOutOfBounds);
        
        return _levelData.Measures[measureId].Triggers.Count == 0;
    }
    
    #endregion
    
    #endregion

    #region Helper Methods

    /// <summary>
    /// Returns true if the subBeat value lies inside the measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure.</param>
    /// <param name="subBeat">An int representing the sub-beat we want to check.</param>
    /// <returns></returns>
    private bool IsProperSubBeat(int measureId, int subBeat)
    {
        return _levelData.Measures[measureId].TimeSignature.Nominator * BeatSubdivisions.Subdivisions > subBeat && subBeat >= 0;
    }

    /// <summary>
    /// Returns true if measure is proper, otherwise false.
    /// </summary>
    /// <param name="measureId">An int representing the measureID.</param>
    private bool IsProperMeasure(int measureId)
    {
        return (measureId < _levelData.Measures.Count && measureId >= 0);
    }

    #endregion
}
