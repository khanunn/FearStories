using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostEnemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;

    Rigidbody2D rb;

    Transform target;

    Vector2 moveDirection;

    public string sceneLoadName;

    public Animator animator;

    public int hitsNeeded = 20;

    private int hits = 0;

    private bool hitGhost = false;

    [SerializeField]
    GameObject player;

    Controller controller;

    PlayerLevel playerlevel;

    //public SceneExit sceneexit;
    //string[] sceneName = {"SolitaryRoom"};
    public string sceneBack;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            controller = player.GetComponent<Controller>();
            playerlevel = player.GetComponent<PlayerLevel>();
        }
        if (PlayerPrefs.GetInt("ReadyToSeeGhost") == 1)
        {
            StartCoroutine(DelayedTargetSetting(5f));
            controller.SetFrozen(true);
        }
        else
        {
            target = GameObject.Find("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector2 direction =
                (target.position - transform.position).normalized;

            //float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
            //rb.rotation = transform.eulerAngles;
            moveDirection = direction;
            if (moveDirection.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (moveDirection.x > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        if (hitGhost)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hits++;
                if (hits >= hitsNeeded)
                {
                    controller.SetFrozen(false);
                    hits = 0;
                    animator.SetBool("IsHit", false);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity =
                new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (playerlevel.level == 9)
            {
                controller.SetFrozen(true);
                animator.SetBool("IsHit", true);
                hitGhost = true;
            }
            else if (playerlevel.level == 10)
            {
                animator.SetBool("IsOpen", true);
                StartCoroutine(DelayedLoadScene(3f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hitGhost = false;
            //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    IEnumerator DelayedTargetSetting(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        controller.SetFrozen(false);
        target = GameObject.Find("Player").transform;
        controller.readyToSeeGhost = false;
        PlayerPrefs.SetInt("ReadyToSeeGhost", controller.readyToSeeGhost ? 1 : 0);
        Debug.Log("ReadyToSeeGhost :"+controller.readyToSeeGhost);
    }

    IEnumerator DelayedLoadScene(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        PlayerPrefs.SetString("LastSceneBack", sceneBack);
        Debug.Log("SetSceneBack : " + sceneBack);
        SceneManager.LoadScene (sceneLoadName);
        controller.LevelLoad(1);
    }
}
