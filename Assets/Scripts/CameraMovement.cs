using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    //public Transform background1;
    //public Transform background2;
    //private float size;

    //[SerializeField]
    //private Transform followTarget;
    private float topHeight = 0f;

    void Start()
    {
        //size = background1.GetComponent<BoxCollider2D>().size.y;
    }

    void Update()
    {
        if (player.transform.position.y > topHeight)
        {
            topHeight = player.transform.position.y;
        }

        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, 0, 0), Mathf.Clamp(0, topHeight, 0), -50);
    }

    void FixedUpdate()
    {
        //if (transform.position.y >= background2.position.y)
    }
}
