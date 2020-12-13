using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement playerMov;
    private Rigidbody2D playerRB2D;

    private AudioSource audioSource;
    public AudioClip ripSound;
    public AudioClip appleSound;

    public GameObject fakePrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerMov = player.GetComponent<PlayerMovement>();
        playerRB2D = player.GetComponent<Rigidbody2D>();
        audioSource = player.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            audioSource.PlayOneShot(appleSound, 0.75f);
            playerMov.UpdateScore(20);
        }

        if (playerRB2D.velocity.y <= 0)
        {
            if (collision.gameObject.CompareTag("PlatformFake"))
            {
                audioSource.PlayOneShot(ripSound, 0.75f);
                Destroy(collision.gameObject);
                playerMov.UpdateScore(-10);
                Instantiate(fakePrefab, new Vector2(Random.Range(-35f, 35f), player.transform.position.y + (45 + Random.Range(0.75f, 5.0f))), Quaternion.identity);
            }
        }
    }
}
