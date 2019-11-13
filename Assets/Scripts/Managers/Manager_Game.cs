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

    public void PlayMusic()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {

            case 0:
                // SoundManager.instance.PlaySound("MainMenu");
                SoundManager.instance.StopAllSound();
                SoundManager.instance.PlaySound("Level 1");
                break;

            case 1:
                //SoundManager.instance.PlaySound("Level 1");
                SoundManager.instance.StopAllSound();
                SoundManager.instance.PlaySound("Level 2");
                break;

            case 2:
                //SoundManager.instance.PlaySound("Level 2");
                SoundManager.instance.StopAllSound();
                SoundManager.instance.PlaySound("MainMenu");
                break;

        }

    }
}
