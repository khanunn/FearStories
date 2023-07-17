using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownOffering : MonoBehaviour
{
    Controller controller;
    [SerializeField] GameObject player;
    public GameObject buttonE;
    PlayerLevel playerlevel;
    public GameObject Dialogue;
    public int limitLevel;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<Controller>();
        playerlevel = player.GetComponent<PlayerLevel>();
        buttonE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.letPutdown == true)
        {
            Dialogue.SetActive(true);
            controller.letPutdown = false;
            controller.SetFrozen(true);
            controller.LevelLoad(1);
            buttonE.SetActive(false);
            controller.readyToSeeGhost = true;
            PlayerPrefs.SetInt("ReadyToSeeGhost", controller.readyToSeeGhost ? 1 : 0);
            Debug.Log("ReadyToSeeGhost :"+controller.readyToSeeGhost);
            //controller.readyToSeeGhost = PlayerPrefs.GetBool("ReadyToSeeGhost");;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(limitLevel == playerlevel.level)
            {
                controller.readyPutdown = true;
                buttonE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            controller.readyPutdown = false;
            buttonE.SetActive(false);
        }
    }
}