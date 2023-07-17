using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWish : MonoBehaviour
{
    Controller controller;
    [SerializeField] GameObject player;
    public GameObject buttonE;
    PlayerLevel playerlevel;
    public GameObject DialogueWish;
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
        if(controller.letWish == true)
        {
            DialogueWish.SetActive(true);
            controller.letWish = false;
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
                controller.readyWish = true;
                buttonE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            controller.readyWish = false;
            buttonE.SetActive(false);
        }
    }
}
