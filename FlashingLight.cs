using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public PlayerLevel playerlevel;
    public GameObject lightNormal;
    public GameObject lightRed;
    public int levelObject;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(levelObject == playerlevel.level)
        {
            lightNormal.SetActive(false);
            lightRed.SetActive(true);
        }
    }
}
