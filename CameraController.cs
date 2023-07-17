using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject zoom;

    Vector3 targetPos;

    public bool isZoom = false;

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        if(isZoom == true)
        {
            SetLockPos();
        }
        else
        {
            SetTargetPos();
        }
        transform.position = targetPos;
    }

    private void SetTargetPos()
    {
        targetPos.x = player.transform.position.x;
        targetPos.y = player.transform.position.y;
    }

    public void SetLockPos()
    {
        targetPos.x = zoom.transform.position.x;
        targetPos.y = zoom.transform.position.y;
    }
}
