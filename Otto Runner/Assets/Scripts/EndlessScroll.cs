using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessScroll : MonoBehaviour
{
    public float scrollFactor = -1;
    public Vector3 gameVelocity;
    private bool collisionOccurred = false;
    private bool isGamePaused = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;
    }

    private void OnTriggerExit(Collider gameArea)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionOccurred = true;
        if (!isGamePaused)
        {
            Time.timeScale = 0; 
            isGamePaused = true;
        }
    }
    void Update()
    {
        if (collisionOccurred && Input.anyKeyDown)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
