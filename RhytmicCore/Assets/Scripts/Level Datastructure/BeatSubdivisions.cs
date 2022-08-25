public class BeatSubdivisions
{
    // Note we are using 24 because the minimum number of subdivision on a single beat are 8.
    // That is with time signature x/2 and a minimum note size of 1/16. Since we want precision for tuplets as well 8*3=24.
    // If we add 1/32 notes change to 16*3 = 48 and if 1/64 then 32*3 = 96.
    public const int Subdivisions = 24;
}
