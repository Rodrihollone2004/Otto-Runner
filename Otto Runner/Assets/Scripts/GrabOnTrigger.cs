using UnityEngine;

public class GrabOnTrigger : MonoBehaviour
{
    public Animator animator;

    public string grabAnimationTrigger = "Grab";
    private void Start()
    {
        //animator = GetComponent<Animator>();
        animator.SetBool("Grabs", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Grabs", true);
        }
    }
}
