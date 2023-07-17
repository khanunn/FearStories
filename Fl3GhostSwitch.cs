using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fl3GhostSwitch : MonoBehaviour
{
    public GhostShowHide ghostShowHide;
    public AudioSource jumpSound;
    [SerializeField] GameObject player;
    PlayerLevel playerlevel;
    void Start()
    {
        playerlevel = player.GetComponent<PlayerLevel>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (playerlevel.level != 9)
            {
                ghostShowHide.ShowGhost();
                Debug.Log("GhostShowed");
                jumpSound.Play();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ghostShowHide.HideGhost();
            Debug.Log("GhostHided");
        }
    }
}
