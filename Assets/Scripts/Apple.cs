using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    //public float appleScore;
    public GameObject applePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //appleScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(applePrefab, new Vector2(Random.Range(-35f, 35f), applePrefab.transform.position.y + (200 + Random.Range(0.2f, 100.0f))), Quaternion.identity);
            //appleScore += 50f;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Instantiate(applePrefab, new Vector2(Random.Range(-35f, 35f), applePrefab.transform.position.y + (200 + Random.Range(0.2f, 100.0f))), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
