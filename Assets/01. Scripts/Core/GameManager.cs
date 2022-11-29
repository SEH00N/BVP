using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null) { Debug.LogWarning("Multiple gameManager instance is running, destroy this"); Destroy(gameObject); }

        instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }
}
