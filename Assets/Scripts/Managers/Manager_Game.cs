using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Game : MonoBehaviour
{
    public static Manager_Game instance;

    private void Start()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        PlayMusic();

    }
    public void StartMusic()
    {
        Invoke("PlayMusic", 1);
    }
    public void PlayMusic()
    {

        switch (SceneManager.GetActiveScene().buildIndex)
        {

            case 0:
                // SoundManager.instance.PlaySound("MainMenu");
                SoundManager.instance.StopAllSound();
                SoundManager.instance.PlaySound("Level 1");
                Debug.Log("Level 1 Sound Playing!");
                break;

            case 1:
                //SoundManager.instance.PlaySound("Level 1");
                SoundManager.instance.StopAllSound();
                SoundManager.instance.PlaySound("Level 2");
                Debug.Log("Level 2 Sound Playing!");
                break;

            case 2:
                //SoundManager.instance.PlaySound("Level 2");
                SoundManager.instance.StopAllSound();
                Debug.Log("Main Menu Song Playing!");
                break;

        }

    }
}
