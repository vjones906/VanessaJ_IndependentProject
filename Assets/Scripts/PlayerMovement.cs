using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB2D;
    private float movementInput;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementInput = Input.GetAxis("Horizontal");
        playerRB2D.velocity = new Vector2(movementInput * speed, playerRB2D.velocity.y);
    }
}
