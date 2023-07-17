using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int sceneName;
    private int sceneSave;
    private string sceneCurrenName;
    Controller controller;
    [SerializeField] GameObject player;

    public GameObject buttonE;

    private int sceneToContinue;
    private void Awake() 
    {
        controller = player.GetComponent<Controller>();
        buttonE.SetActive(false);
    }
    private void Update() 
    {
        if(controller.letScene == true)
        {
            sceneSave = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene",sceneSave);
            Debug.Log("SavedScene"+sceneSave);
            //Debug.Log("LoadScene");
            //Debug.Log("ChangeScene"+sceneName);
            //sceneToContinue = PlayerPrefs.GetInt("SavedScene");
            SceneManager.LoadScene(sceneName);
            Debug.Log("ChangeScene"+sceneName);
            /*if(sceneToContinue == sceneCurrenName)
            {
                SceneManager.LoadScene(sceneToContinue, LoadSceneMode.Single);
                Debug.Log("ChangeSceneToContinue"+sceneToContinue);
            }
            else
            {
                SceneManager.LoadScene(sceneCurrenName, LoadSceneMode.Single);
                Debug.Log("ChangeSceneCurren"+sceneCurrenName);
            }*/
            //SceneManager.LoadScene(sceneCurrenName, LoadSceneMode.Single);
            controller.letScene = false;
            controller.readyScene = false;
            //Debug.Log("LetScene:"+controller.letScene);
            //Debug.Log("ReadyScene:"+controller.readyScene);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            //sceneCurrenName = sceneName;
            //Debug.Log("NextScene"+sceneCurrenName);
            buttonE.SetActive(true);
            controller.readyScene = true;
            /*if(sceneCurrenName != "Floor1")
            {
                PlayerPrefs.SetString("SavedScene",sceneSave);
                Debug.Log("SavedScene"+sceneSave);
            }  */
            //Debug.Log("readyScene"+controller.readyScene);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            buttonE.SetActive(false);
            controller.readyScene = false;
            //Debug.Log("readyScene"+controller.readyScene);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        Debug.Log("SavedScene"+sceneSave);
    }
}
