using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource audioSource;

    private static BackgroundMusic instance = null;
    public static BackgroundMusic Instance
    {
        get { return instance; }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustVolume(float level)
    {
        audioSource.volume = level;
        PlayerPrefs.SetFloat("VolumeLevel", level);
    }
}
