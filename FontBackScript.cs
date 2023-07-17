using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontBackScript : MonoBehaviour
{
    public GameObject curtain;
    // Start is called before the first frame update
    void Start()
    {
        curtain.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        curtain.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        curtain.SetActive(false);
    }
}
