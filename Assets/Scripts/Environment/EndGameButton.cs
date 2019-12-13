using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    public bool isYes = true;
    // Start is called before the first frame update

    public void buttonPressed()
    {
        if(isYes)
        {
            SceneManager.LoadScene(0);
        }
        if(!isYes)
        {
            Application.Quit();
        }
    }
}
