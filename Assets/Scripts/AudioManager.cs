using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;  // Needed for coroutines

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }


    //for adding all one-time sounds
    void Start()
    {
        // Start the coroutine to play the sound after 35 seconds
        StartCoroutine(PlaySoundAfterDelay("wormhole", 36f));

        StartCoroutine(PlaySoundAfterDelay("final_explosion", 30f));
    }

    // Coroutine to play a sound after a specified delay
    IEnumerator PlaySoundAfterDelay(string soundName, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        Play(soundName); // Play the sound
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
