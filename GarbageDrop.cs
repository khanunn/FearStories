using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDrop : MonoBehaviour
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
        if(controller.letDrop == true)
        {
            Dialogue.SetActive(true);
            controller.letDrop = false;
            controller.SetFrozen(true);
            controller.LevelLoad(1);
            buttonE.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(limitLevel == playerlevel.level)
            {
                controller.readyDrop = true;
                buttonE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            controller.readyDrop = false;
            buttonE.SetActive(false);
        }
    }
}
