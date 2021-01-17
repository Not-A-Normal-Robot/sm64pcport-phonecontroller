using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum ButtonID
    {
        AButton = 0,
        BButton = 1,
        ZButton = 2,
        LButton = 3,
        RButton = 4,
        CupButton = 5,
        CleftButton = 6,
        CrightButton = 7,
        CdownButton = 8,
        StartButton = 9
    }
    public ButtonID id;
    public bool buttonPressed;
    #region [var code]
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
    #endregion
    public Sprite pressedSprite;
    public Sprite unpressedSprite;
    public Image image;
    public bool hasError = false;
    public void Start()
    {
        // Returns true if spriteRenderer not set
        if(image == null)
        {
            // Log
            Debug.LogWarning($"Image not set, consider setting it to improve performance.\n" +
                $"Parent GameObject: {gameObject}\n" +
                $"at CustomButton.cs(43)");

            // Auto-finding spriteRenderer on parent gameObject
            image = gameObject.GetComponent<Image>();
            if (image == null)
            {
                // Will not update sprite if hasError is true
                hasError = true;

                // Error
                Debug.LogError($"Auto-finding Image failed, consider adding a Image at parent GameObject!\n" +
                    $"Parent GameObject: {gameObject}\n" +
                    $"at CustomButton.cs(55)");
            }
        }
        if(pressedSprite == null || unpressedSprite == null)
        {
            Debug.LogError("pressedSprite and/or unpressedSprite is null. \n" +
                $"Parent GameObject: {gameObject}\n" +
                $"at CustomButton.cs(62)");
        }
    }
    public void FixedUpdate()
    {
        // Don't update sprite if errors occured, prevents exception buildup and improves error FPS
        if(!hasError)
        {
            if(buttonPressed)
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
