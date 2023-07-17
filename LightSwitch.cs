using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightOn;
    public GameObject lightOff;
    Controller controller;
    PlayerLevel playerlevel;
    [SerializeField] GameObject player;
    public GameObject buttonE;
    private bool IsSwitchOn;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<Controller>();
        playerlevel = player.GetComponent<PlayerLevel>();
        buttonE.SetActive(false);
        lightOn.SetActive(false);
        lightOff.SetActive(true);
    }
    
    private void Update() 
    {
        if(controller.letSwitch == true)
        {
            if(IsSwitchOn == false)
            {
                lightOn.SetActive(true);
                lightOff.SetActive(false);
                controller.letSwitch = false;
                IsSwitchOn = true;
            }
            else
            {
                lightOn.SetActive(false);
                lightOff.SetActive(true);
                controller.letSwitch = false;
                IsSwitchOn = false;
            }
        }
        if(playerlevel.level == 6)
        {
            lightOn.SetActive(false);
            lightOff.SetActive(true);
            IsSwitchOn = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            buttonE.SetActive(true);
            controller.readySwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            buttonE.SetActive(false);
            controller.readySwitch = false;
        }
    }
}
