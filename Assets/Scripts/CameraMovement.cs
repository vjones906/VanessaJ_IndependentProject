using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(followTarget.position.x, 0, 0), transform.position.y, transform.position.z);
    }
}
