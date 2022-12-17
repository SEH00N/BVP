using UnityEngine;
using UnityEngine.AI;

public class Grunt : PoolableMono
{
    [SerializeField] float spawnYDistance = 5f;

    private GruntHealth health = null;
    public GruntHealth Health {
        get {
            if(health == null)
                health = GetComponent<GruntHealth>();
            return health;
        }
    }

    private NavMeshAgent nav = null;

    public override void Reset()
    {
        Health.CurrentHp = Health.MaxhHp;

    }   

    public void Init(Vector3 position)
    {
        position.y += spawnYDistance;
        transform.position = position;

        if(nav == null) 
        {
            nav = GetComponent<NavMeshAgent>();
            nav.enabled = true;
        }
    }
}
