using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    private Vector2 movement;
    private float inputX;
    private float inputY;
    private Animator animator;

    public bool readyScene = false;
    public bool letScene = false;
    private string sceneLoad;

    public PlayerLevel playerlevel;
    public bool readyGet;
    public bool letGet;
    public bool readySwitch;
    public bool letSwitch;
    public bool readyDrop;
    public bool letDrop;
    public bool readyWish;
    public bool letWish;

    //lvl9
    public bool readyPutdown;
    public bool letPutdown;
    public bool readyToSeeGhost;
    //-----------------------------//

    private bool isFrozen = false;
    public AudioClip[] sounds;
    //public AudioClip walkSound;
    //public AudioClip runSound;
    private AudioSource audiosource;
    public AudioSource walkSound; // สร้าง AudioSource เพื่อให้มีเสียงเดิน
    public AudioSource shiftSound; // สร้าง AudioSource เพื่อให้มีเสียงวิ่ง

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Move", false);
        playerlevel = GetComponent<PlayerLevel>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!isFrozen)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if(playerlevel.level == 9)
                {
                    speed.x = 6;
                    speed.y = 3;
                    animator.SetBool("Run", true);
                    if (!shiftSound.isPlaying)
                    {
                        shiftSound.Play();
                    }
                }
                else if(playerlevel.level == 10)
                {
                    animator.SetBool("Crawl", true);
                    speed.x = 1;
                    speed.y = 1;
                }
            }
            else if(playerlevel.level == 10)
            {
                animator.SetBool("Crawl", true);
                speed.x = 1;
                speed.y = 1;
            }
            else
            {
                animator.SetBool("Crawl", false);
                animator.SetBool("Run", false);
                speed.x = 2;
                speed.y = 1;
                if (!walkSound.isPlaying && (inputX != 0 || inputY != 0))
                {
                    walkSound.Play();
                }
            }

            if (inputX != 0)
            {
                animator.SetBool("Move", true);
                animator.SetBool("Homage",false);
            }

            if (inputX < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (inputX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (inputY != 0)
            {
                animator.SetBool("Move", true);
                animator.SetBool("Homage",false);
            }
            else
            {
                walkSound.Pause();
                animator.SetBool("Move", false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (readyScene == true)
                {
                    letScene = true;
                    SceneManager.LoadScene(sceneLoad);
                    //Debug.Log ("LetScene:"+letScene);
                }
                if(readyGet == true)
                {
                    LevelLoad(1);
                    SetFrozen(true);
                    playerlevel.getLevel = true;
                    readyGet = false;
                }
                if(readySwitch == true)
                {
                    letSwitch = true;
                    //readySwitch = false;
                }
                if(readyDrop == true)
                {
                    letDrop = true;
                }
                if(readyWish == true)
                {
                    letWish = true;
                }
                if(readyPutdown == true)
                {
                    letPutdown = true;
                }
            }
        }
        else
        {
            speed.x = 0;
            speed.y = 0;
            GetComponent<AudioSource> ().Pause();
            animator.SetBool("Move", false);

            if(playerlevel.level == 14)
            {
                animator.SetBool("Homage",true);
            }
            else
            {
                animator.SetBool("Homage",false);
            }
        }
    }

    void FixedUpdate()
    {
        if(!isFrozen)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
            movement = new Vector2(speed.x * inputX, speed.y * inputY);
            GetComponent<Rigidbody2D>().velocity = movement;
        }
        else
        {
            movement = new Vector2(speed.x * inputX, speed.y * inputY);
            GetComponent<Rigidbody2D>().velocity = movement;
        }
    }

    public void SceneLoadName(string sceneName)
    {
        sceneLoad = sceneName;
        Debug.Log("SceneLoad = "+sceneLoad);
    }

    public void LevelLoad(int loadLevel)
    {
        playerlevel.level += loadLevel;
        Debug.Log("LevelUp : "+playerlevel.level);
        PlayerPrefs.SetInt("LevelSaved",playerlevel.level);
    }

    public void SetFrozen(bool freeze)
    {
        isFrozen = freeze;
    }
}
