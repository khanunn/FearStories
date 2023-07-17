using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NursingSwitch : MonoBehaviour
{
    public AudioSource medicSound;
    public GameObject anatomyFont;
    public GameObject anatomyBack;
    bool isPlayed;
    // Start is called before the first frame update
    void Start()
    {
        isPlayed = false;
        anatomyBack.SetActive(false);
        anatomyFont.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(isPlayed == false)
            {
                isPlayed = true;
                medicSound.Play();
                anatomyBack.SetActive(true);
                anatomyFont.SetActive(false);
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            anatomyBack.SetActive(false);
            anatomyFont.SetActive(true);
        }
    }
}
