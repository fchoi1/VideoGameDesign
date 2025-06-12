using UnityEngine;

public class BallCollector : MonoBehaviour
{
    public bool hasBall = false;
    public Rigidbody ballPrefab;
    private Animator animator;
    private Transform handHold;
    private Rigidbody currBall;
    private bool doThrow;


    public void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null) Debug.LogError("No Animator!");
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.name == "BallHoldSpot")
            {
                handHold = t;
                break;
            }
        }
        if (handHold == null) Debug.LogError("ballHold not found");
        if (ballPrefab == null) Debug.LogError("ballPrefab not assigned!");
    }

    public void ReceiveBall()
    {
        hasBall = true;

        if (currBall != null) Destroy(currBall.gameObject);
        currBall = Instantiate(ballPrefab, handHold);
        currBall.isKinematic = true;
        currBall.transform.localPosition = Vector3.zero;

        Debug.Log("Ball collected!");
    }
    public void ThrowBall()
    {
        if (currBall == null) return;
        currBall.transform.parent = null;
        currBall.isKinematic = false;
        currBall.linearVelocity = Vector3.zero;
        currBall.angularVelocity = Vector3.zero;
        currBall.AddForce(transform.forward * 10f, ForceMode.VelocityChange); // adjust force
        Debug.Log("Ball thrown!", currBall);
        currBall = null;
    }

    void Update()
    {
        if (currBall != null && Input.GetButtonDown("Fire1"))
        {
            doThrow = true;
            Debug.Log("Throwing ball!");
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("No ball to throw!");
        }
    }

    void FixedUpdate()
    {
        if (doThrow)
        {
            Debug.Log("do throw");
            doThrow = false;
            hasBall = false;
            animator.SetBool("throw", true);
        }
        else
        {
            animator.SetBool("throw", false);
        }
    }
}
