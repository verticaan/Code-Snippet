using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSound : MonoBehaviour
{
    public AudioClip musicClip;   // The audio clip to play

    private AudioSource audioSource;
    private bool isInsideTrigger = false;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isInsideTrigger = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isInsideTrigger = false;
            audioSource.Stop();
        }
    }

    // Optional: You can add a check in the Update() method to stop the sound if the camera is destroyed
    private void Update()
    {
        if (isInsideTrigger && !Camera.main)
        {
            isInsideTrigger = false;
            audioSource.Stop();
        }
    }
}
