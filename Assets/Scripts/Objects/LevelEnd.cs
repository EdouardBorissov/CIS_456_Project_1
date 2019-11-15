using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEnd : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            int finalScore = ScoreManager.instance.TallyFinalScore();

            Debug.Log(finalScore.ToString());
            
            ScoreManager.instance.DisplayFinalScore();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Manager_Game.instance.StartMusic();
    }
}
