using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    public int SelectedMap;
    // Start is called before the first frame update
    void Start()
    {
        SelectedMap = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeMap()
    {
        if(SelectedMap == 1)
        {
            SelectedMap = 2;
            Debug.Log("กำลังเลือกวิญญาณหลังกำแพง");
        }
        else if(SelectedMap == 2)
        {
            SelectedMap = 1;
            Debug.Log("กำลังเลือกเรือนจำแดนใหม่");
        }
    }
}
