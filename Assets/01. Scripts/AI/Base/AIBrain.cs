using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField] AIState currentState = null;

    private void Start()
    {
        
    }

    private void Update()
    {
        currentState.UpdateState(); //상태 업데이트
    }

    public void ChangeToState(AIState targetState) //상태 변경
    {
        currentState = targetState;
    }
}
