using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzicZone : MonoBehaviour
{

    public AudioSource audiosource;
    public float fadeTime;
    private float targetVolume;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume = 1.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume = 0.0f;
        }
    }

    void Start()
    {
        targetVolume = 0.0f;
        audiosource.volume = 0.0f;
    }

  
    void Update()
    {
       
        audiosource.volume = Mathf.MoveTowards(audiosource.volume, targetVolume,(1.0f / fadeTime) * Time.deltaTime);
    }
}
