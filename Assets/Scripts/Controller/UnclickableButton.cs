public class UnclickableButton : UnityEngine.MonoBehaviour
{
    public CustomButton.ButtonID id;
    public UnityEngine.Sprite pressedSprite;
    public UnityEngine.Sprite unpressedSprite;
    public UnityEngine.UI.Image image;
    public bool hasError = false;
    public void Start()
    {
        // Returns true if spriteRenderer not set
        if (image == null)
        {
            // Log
            UnityEngine.Debug.LogWarning($"Image not set, consider setting it to improve performance.\n" +
                $"Parent GameObject: {gameObject}\n" +
                $"at CustomButton.cs(40)");

            // Auto-finding spriteRenderer on parent gameObject
            image = gameObject.GetComponent<UnityEngine.UI.Image>();
            if (image == null)
            {
                // Will not update sprite if hasError is true
                hasError = true;

                // Error
                UnityEngine.Debug.LogError($"Auto-finding Image failed, consider adding a Image at parent GameObject!\n" +
                    $"Parent GameObject: {gameObject}\n" +
                    $"at CustomButton.cs(47)");
            }
        }
    }
    public void Update()
    {
        // Don't update sprite if errors occured, prevents exception buildup and improves error FPS
        if (!hasError)
        {
            if (ReceivedData.buttonsPressed[(int)id])
            {
                // Highlights button when pressed...
                image.sprite = pressedSprite;
                return;
            }
            // And the opposite when not.
            image.sprite = unpressedSprite;
        }
    }
}