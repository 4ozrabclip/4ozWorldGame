using UnityEngine;

public class Talk : MonoBehaviour
{
    private bool playerInside = false;
    private bool talkActive = false;
    private Animator animator;
    public GameObject username;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on GameObject.");
        }
    }

    void Update()
    {
        username.SetActive(talkActive);
        if (playerInside && !talkActive)
        {
            ActivateTalk();
        }
        else if (!playerInside && talkActive)
        {
            
            Invoke("DeactivateTalk", 3f);
        }
    }

    void ActivateTalk()
    {
        talkActive = true;
        if (animator != null)
        {
            animator.SetBool("isTalking", true);
        }
    }

    void DeactivateTalk()
    {
        // Logic to deactivate talk function
        Debug.Log("Player exited the talk trigger.");
        talkActive = false;
        if (animator != null)
        {
            animator.SetBool("isTalking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
