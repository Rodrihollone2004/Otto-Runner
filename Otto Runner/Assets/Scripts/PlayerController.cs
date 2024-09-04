using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 jumpSpeed;

    [SerializeField] private float bufferTime = 0.2f; 
    private float bufferCounter = 0f;

    bool isGrounded = false;
    Rigidbody rb;
    void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (bufferCounter > 0)
        {
            bufferCounter -= Time.deltaTime;
        }

        if (Input.anyKeyDown)
        {
            bufferCounter = bufferTime;
        }

        if ((bufferCounter > 0) && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = false;
            bufferCounter = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
