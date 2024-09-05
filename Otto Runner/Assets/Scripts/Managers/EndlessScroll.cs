using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessScroll : MonoBehaviour
{
    public float scrollFactor = -1;
    public Vector3 gameVelocity;
    private bool collisionOccurred = false;
    private bool isGamePaused = false;

    private RestartTextManager restartTextManager;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;

        restartTextManager = FindObjectOfType<RestartTextManager>();

        if (restartTextManager == null)
        {
            Debug.LogError("No se encontró el RestartTextManager en la escena.");
        }
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

            if (restartTextManager != null)
            {
                restartTextManager.ShowRestartText();
            }
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
