public class ReceiveData : UnityEngine.MonoBehaviour
{
    public DarkRift.Server.Unity.XmlUnityServer server;
    public bool[] b = new bool[10];
    public short[] j = new short[2];
    public short[] c = new short[2];
    public void Start()
    {
        server.Server.ClientManager.ClientConnected += Connect;
    }
    public void Connect(object sender, DarkRift.Server.ClientConnectedEventArgs e)
    {
        e.Client.MessageReceived += GetData;
    }
    public void Update()
    {
        b = ReceivedData.buttonsPressed;
        j = ReceivedData.joystick;
        c = ReceivedData.cjoystick;
    }
    public void GetData(object sender, DarkRift.Server.MessageReceivedEventArgs e)
    {
        using (DarkRift.Message msg = e.GetMessage())
        {
            using (DarkRift.DarkRiftReader reader = msg.GetReader())
            {
                using (Data data = new Data())
                {
                    if (reader.Length % 18 != 0)
                    {
                        UnityEngine.Debug.LogWarning("Received malformed packet.\n" +
                            $"Packet length should be 18 bytes long, but received a packet that is {reader.Length} bytes long.\n" +
                            $"SendMode: {e.SendMode}");
                        return;
                    }
                    while (reader.Position < reader.Length)
                    {
                        for (byte i = 0; i < 10; i++)
                        {
                            data.buttonsPressed[i] = reader.ReadBoolean();
                        }
                        for (byte i = 0; i < 2; i++)
                        {
                            data.joystick[i] = reader.ReadInt16();
                        }
                        for(byte i = 0; i < 2; i++)
                        {
                            data.cjoystick[i] = reader.ReadInt16();
                        }
                        ReceivedData.Set(data);
                    }
                }
            }
        }
    }
}
