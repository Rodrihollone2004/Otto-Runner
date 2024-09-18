using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 gravity;
    [SerializeField] private Vector3 jumpSpeed;
    [SerializeField] private float fastFallMultiplier = 2f;

    [SerializeField] private float bufferTime = 0.2f;
    private float bufferCounter = 0f;
    private bool isGrounded = false;
    private bool isSliding = false;
    private Rigidbody rb;
    private BoxCollider playerCollider;

    private Vector3 originalColliderSize;
    private Vector3 slidingColliderSize;
    private Vector3 originalColliderCenter;
    private Vector3 slidingColliderCenter;

    private LeaderboardManager leaderboardManager;
    private Animator animator;

    [SerializeField] private AudioSource jumpAudioSource;

    private Animator obstacleAnimator;

    void Awake()
    {
        leaderboardManager = FindObjectOfType<LeaderboardManager>();
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();

        originalColliderCenter = playerCollider.center;
        originalColliderSize = playerCollider.size;
        slidingColliderSize = new Vector3(originalColliderSize.x, originalColliderSize.y / 2, originalColliderSize.z);
        slidingColliderCenter = new Vector3(originalColliderCenter.x, originalColliderCenter.y / 2, originalColliderCenter.z);
    }

    void Update()
    {
        Movement();
        FastFall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);
        if (Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftShift) ||
            Input.GetMouseButton(1))
        {
            StartSliding();
        }
    }

    private void Movement()
    {
        if (bufferCounter > 0)
        {
            bufferCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !leaderboardManager.GameObjectLeaderboard.active ||
            Input.GetKeyDown(KeyCode.W) && !leaderboardManager.GameObjectLeaderboard.active ||
            Input.GetKeyDown(KeyCode.UpArrow) && !leaderboardManager.GameObjectLeaderboard.active ||
            Input.GetMouseButtonDown(0) && !leaderboardManager.GameObjectLeaderboard.active)
        {
            animator.SetBool("isJumping", true);
            bufferCounter = bufferTime;

            if (jumpAudioSource != null)
            {
                jumpAudioSource.Play();
            }
        }
        if (Input.GetKey(KeyCode.S) ||
             Input.GetKey(KeyCode.DownArrow) ||
             Input.GetKey(KeyCode.LeftShift) ||
             Input.GetMouseButton(1))
        {
            animator.SetBool("isJumping", false);
            StartSliding();
        }
        if (Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftShift) ||
            Input.GetMouseButtonUp(1))
        {
            animator.SetBool("isJumping", false);
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
        if (!isGrounded && !isSliding && Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftShift) ||
            Input.GetMouseButtonDown(1))
        {
            rb.velocity = new Vector3(rb.velocity.x, -fastFallMultiplier, rb.velocity.z);
        }
    }

    private void StartSliding()
    {
        if (!isSliding && isGrounded)
        {
            isSliding = true;
            playerCollider.size = slidingColliderSize;
            playerCollider.center = slidingColliderCenter;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
            animator.SetBool("isCrawling", true);
        }
    }

    private void StopSliding()
    {
        if (isSliding)
        {
            isSliding = false;
            playerCollider.size = originalColliderSize;
            playerCollider.center = originalColliderCenter;
            animator.SetBool("isCrawling", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Banco"))
        {
            StartSliding();
        }
        else if (other.CompareTag("Nena"))
        {
            // Obtener el Animator del obstáculo
            obstacleAnimator = other.GetComponentInParent<Animator>();

            // Activar la animación de agarrar del obstáculo
            if (obstacleAnimator != null)
            {
                obstacleAnimator.SetTrigger("Grab");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Banco"))
        {
            StopSliding();
        }
    }
}
