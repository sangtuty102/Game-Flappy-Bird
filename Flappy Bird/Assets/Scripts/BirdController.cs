using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public float lucnhay = 1;
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private GameObject spawnerPipe;


    // Sound
    [SerializeField] // co tac dung de bien private vẫn gọi được  bên unity như là public
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flapSounds, pingSounds, diedSounds;

    //click
    private bool isAlive;
    private bool didFlap;
    public float flag = 0;
    public int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _MakeInstance();
        isAlive = true;
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spawnerPipe = GameObject.Find("SpawnerPipe");
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                rigidBody2D.velocity = Vector2.up * lucnhay;
                audioSource.PlayOneShot(flapSounds);
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    rigidBody2D.velocity = Vector2.up * lucnhay;
        //    audioSource.PlayOneShot(flapSounds);
        //}
        if (rigidBody2D.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, rigidBody2D.velocity.y / 10); // goc bien dong = (rigidBody2D.velocity.y/10) tu 0->90
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        if (rigidBody2D.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -rigidBody2D.velocity.y / 10); // goc bien dong = (rigidBody2D.velocity.y) tu 0->90
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
    public void FlapButton()
    {
        didFlap = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PipeHolder")
        {
            score++;

            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._setScore(score: score);
            }

            audioSource.PlayOneShot(pingSounds);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "BGFloor")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;

                Destroy(spawnerPipe);
                audioSource.PlayOneShot(diedSounds);
                animator.SetTrigger("Died");
                if (GamePlayController.instance != null)
                {
                    GamePlayController.instance._showPanelGameOver(score);
                }
            }
        }
    }
}
