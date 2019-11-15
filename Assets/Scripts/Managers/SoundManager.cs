using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
        /*
    Warren Guiles
    SoundManager
    CIS_456_Project_1
    This is a singleton manager that has methods that can be called from anywhere. Contains an array of the "Sound"
    class below, which makes it very easy insert audioclips and modify elements in the inspector.
     */
    
    //static instance for singleton
    public static SoundManager instance;

    //class for each sound has a name, source, clip, volume, and pitch
    [System.Serializable]
    public class Sound
    {

        public string name;

        [HideInInspector]
        public AudioSource source;


        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(0f, 1f)]
        public float pitch;

        public bool shouldLoop;

    }

    //the array of sound classes
    public Sound[] sounds;




    private void Awake()
    {

        //the process of making this class a singleton (if this doesn't exist yet, make it a singleton. Otherwise, destroy this)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        //go through the sounds array and make a new source for each one, and assign that souce 
        //the corresponding source, clip, volume, pitch, and whether or not it should loop
        foreach(Sound s in sounds)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>() as AudioSource;
            s.source = newSource;
            newSource.clip = s.clip;
            newSource.volume = s.volume;
            newSource.pitch = s.pitch;
            newSource.loop = s.shouldLoop;
        }
    }


    //Loops through the array until a sound with the same name 
    //as the string that was passed through is found, and then
    //plays that sound
    public void PlaySound(string clipName)
    {
        foreach (Sound s in sounds)
        {
            if (clipName == s.name)
            {
                s.source.PlayOneShot(s.clip);
            }
        }
    }

    //Loops through the array until a sound with the same name 
    //as the string that was passed through is found, and then
    //plays stops sound
    public void StopSound(string clipName)
    {
        foreach (Sound s in sounds)
        {
            if (clipName == s.name)
            {
                s.source.Stop();
            }
        }
    }

    public void StopAllSound()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    //a string containing the names of all the ricochet sounds
    private string[] RicochetSounds = {"Ricochet1", "Ricochet2", "Ricochet3", "Ricochet4"};

    //this grabs a random string from the RichochetSounds array and passes it
    //into the Playsound method. bullets are going to be bouncing frequently 
    //in our game, so we thought it'd be best to have different sounds
    //to avoid tedium

    public void PlayRandomRicochet()
    {
        int RandomNum = Random.Range(0,4);

        PlaySound(RicochetSounds[RandomNum]);
    }
}
