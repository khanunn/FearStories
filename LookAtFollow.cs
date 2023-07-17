using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFollow : MonoBehaviour
{
    public Transform Target;
    float Speed = 1.0f;

    void FixedUpdate()
    {
        transform.LookAt(Target.position);
        transform.Translate(0.0f,0.0f,Speed*Time.deltaTime);
    }
}
