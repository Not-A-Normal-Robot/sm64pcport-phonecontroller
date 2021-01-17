public class GetData : UnityEngine.MonoBehaviour
{
    public CustomButton[] buttons = new CustomButton[10];
    public FixedJoystick joystick;
    public FixedJoystick cjoy;
    public bool[] buttonsPressed;
    public short[] joystickAxes = new short[2];
    public short[] cjoystick = new short[2];
    public bool isDebugMode = false;
    public void Awake()
    {
        buttonsPressed = new bool[buttons.Length];
    }
    public void Update()
    {
        if(isDebugMode)
        {
            joystickAxes[0] = System.Convert.ToInt16(joystick.Horizontal * 32767);
            joystickAxes[1] = System.Convert.ToInt16(joystick.Vertical * 32767);
            cjoystick[0] = System.Convert.ToInt16(cjoy.Horizontal * 32767);
            cjoystick[1] = System.Convert.ToInt16(cjoy.Vertical * 32767);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttonsPressed[i] = buttons[i].buttonPressed;
            }
        }
    }
    public DarkRift.Message Get()
    {
        using (DarkRift.DarkRiftWriter _writer = DarkRift.DarkRiftWriter.Create())
        {
            // Gathers data
            for (int i = 0; i < buttons.Length; i++)
            {
                _writer.Write(buttons[i].buttonPressed);
            }
            _writer.Write(System.Convert.ToInt16(joystick.Horizontal * 32767));
            _writer.Write(System.Convert.ToInt16(joystick.Vertical * 32767));
            _writer.Write(System.Convert.ToInt16(cjoy.Horizontal * 32767));
            _writer.Write(System.Convert.ToInt16(cjoy.Vertical * 32767));

            // Packages data into a message, then send to invoker
            return DarkRift.Message.Create(0, _writer);
        }
    }
}
