using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stumble : MonoBehaviour
{
    public GameObject player;
    private PlayerLevel playerlevel;
    private Controller controller;
    public int levelobject;
    public GameObject waterDispenser;
    public GameObject blurUI;
    // Start is called before the first frame update
    void Start()
    {
        playerlevel = player.GetComponent<PlayerLevel>();
        controller = player.GetComponent<Controller>();
        waterDispenser.SetActive(false);
        blurUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(levelobject == playerlevel.level)
        {
            controller.LevelLoad(1);
            waterDispenser.SetActive(true);
            blurUI.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
