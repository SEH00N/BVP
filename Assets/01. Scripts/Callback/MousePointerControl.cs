using UnityEngine;

public class MousePointerControl : MonoBehaviour
{
    public void ToggleCursor(bool toggle)
    {
        GameManager.Instance.CursorActive = toggle;
        Debug.Log(toggle + " " + GameManager.Instance.CursorActive);
    }
}
