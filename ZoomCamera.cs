using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public Camera mainCamera;
    public float targetSize = 0f;
    public float shrinkDuration = 1f;
    public float expandDuration = 1f;

    private float originalSize;

    [SerializeField] GameObject player;
    PlayerLevel playerlevel;

    CameraController cameracontroller;

    public GameObject keyZoom;

    private bool isZoom = false;

    SceneExit sceneexit;
    string sceneLoad;
    string[] sceneName = {"BedRoom","Nursing","SolitaryRoom"};

    private void Start()
    {
        originalSize = mainCamera.orthographicSize;
        playerlevel = player.GetComponent<PlayerLevel>();
        cameracontroller = mainCamera.GetComponent<CameraController>();
        sceneexit = GetComponent<SceneExit>();
        if(sceneexit != null)
        {
            sceneLoad = sceneexit.sceneLoad;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            /*if(playerlevel.level < 2 || playerlevel.level > 5 && playerlevel.level < 8)
            {
                //cameracontroller.isZoom = true;
                StartCoroutine(ShrinkAndExpand());
            }*/
            if(playerlevel.level == 0)
            {
                if(sceneLoad == sceneName[1])
                {
                    StartCoroutine(ShrinkAndExpand());
                }
            }
            if(playerlevel.level <= 4)
            {
                if(sceneLoad == sceneName[0])
                {
                    cameracontroller.isZoom = true;
                    StartCoroutine(ShrinkAndExpand());
                }
            }
            if(playerlevel.level == 9)
            {
                if(sceneLoad == sceneName[2])
                {
                    cameracontroller.isZoom = true;
                    StartCoroutine(ShrinkAndExpandGhost());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(playerlevel.level == 3)
        {
            //cameracontroller.isZoom = true;
            if(isZoom == false)
            {
                StartCoroutine(GhostShrink());
            }
        }
        else if(playerlevel.level == 4)
        {
            //cameracontroller.isZoom = true;
            if(isZoom == false)
            {
                StartCoroutine(GhostExpand());
            }
        }
    }

    private IEnumerator ShrinkAndExpandGhost()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);
        
        // Shrink the camera to the target size
        float elapsedTime = 0f;
        while (elapsedTime < shrinkDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(originalSize, targetSize, elapsedTime / shrinkDuration);
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        mainCamera.orthographicSize = targetSize;
        GetComponent<AudioSource>().Play();
        Debug.Log("Sound: เฮือก");

        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);

        // Expand the camera back to the original size
        elapsedTime = 0f;
        while (elapsedTime < expandDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(targetSize, originalSize, elapsedTime / expandDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.orthographicSize = originalSize;
        cameracontroller.isZoom = false;
    }

    private IEnumerator ShrinkAndExpand()
    {
        // Shrink the camera to the target size
        float elapsedTime = 0f;
        while (elapsedTime < shrinkDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(originalSize, targetSize, elapsedTime / shrinkDuration);
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        mainCamera.orthographicSize = targetSize;

        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);

        // Expand the camera back to the original size
        elapsedTime = 0f;
        while (elapsedTime < expandDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(targetSize, originalSize, elapsedTime / expandDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.orthographicSize = originalSize;
        cameracontroller.isZoom = false;
    }

    private IEnumerator GhostShrink()
    {
        // Shrink the camera to the target size
        float elapsedTime = 0f;
        while (elapsedTime < shrinkDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(originalSize, targetSize, elapsedTime / shrinkDuration);
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        mainCamera.orthographicSize = targetSize;
        isZoom = true;

        /*// Wait for 2 seconds
        yield return new WaitForSeconds(f);

        // Expand the camera back to the original size
        elapsedTime = 0f;
        while (elapsedTime < expandDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(targetSize, originalSize, elapsedTime / expandDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.orthographicSize = originalSize;
        cameracontroller.isZoom = false;*/
    }

    private IEnumerator GhostExpand()
    {
        // Expand the camera back to the original size
        float elapsedTime = 0f;
        while (elapsedTime < expandDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(targetSize, originalSize, elapsedTime / expandDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.orthographicSize = originalSize;
        cameracontroller.isZoom = false;
        isZoom = true;
    }

    public void ReadyZoom()
    {
        cameracontroller.isZoom = true;
    }
}
