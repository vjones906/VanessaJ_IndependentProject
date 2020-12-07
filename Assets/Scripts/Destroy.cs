using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject boostPrefab;
    public GameObject fakePrefab;
    //private GameObject newPlatform;

    //private EventManager eventManager;

    void Start()
    {
        //eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformNormal"))
        {
            if(Random.Range(1, 7) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(boostPrefab, new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (35 + Random.Range(0.75f, 1.0f))), Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (35 + Random.Range(0.75f, 1.0f)));
            }
        }
        else if(collision.gameObject.CompareTag("PlatformBoost"))
        {
            if (Random.Range(1, 7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (35 + Random.Range(0.75f, 1.0f)));
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (35 + Random.Range(0.75f, 1.0f))), Quaternion.identity);
            }
        }
        else if (collision.gameObject.CompareTag("PlatformFake"))
        {
            Destroy(collision.gameObject);
            Instantiate(fakePrefab, new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (35 + Random.Range(0.75f, 5.0f))), Quaternion.identity);
        }
        else if (collision.gameObject.CompareTag("PlatformEnemy"))
        {
            Destroy(collision.gameObject);
            
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Game Over");
            //eventManager.gameOverEvent?.Invoke();
        }
    }
}
