using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Transactions;
using UnityEngine;

public class Measure
{
    public TimeSignature TimeSignature;
    public Dictionary<int, RhythmicValue> RhythmicValues;
    public Dictionary<int, Trigger> Triggers;
}
