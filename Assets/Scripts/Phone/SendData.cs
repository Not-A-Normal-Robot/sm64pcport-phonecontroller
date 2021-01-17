public class SendData : UnityEngine.MonoBehaviour
{
    public GetData dataClass;
    public DarkRift.Client.Unity.UnityClient client;
    public static DarkRift.SendMode mode = DarkRift.SendMode.Reliable;
    public void Awake()
    {
        client.Address = System.Net.IPAddress.Parse(UnityEngine.PlayerPrefs.GetString("IP"));
        UnityEngine.PlayerPrefs.DeleteAll();
    }
    public void FixedUpdate()
    {
        // Gets message/packet from Data.cs and sends them to all clients
        if(!client.SendMessage(dataClass.Get(), mode))
        {
            if(mode == DarkRift.SendMode.Reliable)
            {
                UnityEngine.Debug.LogWarning("Packet lost when using TCP/IP.");
            }
            else
            {
                UnityEngine.Debug.Log("Packet lost when using UDP.");
            }
        }
    }

    public void ToggleReliability()
    {
        // Toggles between TCP/IP and UDP
        if(mode == DarkRift.SendMode.Reliable)
        {
            mode = DarkRift.SendMode.Unreliable;
            return;
        }
        mode = DarkRift.SendMode.Reliable;
    }
}
