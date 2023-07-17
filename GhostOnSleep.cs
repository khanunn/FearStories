using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostOnSleep : MonoBehaviour
{
    public GameObject ghost;
    private bool readyGhost;
    public PlayerLevel playerlevel;

    // Start is called before the first frame update
    void Start()
    {
        if(ghost != null)
        {
            ghost.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(readyGhost == true)
        {
            if(playerlevel.level == 6)
            {
                ghost.SetActive(true);
                readyGhost = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            readyGhost = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            readyGhost = false;
        }
    }
}
