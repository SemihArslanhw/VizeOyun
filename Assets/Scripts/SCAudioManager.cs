using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCAudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip StartingMusic;
    public AudioClip BossMusic;
    public AudioClip FinishMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = StartingMusic;
        audioSource.Play();
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossMusicStart()
    {
        audioSource.clip = BossMusic;
        audioSource.Play();
        audioSource.loop = true;
    }

    public void BossKilledMusic()
    {
        audioSource.clip = FinishMusic;
        audioSource.Play();
        audioSource.loop = true;
    }
}
