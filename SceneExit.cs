using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneLoad;
    public string sceneBack;
    Controller controller;
    [SerializeField] GameObject player;
    public GameObject buttonE;
    public GameObject dialogueTrigger;
    public GameObject keyPopup;

    PlayerLevel playerlevel;

    ZoomCamera zoomcamera;
    string[] sceneName = {"BedRoom","Gym","Floor2A","Floor2B","ControllerRoom","Nursing","Libary","Floor3","SolitaryRoom"};

    void Awake()
    {
        controller = player.GetComponent<Controller>();
        playerlevel = player.GetComponent<PlayerLevel>();
        zoomcamera = GetComponent<ZoomCamera>();
        buttonE.SetActive(false);
        if(keyPopup != null)
        {
            keyPopup.SetActive(false);
        }
        if(dialogueTrigger != null)
        {
            dialogueTrigger.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(playerlevel.level == 0)
            {
                if(sceneLoad == sceneName[1] || sceneLoad == sceneName[2] || sceneLoad == sceneName[6])
                {
                    //buttonE.SetActive(true);
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                    dialogueTrigger.SetActive(true);
                    GetComponent<AudioSource>().Play();
                }
                else if(sceneLoad == sceneName[0] || sceneLoad == sceneName[5])
                {
                    //buttonE.SetActive(true);
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                    GetComponent<AudioSource>().Play();
                    zoomcamera.ReadyZoom();
                }
                else if(sceneLoad == sceneName[7])
                {
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                }
                else
                {
                    buttonE.SetActive(true);
                    ActiveScene();
                }
            }
            else if(playerlevel.level == 1)
            {
                if(sceneLoad == sceneName[0] || sceneLoad == sceneName[4] || sceneLoad == sceneName[2])
                {
                    //buttonE.SetActive(true);
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                    GetComponent<AudioSource>().Play();
                }
                else if(sceneLoad == sceneName[7])
                {
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                }
                else
                {
                    buttonE.SetActive(true);
                    ActiveScene();
                }
            }
            else if(playerlevel.level >= 2 && playerlevel.level <= 3)
            {
                if(sceneLoad == sceneName[0] || sceneLoad == sceneName[4])
                {
                    //buttonE.SetActive(true);
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                    GetComponent<AudioSource>().Play();
                }
                else if(sceneLoad == sceneName[7])
                {
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                }
                else
                {
                    buttonE.SetActive(true);
                    ActiveScene();
                }
            }
            else if(playerlevel.level == 4)
            {
                if(sceneLoad == sceneName[0])
                {
                    //buttonE.SetActive(true);
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                    GetComponent<AudioSource>().Play();
                }
                else if(sceneLoad == sceneName[4])
                {
                    buttonE.SetActive(true);
                    dialogueTrigger.SetActive(true);
                    ActiveScene();
                }
                else if(sceneLoad == sceneName[7])
                {
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                }
                else
                {
                    buttonE.SetActive(true);
                    ActiveScene();
                }
            }
            else if(playerlevel.level >= 5 && playerlevel.level <= 6)
            {
                if(sceneLoad == sceneName[7])
                {
                    if(keyPopup != null)
                    {
                        keyPopup.SetActive(true);
                    }
                    Debug.Log("SceneBlocked");
                }
                else
                {
                    buttonE.SetActive(true);
                    ActiveScene();
                }
            }
            else
            {
                buttonE.SetActive(true);
                ActiveScene();
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            //PlayerPrefs.DeleteKey("LastSceneBack");
            //Debug.Log("DeleteSceneBack");
            if(keyPopup != null)
            {
                keyPopup.SetActive(false);
            }
            buttonE.SetActive(false);
            controller.readyScene = false;
            //Debug.Log("readyScene"+controller.readyScene);
        }
    }

    private void ActiveScene()
    {
        PlayerPrefs.SetString("LastSceneBack",sceneBack);
        Debug.Log("SetSceneBack : "+sceneBack);
        controller.SceneLoadName(sceneLoad);
        buttonE.SetActive(true);
        controller.readyScene = true;
    }
}
