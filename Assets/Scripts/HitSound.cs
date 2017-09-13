using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour {

    public AudioSource MusicSource;
    public AudioClip MusicClip;

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "Ball(Clone)")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
        }
    }

    // Use this for initialization
    void Start () {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.8f, 1.5f);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
	}
}
