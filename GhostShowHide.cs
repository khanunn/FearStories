using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShowHide : MonoBehaviour
{
    public Transform target;
    public float movementSpeed = 3f;

    private bool isHidden = true;

    private void Update()
    {
        if (!isHidden)
        {
            // เคลื่อนที่ Ghost ไปข้างหน้า
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

            if (transform.position == target.position)
            {
                // ถึงที่หมายแล้วซ่อน Ghost
                HideGhost();
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowGhost()
    {
        isHidden = false;
        gameObject.SetActive(true);
    }

    public void HideGhost()
    {
        isHidden = true;
        gameObject.SetActive(false);
    }
}
