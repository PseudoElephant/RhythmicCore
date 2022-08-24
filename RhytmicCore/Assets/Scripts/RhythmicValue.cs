public class RhythmicValue
{
    public enum RhythmicValueType
    {
        WholeNote,
        HalfNote,
        EightNote,
        SixteenthNote,
        WholeRest,
        HalfRest,
        EightRest,
        SixteenthRest,
        Tuple
    }

    public RhythmicValueType Value;
    public bool IsDotted;
    public bool HasTie;
}
