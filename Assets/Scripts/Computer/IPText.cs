public class IPText : UnityEngine.MonoBehaviour
{
    public UnityEngine.UI.Text Text;
    public string prefix = "IP: ";
    string text
    {
        get
        {
            return Text.text;
        }
        set
        {
            Text.text = value;
        }
    }
    void Start()
    {
        StartCoroutine(ShowIP(60));
    }
    System.Collections.IEnumerator ShowIP(float delay)
    {
        System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (System.Net.IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                text = $"{prefix}{ip}";
            }
        }
        yield return new UnityEngine.WaitForSeconds(delay);
        StartCoroutine(ShowIP(delay));
    }
}