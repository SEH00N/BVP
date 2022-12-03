using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIBrain brain;

    private void Awake()
    {
        brain = transform.parent.parent.GetComponent<AIBrain>();
    }
    
    public abstract void TakeAction();
}
