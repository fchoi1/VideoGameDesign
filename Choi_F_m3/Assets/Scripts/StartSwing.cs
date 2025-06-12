using UnityEngine;

public class StartSwing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(5f, 0f, 10f), ForceMode.Impulse);
    }
}
