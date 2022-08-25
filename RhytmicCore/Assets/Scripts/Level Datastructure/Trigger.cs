using System;

public class Trigger
{
    public enum TriggerType
    {
        Shader,
        Particle,
        Bpm,
        BgPulse,
        BgChange,
        TimeSignature
    }

    public Guid TriggerID { get; } = new Guid();
    public TriggerType Type;
}
