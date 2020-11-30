using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip gameStartSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(gameStartSound, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
