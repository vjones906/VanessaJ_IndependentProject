using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB2D;
    private float movementInput;
    public float speed = 10f;
    public GameObject player;

    public Text scoreText;
    private float topScore = 0f;

    private EventManager eventManager;

    public bool gameOver;
    public bool isActive;

    public GameObject fakePrefab;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        playerRB2D = GetComponent<Rigidbody2D>();

        gameOver = false;
        isActive = true;
    }

    void Update()
    {
        if(playerRB2D.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y / 8;
        }

        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementInput = Input.GetAxis("Horizontal");
        playerRB2D.velocity = new Vector2(movementInput * speed, playerRB2D.velocity.y);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -39, 39), transform.position.y);

        if (movementInput < 0.1)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerRB2D.velocity.y <= 0)
        {
            if (collision.gameObject.CompareTag("PlatformFake"))
            {
                Destroy(collision.gameObject);
                Instantiate(fakePrefab, new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (45 + Random.Range(0.2f, 5.0f))), Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("Game Over");
            //eventManager.gameOverEvent?.Invoke();
        }
    }
}
