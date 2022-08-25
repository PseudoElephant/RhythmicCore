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

    public RhythmicValueType Type;
    public bool IsDotted;
    public bool HasTie;
}
