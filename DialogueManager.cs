using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nextText;

    public Animator animator;

    public Queue<string> sentences;
    
    public string sceneLoad;

    public GameObject dialogueBox;

    Controller controller;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(player != null)
        {
            controller = player.GetComponent<Controller>();
        }
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("เริ่มบทสนทนากับ"+ dialogue.name);
        animator.SetBool("IsOpen",true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("NextSentence");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else if(sentences.Count == 1)
        {
            if(nextText != null)
            {
                //nextText.text = "ปิด";
                nextText.text = "Close";
            } 
        }
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        //Debug.Log("จบบทสนทนา");
        animator.SetBool("IsOpen",false);
        Destroy(gameObject);
        if(sceneLoad != "")
        {
            SceneManager.LoadScene(sceneLoad);
        }
        else if(dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }
        if(player != null)
        {
            controller.SetFrozen(false);
        }
    }
}
