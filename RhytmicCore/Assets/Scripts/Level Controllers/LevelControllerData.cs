using System;
using System.Collections.Generic;

/// <summary>
/// Class in charge of handling the <see cref="LevelData"/> data section of the <see cref="Level"/> class.
/// <b>Note: this class is intended to only be used through <see cref="LevelController"/>.</b>
/// </summary>
public class LevelControllerData
{
    private LevelData _levelData;

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
    /// Adds a trigger of the given type, at the specified position and measure, to the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to add the trigger.</param>
    /// <param name="position">An int representing the position of the trigger within the measure.</param>
    /// <param name="type">The <see cref="Trigger.TriggerType"/> representing the type of trigger.</param>
    public void AddTrigger(int measureId, int position, Trigger.TriggerType type)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes the specified trigger of the given type, at the specified position and measure, from the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to remove the trigger.</param>
    /// <param name="position">An int representing the position of the trigger within the measure.</param>
    /// <param name="type">The <see cref="Trigger.TriggerType"/> representing the type of trigger.</param>
    public void RemoveTrigger(int measureId, int position, Trigger.TriggerType type)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a dictionary with all the triggers on the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the trigger.</param>
    /// <returns>A Dictionary containing all of the triggers. The key is the position, and the value is a list of type <see cref="Trigger"/> which contains the triggers at the specified position. </returns>
    public Dictionary<int, List<Trigger>> GetTriggersOnMeasure(int measureId)
    {
        return _levelData.Measures[measureId].Triggers;
    }

    /// <summary>
    /// Returns a list of all the triggers at the specified measure and position.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the trigger.</param>
    /// <param name="position">An in representing the position of the trigger(s) within the measure.</param>
    /// <returns>A list of type <see cref="Trigger"/> with all the triggers at the specified position.</returns>
    public List<Trigger> GetTriggersAtPosition(int measureId, int position)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a RhythmicValue of the given type, at the specified measure and position, to the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to add the rhythmic value.</param>
    /// <param name="position">An int representing the position of the rhythmic value within the measure.</param>
    /// <param name="type">The <see cref="RhythmicValue.RhythmicValueType"/> representing the type of rhythmic value.</param>
    public void AddRhythmicValue(int measureId, int position, RhythmicValue.RhythmicValueType type)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes the RhythmicValue at the specified measure and position, from the level data.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure to which to remove the rhythmic value.</param>
    /// <param name="position">An int representing the position of the rhythmic value within the measure.</param>
    public void RemoveRhythmicValue(int measureId, int position)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a dictionary with all the RhythmicValues on the specified measure.
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure of the rhythmic value.</param>
    /// <returns>A Dictionary containing all of the rhythmic values. The key is the position, and the value is <see cref="RhythmicValue"/>. </returns>
    public Dictionary<int, RhythmicValue> GetRhythmicValuesOnMeasure(int measureId)
    {
        return _levelData.Measures[measureId].RhythmicValues;
    }

    /// <summary>
    /// Returns the RhythmicValue at the specified measure and position.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="position">An int representing the position of the rhythmic value within the measure.</param>
    /// <returns>A <see cref="RhythmicValue"/> representing the note or rest at the given measure and position.</returns>
    public RhythmicValue GetRhythmicValueAtPosition(int measureId, int position)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets the IsDotted property of the <see cref="RhythmicValue"/> at the given measure and position.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="position">An int representing the position of the rhythmic value within the measure.</param>
    /// <param name="isDotted">A bool representing if the value is to be dotted or not.</param>
    public void SetRhythmicValueIsDottedAtPosition(int measureId, int position, bool isDotted)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets the HasTie property of the <see cref="RhythmicValue"/> at the given measure and position.
    /// </summary>
    /// <param name="measureId">An in representing the ID of the measure of the rhythmic value.</param>
    /// <param name="position">An int representing the position of the rhythmic value within the measure.</param>
    /// <param name="hasTie">A bool representing if the value is to be tied to the next note or not.</param>
    public void SetRhythmicValueHasTieAtPosition(int measureId, int position, bool hasTie)
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
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns <c>true</c> if there are <b>no</b> rhythmic values on the measure. 
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to check.</param>
    /// <returns>A bool representing if it has rhythmic values or not.</returns>
    public bool MeasureHasNoRhythmicValues(int measureId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns <c>true</c> if there are <b>no</b> triggers on the measure. 
    /// </summary>
    /// <param name="measureId">An int representing the ID of the measure to which to check.</param>
    /// <returns>A bool representing if it has triggers or not.</returns>
    public bool MeasureHasNoTriggers(int measureId)
    {
        throw new NotImplementedException();
    }
    
    #endregion
}
