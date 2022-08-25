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
    
    /// <summary>
    /// Adds a trigger of the given type, at the specified sub-beat and measure, to the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to add the trigger.</param>
    /// <param name="subBeat">An int representing the sub-beat of the trigger within the measure.</param>
    /// <param name="type">The <see cref="Trigger.TriggerType"/> representing the type of trigger.</param>
    public Trigger AddTrigger(int measureId, int subBeat, Trigger.TriggerType type)
    {
        //TODO: Note, may be useful to return a copy of the trigger object instead and ask for a trigger instead of a type
        
        if (measureId >= _levelData.Measures.Count) throw new Exception(_measureOutOfBounds);
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
        if (measureId >= _levelData.Measures.Count) throw new Exception(_measureOutOfBounds);
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
        return _levelData.Measures[measureId].Triggers;
    }

    /// <summary>
    /// Returns a list of all the triggers at the specified measure and sub-beat.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the trigger.</param>
    /// <param name="subBeat">An in representing the sub-beat of the trigger(s) within the measure.</param>
    /// <returns>A list of type <see cref="Trigger"/> with all the triggers at the specified sub-beat.</returns>
    public List<Trigger> GetTriggersAtPosition(int measureId, int subBeat)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a RhythmicValue of the given type, at the specified measure and sub-beat, to the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to add the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <param name="type">The <see cref="RhythmicValue.RhythmicValueType"/> representing the type of rhythmic value.</param>
    public void AddRhythmicValue(int measureId, int subBeat, RhythmicValue.RhythmicValueType type)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes the RhythmicValue at the specified measure and sub-beat, from the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to remove the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    public void RemoveRhythmicValue(int measureId, int subBeat)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a dictionary with all the RhythmicValues on the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the rhythmic value.</param>
    /// <returns>A Dictionary containing all of the rhythmic values. The key is the sub-beat, and the value is <see cref="RhythmicValue"/>. </returns>
    public Dictionary<int, RhythmicValue> GetRhythmicValuesOnMeasure(int measureId)
    {
        return _levelData.Measures[measureId].RhythmicValues;
    }

    /// <summary>
    /// Returns the RhythmicValue at the specified measure and sub-beat.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <returns>A <see cref="RhythmicValue"/> representing the note or rest at the given measure and sub-beat.</returns>
    public RhythmicValue GetRhythmicValueAtPosition(int measureId, int subBeat)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets the IsDotted property of the <see cref="RhythmicValue"/> at the given measure and sub-beat.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <param name="isDotted">A bool representing if the value is to be dotted or not.</param>
    public void SetRhythmicValueIsDottedAtPosition(int measureId, int subBeat, bool isDotted)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets the HasTie property of the <see cref="RhythmicValue"/> at the given measure and sub-beat.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="subBeat">An int representing the sub-beat of the rhythmic value within the measure.</param>
    /// <param name="hasTie">A bool representing if the value is to be tied to the next note or not.</param>
    public void SetRhythmicValueHasTieAtPosition(int measureId, int subBeat, bool hasTie)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the <see cref="TimeSignature"/> of the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure.</param>
    /// <returns>A <see cref="TimeSignature"/>.</returns>
    public TimeSignature GetTimeSignatureOfMeasure(int measureId)
    {
        return _levelData.Measures[measureId].TimeSignature;
    }

    /// <summary>
    /// Changes the time signature of a measure. It will reorganize and calculate all measures to the right of the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to change the time signature.</param>
    /// <param name="newTimeSignature">A <see cref="TimeSignature"/> specifying the new time signature.</param>
    public void ChangeTimeSignatureOfMeasure(int measureId, TimeSignature newTimeSignature)
    {
        _levelData.Measures[measureId].TimeSignature = newTimeSignature;
        //TODO: Think properly if you have to reorganize all _rhythmic values and triggers here
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
        if (measureId >= _levelData.Measures.Count) throw new Exception(_measureOutOfBounds);
        
        return _levelData.Measures[measureId].RhythmicValues.Count == 0;
    }

    /// <summary>
    /// Returns <c>true</c> if there are <b>no</b> triggers on the measure. 
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to check.</param>
    /// <returns>A bool representing if it has triggers or not.</returns>
    public bool MeasureHasNoTriggers(int measureId)
    {
        if (measureId >= _levelData.Measures.Count) throw new Exception(_measureOutOfBounds);
        
        return _levelData.Measures[measureId].Triggers.Count == 0;
    }
    
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
        return _levelData.Measures[measureId].TimeSignature.Nominator * BeatSubdivisions.Subdivisions > subBeat;
    }
    
    #endregion
}
