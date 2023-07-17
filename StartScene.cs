using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public ChangeMap changeMap;
    string[] sceneName = {"Warning","Floor1"};
    int levelStory;

    public void changeScene()
    { 
        levelStory = PlayerPrefs.GetInt("LevelStory");
        Debug.Log("LevelStory = : "+levelStory);

        if(changeMap.SelectedMap == 1)
        {
            StartCoroutine(NextScene(sceneName[0]));
            Debug.Log("เรือนจำแดนใหม่");
        }
        else if(changeMap.SelectedMap == 2)
        {
            if(levelStory == 2)
            {
                StartCoroutine(NextScene(sceneName[1]));
                Debug.Log("วิญญาณหลังกำแพง");
            }
            else
            {
                Debug.Log("เนื้อเรื่องนี้ถูกล็อคอยู่");
            }
        }
    }

    IEnumerator NextScene(string sceneName) 
    {
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.DeleteKey("LastSceneBack");
        PlayerPrefs.DeleteKey("LevelSaved");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void exitScene()
    {
        Application.Quit();
    }
}
