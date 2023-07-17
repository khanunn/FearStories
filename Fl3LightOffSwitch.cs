using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fl3LightOffSwitch : MonoBehaviour
{
    public GameObject[] light;
    private int stack = 0;
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
            if (playerlevel.level == 9)
            {
                if(stack == 0)
                {
                    light[0].SetActive(false);
                }
                else if(stack == 1)
                {
                    light[1].SetActive(false);
                }
                else if(stack == 2)
                {
                    light[2].SetActive(false);
                }
                else if(stack == 3)
                {
                    light[3].SetActive(false);
                }
                else
                {
                    light[4].SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (playerlevel.level == 9)
            {
                stack++;
                Debug.Log("Stack : "+stack);
            }
        }
    }
}
