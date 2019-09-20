using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


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

    public Sound[] sounds;

    private string[] RicochetSounds = {"Ricochet1", "Ricochet2", "Ricochet3", "Ricochet4"};


    private void Awake()
    {


        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
            PlaySound("ambientMusic");

    }


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

    public void StopStound(string clipName)
    {
        foreach (Sound s in sounds)
        {
            if (clipName == s.name)
            {
                s.source.Stop();
            }
        }
    }

    public void PlayRandomRicochet()
    {
        int RandomNum = Random.Range(0,4);

        PlaySound(RicochetSounds[RandomNum]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
