using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodGirl : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Play();
            StartCoroutine(seizureTime());
        }
    }
    private IEnumerator seizureTime(){
        yield return new WaitForSeconds(5);
        animator.SetTrigger("seizure");
        yield return new WaitForSeconds(10);
        animator.SetTrigger("seizure");
    }
}