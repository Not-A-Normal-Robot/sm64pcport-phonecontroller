using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager; 
public class MainMenu : MonoBehaviour
{
    public GameObject loadingText;
    public GameObject errorText;
    public GameObject restartButton;
    public bool isInPC;
    public void Start()
    {
        loadingText.SetActive(true);
        restartButton.SetActive(false);
        errorText.SetActive(false);
        if (Application.internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            loadingText.SetActive(false);
            errorText.SetActive(true);
            restartButton.SetActive(true);
        }
        else
        {
            isInPC = Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxEditor || Application.platform == RuntimePlatform.LinuxPlayer;
            if (isInPC)
            {
                StartServer();
            }
            else
            {
                StartClient();
            }
        }
    }

    public void StartClient()
    {
        if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            LoadScene("ConnectToComputer");
        }
    }

    public void StartServer()
    {
        if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            LoadScene("Computer");
        }
    }
}
