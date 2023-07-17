using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public GameObject player;
    private PlayerLevel playerlevel;

    // Start is called before the first frame update
    void Start()
    {
        playerlevel = player.GetComponent<PlayerLevel>();
    }

    private void Update()
    {
        if(playerlevel.level == 9)
        {
             transform.position = targetPosition;
             transform.rotation = Quaternion.Euler(targetRotation);
        }
    }
}
