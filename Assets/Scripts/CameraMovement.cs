using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    //[SerializeField]
    //private Transform followTarget;
    private float topHeight = 0f;

    void Update()
    {
        if (player.transform.position.y > topHeight)
        {
            topHeight = player.transform.position.y;
        }

        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, 0, 0), Mathf.Clamp(0, topHeight, 0), -50);
    }
}
