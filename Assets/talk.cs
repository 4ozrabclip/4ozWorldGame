using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class Talk : MonoBehaviour
{
    private bool playerInside = false;
    private bool talkActive = false;
    private bool coroutineStarted = false; // New flag to track if the coroutine has been started
    private Animator animator;
    public GameObject username;
    public GameObject messageManagerObject;
    private GameManager messageManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        messageManager = messageManagerObject.GetComponent<GameManager>();
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
            if (!coroutineStarted) // Check if the coroutine hasn't been started yet
            {
                StartCoroutine(chatting());
                coroutineStarted = true; // Set the flag to true to prevent starting new coroutines
            }
        }
    }

    IEnumerator chatting()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("co start");
        messageManager.SendMessageToChat("Alex: hey stranger jajaja", Message.MessageType.npcMessage);
        yield break;
    }

    void DeactivateTalk()
    {
        // Logic to deactivate talk function
        Debug.Log("Player exited the talk trigger.");
        talkActive = false;
        coroutineStarted = false; // Reset the flag when the talk is deactivated
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