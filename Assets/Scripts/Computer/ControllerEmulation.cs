public class ControllerEmulation : UnityEngine.MonoBehaviour
{
    Nefarius.ViGEm.Client.ViGEmClient client = new Nefarius.ViGEm.Client.ViGEmClient();
    Nefarius.ViGEm.Client.Targets.IDualShock4Controller controller;
    bool[] buttonState = new bool[10];
    public void Start()
    {
        if(client == null)
        {
            UnityEngine.Debug.LogError("ViGEmClient is null.");
        }
        controller = client.CreateDualShock4Controller();
        controller.Connect();
        if(controller == null)
        {
            UnityEngine.Debug.LogError("Controller is null.");
        }
    }
    public void FixedUpdate()
    {
        if(controller != null)
        {
            controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Axis.LeftThumbX, ShortToByte(ReceivedData.joystick[0]));
            controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Axis.LeftThumbY, (byte)-ShortToByteCeil(ReceivedData.joystick[1]));
            controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Axis.RightThumbX, ShortToByte(ReceivedData.cjoystick[0]));
            controller.SetAxisValue(Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Axis.RightThumbY, (byte)-ShortToByteCeil(ReceivedData.cjoystick[1]));
            for (byte i = 0; i < 5; i++)
            {
                if (ReceivedData.buttonsPressed[i] != buttonState[i])
                {
                    controller.SetButtonState(ButtonConverter(i), ReceivedData.buttonsPressed[i]);
                    buttonState[i] = ReceivedData.buttonsPressed[i];
                }
            }
            if (ReceivedData.buttonsPressed[9] != buttonState[9])
            {
                controller.SetButtonState(Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button.Options, ReceivedData.buttonsPressed[9]);
                buttonState[9] = ReceivedData.buttonsPressed[9];
            }
        }
    }
    public byte ShortToByte(short n)
    {
        byte a = (byte)(n / 256d + 384d);
        if ((a > 127 && n < 0) || a < 127 && n > 0)
        {
            return (byte)-a;
        }
        else
        {
            return a;
        }
    }
    public byte ShortToByteCeil(short n)
    {
        byte a = (byte)System.Math.Ceiling(n / 256d + 384d);
        if ((a > 127 && n < 0) || a < 127 && n > 0)
        {
            return (byte)-a;
        }
        else
        {
            return a;
        }
    }
    public Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button ButtonConverter(byte index)
    {
        switch (index)
        {
            // A
            case 0:
                return Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button.Cross;
            // B
            case 1:
                return Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button.Square;
            // Z
            case 2:
                return Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button.ThumbLeft;
            // L
            case 3:
                return Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button.TriggerLeft;
            // R
            case 4:
                return Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button.TriggerRight;
            // Unknown
            default:
                return Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Button.Share;
        }
    }
    public void OnApplicationQuit()
    {
        controller.Disconnect();
    }
}
