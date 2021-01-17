public class ConnectToController : UnityEngine.MonoBehaviour
{
    public UnityEngine.UI.InputField _ip;
    public void Connect()
    {
        try
        {
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(_ip.text);
            UnityEngine.PlayerPrefs.SetString("IP",_ip.text);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Phone");
        }
        catch(System.FormatException fe)
        {
            UnityEngine.Debug.Log(fe);
            UnityEngine.Debug.LogWarning("User tried to input invalid IP Address\n" +
                "at ConnectToController.cs(13)");
        }
        catch(System.Exception e)
        {
            UnityEngine.Debug.LogError(e);
        }
    }
}
