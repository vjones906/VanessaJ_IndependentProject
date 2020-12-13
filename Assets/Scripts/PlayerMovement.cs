using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB2D;
    private float movementInput;
    public float speed = 10f;
    public GameObject player;

    public Text scoreText;
    private float topScore = 0f;
    private float overallScore = 0f;
    public float appleScore = 0f;
    public float fakePlatScore = 0f;

    private EventManager eventManager;

    public bool gameOver;
    public bool isActive;

    public GameObject fakePrefab;

    private GameObject camera;
    private float lowerBoundary;

    public Animator anim;

    private AudioSource audioSource;
    public AudioClip ripSound;
    public AudioClip appleSound;

    Material material;
    bool isDissolving = false;
    float fade = 0f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        playerRB2D = GetComponent<Rigidbody2D>();
        lowerBoundary = camera.transform.position.y - 30;

        gameOver = false;
        isActive = true;

        audioSource = GetComponent<AudioSource>();

        material = GetComponent<SpriteRenderer>().material;

        isDissolving = true;
    }

    void Update()
    {
        if (isDissolving)
        {
            fade += Time.deltaTime;

            if (fade >= 1f)
            {
                fade = 1f;
                isDissolving = false;
            }
        }

        material.SetFloat("_Fade", fade);

        lowerBoundary = camera.transform.position.y - 30;

        if (playerRB2D.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = (transform.position.y / 10);
        }

        scoreText.text = "Score: " + Mathf.Round(topScore + overallScore).ToString();

        if (transform.position.y < lowerBoundary && gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over normal");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void UpdateScore(float Addition)
    {
        overallScore += Addition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //appleScore = GameObject.FindWithTag("Apple").GetComponent<Apple>().appleScore;

        movementInput = Input.GetAxis("Horizontal");
        playerRB2D.velocity = new Vector2(movementInput * speed, playerRB2D.velocity.y);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -39, 39), transform.position.y);

        if (movementInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (movementInput > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (playerRB2D.velocity.y > 0.1)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            audioSource.PlayOneShot(appleSound, 0.75f);
            appleScore += 50;
        }

        if (playerRB2D.velocity.y <= 0)
        {
            if (collision.gameObject.CompareTag("PlatformFake"))
            {
                audioSource.PlayOneShot(ripSound, 0.75f);
                Destroy(collision.gameObject);
                fakePlatScore -= 5;
                Instantiate(fakePrefab, new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (45 + Random.Range(0.75f, 5.0f))), Quaternion.identity);
            }
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("Game Over");
            //eventManager.gameOverEvent?.Invoke();
        }
        
    }
}
