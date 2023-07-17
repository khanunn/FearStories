using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public string lastSceneBack;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("LastSceneBack") == lastSceneBack)
        {
            Debug.Log("GetSceneBack : " + lastSceneBack);
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
            GetComponent<AudioSource>().Play();
        }
    }
}
