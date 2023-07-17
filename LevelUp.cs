using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    Controller controller;
    [SerializeField] GameObject player;
    public GameObject buttonE;
    PlayerLevel playerlevel;
    //private int levelup;
    public int levelobject;
    [SerializeField] GameObject otherTrigger;

    void Awake()
    {
        controller = player.GetComponent<Controller>();
        playerlevel = player.GetComponent<PlayerLevel>();
        if(buttonE != null)
        {
            buttonE.SetActive(false);
        }
        if(otherTrigger != null)
        {
            otherTrigger.SetActive(false);
        }
    }

    private void Update()
    {
        /*if(levelobject <= playerlevel.level)
        {
            gameObject.SetActive(false);
        }*/
        if(levelobject <= playerlevel.level)
        {
            if(controller.readyGet == false)
            {
                if(buttonE != null)
                {
                    buttonE.SetActive(false);
                }
            }
            if(playerlevel.getLevel == true)
            {
                if(otherTrigger != null)
                {
                    otherTrigger.SetActive(true);
                    playerlevel.getLevel = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(levelobject == playerlevel.level)
            {
                /*levelup = playerlevel.level;
                Debug.Log("LevelPrevious : "+levelup);
                levelup++;
                PlayerPrefs.SetInt("LevelSaved",levelup);*/
                if(buttonE != null)
                {
                    buttonE.SetActive(true);
                }
                else
                {
                    if(otherTrigger != null)
                    {
                        otherTrigger.SetActive(true);
                    }
                }
                controller.readyGet = true;
                /*playerlevel.level = levelup;
                Debug.Log("LevelUp : "+playerlevel.level);*/
                //Destroy(gameObject);
            }
            else
            {
                if(buttonE != null)
                {
                    buttonE.SetActive(false);
                }
                controller.readyGet = false;
                if(otherTrigger != null)
                {
                    //otherTrigger.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            /*if(levelobject > playerlevel.level)
            {
                buttonE.SetActive(false);
                controller.readyGet = false;
            }*/
            if(buttonE != null)
            {
                buttonE.SetActive(false);
            }
            controller.readyGet = false;
            playerlevel.getLevel = false;
        }
    }
}
