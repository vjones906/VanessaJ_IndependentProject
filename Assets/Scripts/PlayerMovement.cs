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

    // Start is called before the first frame update
    void Start()
    {
        playerRB2D = GetComponent<Rigidbody2D>();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(player.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            if (collision.gameObject.name.StartsWith("Fake"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
