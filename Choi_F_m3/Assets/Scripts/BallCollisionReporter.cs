using UnityEngine;

public class BallCollisionReporter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        EventManager.TriggerEvent<BombBounceEvent, Vector3>(transform.position);
    }
}
