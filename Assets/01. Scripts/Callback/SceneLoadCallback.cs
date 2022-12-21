using UnityEngine;

public class SceneLoadCallback : MonoBehaviour
{
    public bool cursorToggle;

    public void LoadScene(string sceneName)
    {
        SceneLoader.Instance.LoadAsync(sceneName, () => GameManager.Instance.CursorActive = cursorToggle );
    }
}
