using UnityEngine;
using UnityEngine.AI;


public enum AIState
{
    PatrolStaticWaypoints,
    InterceptMovingWaypoint
}


[RequireComponent(typeof(NavMeshAgent))]
public class MinionAI : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public GameObject[] waypoints;
    private int currWaypoint = -1;

    public AIState aiState;

    public GameObject movingWaypoint;
    public GameObject destinationTracker;
    private VelocityReporter velocityReporter;

    private NavMeshAgent agent;
    private Animator anim;



    // private void SetNextWaypoint()
    // {
    //     if (waypoints == null || waypoints.Length == 0)
    //     {
    //         Debug.Log("No waypoints to move to");
    //         return;
    //     }

    //     currWaypoint = (currWaypoint + 1) % waypoints.Length;
    //     navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);

    // }
    // void Start()
    // {
    //     navMeshAgent = GetComponent<NavMeshAgent>();
    //     animator = GetComponent<Animator>();

    //     currWaypoint = -1;
    //     SetNextWaypoint();
    // }

    // Set next waypoint when destination reached
    // void Update()
    // {
    //     if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
    //     {
    //         if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0)
    //         {
    //             SetNextWaypoint();
    //         }
    //     }

    //     // Update Animator parameter for forward movement
    //     float normalizedSpeed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
    //     animator.SetFloat("vely", normalizedSpeed);
    // }

    void Update()
    {
        // Animation based on velocity
        anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);

        switch (aiState)
        {
            case AIState.PatrolStaticWaypoints:
                PatrolStateLogic();
                break;

            case AIState.InterceptMovingWaypoint:
                InterceptStateLogic();
                break;
        }
        if (aiState != AIState.InterceptMovingWaypoint && destinationTracker != null)
        {
            destinationTracker.transform.position = Vector3.down * 100f;  // Hide it far below ground
        }
    }

    void Start()
    {
        aiState = AIState.PatrolStaticWaypoints;
        currWaypoint = -1;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        velocityReporter = movingWaypoint.GetComponent<VelocityReporter>();
        GoToNextStaticWaypoint();
    }

    void PatrolStateLogic()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currWaypoint++;
            if (currWaypoint >= waypoints.Length)
            {
                aiState = AIState.InterceptMovingWaypoint;
            }
            else
            {
                GoToNextStaticWaypoint();
            }
        }
    }

    void GoToNextStaticWaypoint()
    {
        if (currWaypoint >= 0 && currWaypoint < waypoints.Length)
        {
            agent.SetDestination(waypoints[currWaypoint].transform.position);
            Debug.Log("Minion moving to waypoint: " + waypoints[currWaypoint].name);
        }
    }
    void InterceptStateLogic()
    {
        Vector3 waypointPos = movingWaypoint.transform.position;
        Vector3 velocity = velocityReporter.velocity;

        float dist = Vector3.Distance(transform.position, waypointPos);
        float lookahead = Mathf.Clamp(dist / agent.speed, 0.1f, 3.0f);
        Vector3 predictedPos = waypointPos + velocity * lookahead;

        NavMeshHit hit;
        if (NavMesh.Raycast(waypointPos, predictedPos, out hit, NavMesh.AllAreas))
        {
            predictedPos = hit.position - velocity.normalized * 0.5f;
            Debug.Log($"NavMesh.Raycast hit! Adjusted predicted position to: {predictedPos}");
        }

        destinationTracker.transform.position = predictedPos;
        agent.SetDestination(predictedPos);
        Debug.Log($"Intercepting moving waypoint. PredictedPos: {predictedPos}, Agent position: {transform.position}, Distance to waypoint: {dist}");

        float captureDistance = 1.0f;
        if (Vector3.Distance(transform.position, waypointPos) < captureDistance)
        {
            Debug.Log($"Reached moving waypoint: {movingWaypoint.name}. Switching back to PatrolStaticWaypoints.");
            currWaypoint = -1;
            aiState = AIState.PatrolStaticWaypoints;
            GoToNextStaticWaypoint();
        }
    }









}
