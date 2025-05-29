using UnityEngine;

public class JumpingBeanAI : MonoBehaviour
{
    public float minJumpForce = 5f;
    public float maxJumpForce = 10f;
    public float minJumpDelay = 1f;
    public float maxJumpDelay = 3f;
    public float torqueAmount = 10f;

    private Rigidbody rb;
    private bool isGrounded = false;
    private float nextJumpTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ScheduleNextJump();
    }

    void FixedUpdate()
    {
        CheckGrounded();

        if (isGrounded && Time.time >= nextJumpTime)
        {
            Jump();
            ScheduleNextJump();
        }
    }

    void ScheduleNextJump()
    {
        nextJumpTime = Time.time + Random.Range(minJumpDelay, maxJumpDelay);
    }

    void Jump()
    {
        // Random direction
        Vector3 jumpDir = new Vector3(Random.Range(-0.5f, 0.5f), 1f, Random.Range(-0.5f, 0.5f)).normalized;
        float jumpForce = Random.Range(minJumpForce, maxJumpForce);

        // Apply force
        rb.AddForce(jumpDir * jumpForce, ForceMode.Impulse);

        // Add Random torque 
        Vector3 torque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * torqueAmount;
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    void CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            isGrounded = hit.collider.CompareTag("ground");
        }
        else
        {
            isGrounded = false;
        }
    }
}