using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(gameOverSound, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
