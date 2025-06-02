using UnityEngine;

public class CollectibleBall : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody == null) return;

        BallCollector bc = c.attachedRigidbody.GetComponent<BallCollector>();
        if (bc == null) return;
        bc.ReceiveBall();
        EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
        Destroy(this.gameObject);
    }
}
