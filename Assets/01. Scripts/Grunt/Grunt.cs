using UnityEngine;
using UnityEngine.AI;

public class Grunt : PoolableMono
{
    [SerializeField] float spawnYDistance = 5f;

    private GruntAction performer = null;
    public GruntAction Performer => performer;

    private GruntHealth health = null;
    public GruntHealth Health {
        get {
            if(health == null)
                health = GetComponent<GruntHealth>();
            return health;
        }
    }

    private NavMeshAgent nav = null;
    public NavMeshAgent Nav => nav;

    public override void Reset()
    {
        Health.CurrentHp = Health.MaxhHp;
    }   

    public void Init(Vector3 position, GruntAction performer)
    {
        position.y += spawnYDistance;
        transform.position = position;

        this.performer = performer;

        if(nav == null) 
            nav = GetComponent<NavMeshAgent>();

        nav.enabled = true;
        nav.ResetPath();
    }

    public void Init(Vector3 position, Transform parent = null)
    {
        position.y += spawnYDistance;
        this.transform.position = position;

        if(nav == null) 
            nav = GetComponent<NavMeshAgent>();
        
        nav.enabled = true;
        
        if(parent != null)
            this.transform.SetParent(parent);
    }
}
