using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectAudio : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Debug.Log("clips.length = " + clips.Length);
        source.clip = clips[Random.Range(0, clips.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.Play();
    }
}
