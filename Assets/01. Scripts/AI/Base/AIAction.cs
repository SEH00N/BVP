using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIBrain brain;

    protected virtual void Awake()
    {
        brain = transform.parent.parent.GetComponent<AIBrain>();
    }
    
    public abstract void TakeAction();
}
