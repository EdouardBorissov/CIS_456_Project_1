using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource[] audioSources;

    [Range(0,1)]
    public float volume;
    public bool loop;

    private void OnEnable()
    {
        GameObject[] sms = GameObject.FindGameObjectsWithTag("SoundManager");
        if (sms.Length != 1) Destroy(gameObject);
        

        DontDestroyOnLoad(gameObject);
        {
            foreach (AudioClip ac in audioClips)
            {
                AudioSource ass = gameObject.AddComponent<AudioSource>();
                ass.clip = ac;
            }

            audioSources = GetComponents<AudioSource>();
            foreach (AudioSource ass in audioSources)
            {
                ass.volume = volume;
                ass.loop = loop;
            }
        }
    }
    public void PlaySound(string name)
    {
        foreach(AudioSource ass in audioSources)
        {
            if (ass.clip.name == name)
            {
                ass.Play();
                return;
            }
        }
        Debug.LogWarning("No sound called " + name);
    }

    public void Shush()
    {
        foreach(AudioSource ass in audioSources)
        {
            if (ass.isPlaying)
            {
                ass.Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
