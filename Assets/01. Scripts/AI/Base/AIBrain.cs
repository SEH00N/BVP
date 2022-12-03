using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{
    [SerializeField] AIState currentState = null;
    private NavMeshAgent navAgent = null;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

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

    public void MoveTo(Vector3 targetPos)
    {
        navAgent.destination = targetPos;
    }
}
