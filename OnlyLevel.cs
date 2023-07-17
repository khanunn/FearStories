using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyLevel : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerLevel playerlevel;
    public int levelForActive;
    public GameObject whatYouWantToShow; 

    // Start is called before the first frame update
    void Start()
    {
        playerlevel = player.GetComponent<PlayerLevel>();
    }
    private void Update()
    {
        if(playerlevel.level == levelForActive)
        {
            gameObject.SetActive(true);
            whatYouWantToShow.SetActive(true);
        }
        else
        {

            if(whatYouWantToShow != null)
            {
                whatYouWantToShow.SetActive(false);
            }
            //gameObject.SetActive(false);
        }
    }
}
