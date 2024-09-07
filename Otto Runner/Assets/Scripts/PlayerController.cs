using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 gravity;
    [SerializeField] private Vector3 jumpSpeed;
    [SerializeField] private float fastFallMultiplier = 3f;

    [SerializeField] private float bufferTime = 0.2f;
    private float bufferCounter = 0f;
    private bool isGrounded = false;
    private bool isSliding = false; 
    private Rigidbody rb;
    private BoxCollider playerCollider;

    private Vector3 originalColliderSize; 
    private Vector3 slidingColliderSize; 

    void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();

        originalColliderSize = playerCollider.size;
        slidingColliderSize = new Vector3(originalColliderSize.x, originalColliderSize.y / 2, originalColliderSize.z); 
    }

    void Update()
    {
        Movement();
        FastFall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void Movement()
    {

        if (bufferCounter > 0)
        {
            bufferCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetMouseButtonDown(0))
        {
            bufferCounter = bufferTime;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            StartSliding();
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButtonUp(1))
        {
            StopSliding();
        }

        if ((bufferCounter > 0) && isGrounded && !isSliding)
        {
            rb.velocity = jumpSpeed;
            isGrounded = false;
            bufferCounter = 0;
        }
    }

    private void FastFall()
    {
        if (!isGrounded && Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity += Vector3.down * fastFallMultiplier * Time.deltaTime;
        }
    }

    private void StartSliding()
    {
        if (!isSliding)
        {
            isSliding = true;
            playerCollider.size = slidingColliderSize; 
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z); 
        }
    }

    private void StopSliding()
    {
        if (isSliding)
        {
            isSliding = false;
            playerCollider.size = originalColliderSize;
        }
    }
}
