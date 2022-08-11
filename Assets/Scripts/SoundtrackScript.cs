using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] Soundtrack = new AudioClip[13];
    public int ostNum;

    IEnumerator WaitForSongEnd()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        int ost = Random.Range(0, ostNum);
        audioSource.clip = Soundtrack[ost];
        audioSource.Play();
        StartCoroutine(WaitForSongEnd());
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int ost = Random.Range(0, ostNum);
        audioSource.clip = Soundtrack[ost];
        audioSource.Play();
        StartCoroutine(WaitForSongEnd());
    }
}
