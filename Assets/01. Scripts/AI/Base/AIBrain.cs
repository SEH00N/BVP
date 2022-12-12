using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{
    [SerializeField] AIState currentState = null;
    
    public bool onGroggy = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(onGroggy) return;

        currentState.UpdateState(); //상태 업데이트
    }

    public void ChangeToState(AIState targetState) //상태 변경
    {
        currentState = targetState;
    }
}
