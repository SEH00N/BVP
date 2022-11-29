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
}
