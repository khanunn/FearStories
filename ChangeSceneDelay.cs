using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDelay : MonoBehaviour
{
    public string sceneName;
    public float timeDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene(sceneName));
    }
    IEnumerator NextScene(string sceneName) 
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
