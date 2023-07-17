using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueShow : MonoBehaviour
{
    public Dialogue dialogue;
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextShow());
    }
    IEnumerator NextShow() 
    {
        yield return new WaitForSeconds(delayTime);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
