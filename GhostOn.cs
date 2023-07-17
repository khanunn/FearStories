using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostOn : MonoBehaviour
{
    public GameObject player;
    private PlayerLevel playerlevel;
    private Controller controller;
    public GameObject ghost;
    public int levelobject;
    // Start is called before the first frame update
    void Start()
    {
        playerlevel = player.GetComponent<PlayerLevel>();
        controller = player.GetComponent<Controller>();
        ghost.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(levelobject == playerlevel.level)
        {
            StartCoroutine(ShowGhost());
            //ghost.SetActive(true);
            StartCoroutine(HideGhost());
            controller.LevelLoad(1);
            GetComponent<AudioSource>().Play();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        //ghost.SetActive(false);
    }

    IEnumerator HideGhost() 
    {
        yield return new WaitForSeconds(1f);
        ghost.SetActive(false);
    }
    IEnumerator ShowGhost() 
    {
        yield return new WaitForSeconds(0.5f);
        ghost.SetActive(true);
    }
}
