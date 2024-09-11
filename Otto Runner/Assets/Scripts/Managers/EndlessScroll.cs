using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessScroll : MonoBehaviour
{
    public float scrollFactor = -1;
    public Vector3 gameVelocity;
    private bool collisionOccurred = false;

    private RestartTextManager restartTextManager;

    private ObstacleSpawner obstacleSpawner;
    private CoinSpawner coinSpawner;

    private Rigidbody rb;

    private Animator animator;

    LeaderboardManager leaderboardManager;

    void Start()
    {
        leaderboardManager = FindAnyObjectByType<LeaderboardManager>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        coinSpawner = FindObjectOfType<CoinSpawner>();

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
        obstacleSpawner.NoSpawn = false;
        coinSpawner.StopSpawnCoins = false;
        collisionOccurred = true;
        animator.SetBool("isDead", true);
        gameVelocity = Vector3.zero;
        GameManger.instance.Dead = true;

        if (GameManger.instance.IsLeaderboard)
            leaderboardManager.EnterLeaderboard();

        if (restartTextManager != null)
        {
            restartTextManager.ShowRestartText();
        }
    }
    void Update()
    {
        if (GameManger.instance.Dead)
        {
            rb.velocity = gameVelocity * 0;
        }
        if (collisionOccurred && Input.anyKeyDown && GameManger.instance.IsLeaderboard == false)
        {
            animator.SetBool("isDead", false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
