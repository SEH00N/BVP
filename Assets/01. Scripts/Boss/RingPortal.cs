using UnityEngine;

public class RingPortal : MonoBehaviour
{
    public Color ringColor;
    [SerializeField] Transform portalRoom = null;
    [SerializeField] ElementOreHealth ore = null;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.position = portalRoom.position;
            ore.Reset(this);
        }
    }

    public void Die()
    {
        //너가 해라 김민수
        transform.parent.parent.parent.GetComponent<BossHealth>()?.OnDamage(40f);
    }
}
