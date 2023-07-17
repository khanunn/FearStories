using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spacebar : MonoBehaviour
{
    public int hitsNeeded = 20;
    private int hits = 0;
    //public GameObject uiWindow;
    //public GameObject uiButton;
    public int levelobject;
    PlayerLevel playerlevel;
    Controller controller;
    public Animator animator;
    [SerializeField] GameObject player;
    public GameObject dialogue;

    void Awake()
    {
        playerlevel = player.GetComponent<PlayerLevel>();
        controller = player.GetComponent<Controller>();
    }

    private void Update()
    {
        if(levelobject == playerlevel.level)
        {
            //uiWindow.SetActive(true);
            //uiButton.SetActive(true);
            animator.SetBool("IsOpen",true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hits++;
                if (hits >= hitsNeeded)
                {
                    //uiWindow.SetActive(false);
                    //uiButton.SetActive(false);
                    animator.SetBool("IsOpen",false);
                    controller.LevelLoad(1);
                    dialogue.SetActive(true);
                }
            }
        }
    }
}