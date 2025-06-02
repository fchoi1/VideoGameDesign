using UnityEngine;

public class GrowingCubeTrigger : MonoBehaviour
{
    public Animator animator;     // Assign your cube's Animator in the Inspector.
    public string playerTag = "Player"; // Ensure your player GameObject is tagged appropriately.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // When the player enters, trigger the grow animation.
            animator.SetBool("grow", true);
            Debug.Log("Player entered range – starting to grow.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // When the player exits, trigger the reverse (shrink) animation.
            animator.SetBool("grow", false);
            Debug.Log("Player exited range – starting to shrink.");
        }
    }
}
