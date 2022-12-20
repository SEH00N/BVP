using UnityEngine;

public class RingPortal : MonoBehaviour
{
    public Color ringColor;
    [SerializeField] Transform portalRoom = null;
    [SerializeField] ElementOreHealth ore = null;
    [SerializeField] Transform light = null;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            foreach(Light l in light.GetComponentsInChildren<Light>()){
                l.color = ringColor;
            }
            other.transform.position = portalRoom.position;
            ore.Reset(this);
        }
    }

    public void Die()
    {
        Particle portalDestroy = PoolManager.Instance.Pop("PortalDestroy") as Particle;
        portalDestroy.transform.position = transform.position;
        transform.parent.gameObject.SetActive(false);
        transform.parent.parent.parent.GetComponent<BossHealth>()?.OnDamage(40f);
    }
}
