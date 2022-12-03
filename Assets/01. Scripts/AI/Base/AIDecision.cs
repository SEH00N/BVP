using System.Reflection;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIBrain brain = null;
    
    protected virtual void Awake()
    {
        brain = transform.parent.parent.parent.GetComponent<AIBrain>();
    }

    public abstract bool MakeDecision(); //확인할 조건
}
