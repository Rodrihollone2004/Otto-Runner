using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BenchMov : MonoBehaviour
{
    [SerializeField] float scrollFactor = -1;
    [SerializeField] Vector3 gameVelocity;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;
    }
    private void Update()
    {
        if (GameManger.instance.Dead)
        {
            rb.velocity = gameVelocity * 0;
        }
    }
    private void OnTriggerExit(Collider gameArea)
    {
        Destroy(gameObject);
    }
}
