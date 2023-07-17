using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    public int levelSetForMap; 
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LevelSaved",levelSetForMap);
    }
}
