using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionBench : MonoBehaviour
{
    [SerializeField] float scrollFactor = -1;
    [SerializeField] Vector3 gameVelocity;
    private bool collisionOccurred = false;
    private bool isGamePaused = false;

    private RestartTextManager restartTextManager;

    Rigidbody rb;

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
