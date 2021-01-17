public class UIManager : UnityEngine.MonoBehaviour
{
    public SendData sendData;
    public UnityEngine.UI.Text buttonText;
    public void SwitchConnection()
    {
        sendData.ToggleReliability();
        if (SendData.mode == DarkRift.SendMode.Reliable)
        {
            buttonText.text = "TCP Mode\n[reliable]";
        }
        else
        {
            buttonText.text = "UDP Mode\n[faster, unreliable]";
        }
    }
}
