using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwitch : MonoBehaviour
{
    public AudioSource knockSound;
    public AudioSource electricSound;
    Animator animator;
    bool isPlayed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isPlayed = false;
        electricSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(isPlayed == false)
            {
                isPlayed = true;
                animator.SetBool("isBroken", true);
                knockSound.Play();
                electricSound.Pause();
                StartCoroutine(ToiletLight(5f));
            } 
        }
    }

    IEnumerator ToiletLight(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        animator.SetBool("isBroken", false);
        electricSound.Play();
    }
}
