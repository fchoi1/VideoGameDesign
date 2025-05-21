using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{

    public Transform player;

    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (player != null)
    //     {
    //         navMeshAgent.SetDestination(player.position);
    //     }

    // }
    void Update()
    {
        if (player != null)
        {
            NavMeshPath path = new NavMeshPath();
            navMeshAgent.CalculatePath(player.position, path);

            if (path.status == NavMeshPathStatus.PathComplete)
            {
                navMeshAgent.SetPath(path);

                // Draw each path segment
                for (int i = 0; i < path.corners.Length - 1; i++)
                {
                    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.green, 2.0f);
                }
            }

            else
            {
                Debug.Log("No valid path to player!");
                navMeshAgent.ResetPath();
            }
        }
    }

}
