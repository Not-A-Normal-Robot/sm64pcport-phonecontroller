
public class Data : System.IDisposable
{
    /// <summary>
    /// Order : A, B, Z, L, R, Cu, Cl, Cr, Cd, Start
    /// </summary>
    public bool[] buttonsPressed = new bool[10];
    public short[] joystick = new short[2];
    public short[] cjoystick = new short[2];
    // { Horizontal, Vertical }
    public void Dispose(){}
}
public static class ReceivedData
{
    /// <summary>
    /// Order : A, B, Z, L, R, Cu, Cl, Cr, Cd, Start
    /// </summary>
    public static bool[] buttonsPressed = new bool[10];
    public static short[] joystick = new short[2];
    public static short[] cjoystick = new short[2];
    // { Horizontal, Vertical }
    public static void Set(Data _d)
    {
        buttonsPressed = _d.buttonsPressed;
        joystick = _d.joystick;
        cjoystick = _d.cjoystick;
    }
}