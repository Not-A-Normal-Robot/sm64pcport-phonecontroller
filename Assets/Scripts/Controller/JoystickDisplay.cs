using UnityEngine;
public class JoystickDisplay : MonoBehaviour
{
    public enum JoystickType
    {
        Normal,
        CJoystick
    }
    public JoystickType joystickType;
    private Vector2 center;
    public Transform circle;
    private Vector2 edge;
    public void Start()
    {
        if(circle == null)
        {
            Debug.LogError("Transform object not set, please set it in the editor.\n" +
                "at JoystickDisplay.cs(13)");
        }
        center = transform.position;
        edge = new Vector2(transform.position.x + gameObject.GetComponent<Renderer>().bounds.size.x / 2,0);
    }
    public void Update()
    {
        if(circle != null)
        {
            if(joystickType == JoystickType.Normal)
            {
                circle.position = new Vector2(ReceivedData.joystick[0] / 32767f * edge.x + center.x, ReceivedData.joystick[1] / 32767f * edge.x + center.y);
            }
            if(joystickType == JoystickType.CJoystick)
            {
                circle.position = new Vector2(ReceivedData.cjoystick[0] * (5000f / 32767f) / 32767f * edge.x + center.x, ReceivedData.cjoystick[1] * (5000f / 32767f) / 32767f * edge.x + center.y);
            }
        }
    }
}