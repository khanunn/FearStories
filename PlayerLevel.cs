using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level;
    public bool getLevel = false;
    //public GameObject[] dialogue;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("LevelSaved",8);
        level = PlayerPrefs.GetInt("LevelSaved");
        Debug.Log("Player Level : "+level);
    }
}
