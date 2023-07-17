using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerLevel playerlevel;
    Controller controller;
    public string sceneEndGame;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<Controller>();
        playerlevel = player.GetComponent<PlayerLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerlevel.level == 15)
        {
            StartCoroutine(DelayedLoadScene(1f));
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(playerlevel.getLevel == true)
            {
                Debug.Log ("Get Level : True");
                if(sceneEndGame != null)
                {
                    StartCoroutine(DelayedLoadScene(1f));
                    Debug.Log ("LoadScene EndGame");
                    playerlevel.getLevel = false;
                }
            }
        }
    }

    IEnumerator DelayedLoadScene(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneEndGame);
    }
}
