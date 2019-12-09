using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 Warren - Created the code for the par system and UI display at the end of the level
     
     */
public class ScoreManager : MonoBehaviour
{

    //singleton 
    public static ScoreManager instance;
    public GameObject EndPanel;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //members for counting elements, along with their multipliers
    private int numberOfDeaths;
    private int numberOfRicochets;
    private int numberOfShotsFired;

    public float deathsMultiplier;
    public float ricochetsMultiplier;
    public float shotsFiredMultiplier;

    private int finalScore;

    private bool scoreCalculated = false;


    //methods to count deaths, ricochets, and shots fired
    public void IncrementDeaths()
    {
        numberOfDeaths++;
    }

    public void IncrementRicochets()
    {
        numberOfRicochets++;
    }

    public void IncrementShotsFired()
    {
        numberOfShotsFired++;
    }

    //everything is added together to generate the final score here
    public int TallyFinalScore()
    {
        finalScore = 10000;
        finalScore -= (int)((numberOfDeaths * deathsMultiplier) + (numberOfRicochets * ricochetsMultiplier) + (numberOfShotsFired * shotsFiredMultiplier));
        Debug.Log("Level completion = 10,000");
        Debug.Log("Deaths " + numberOfDeaths.ToString());
        Debug.Log("Ricochets " + numberOfRicochets.ToString());
        Debug.Log("Shots Fired " + numberOfShotsFired.ToString());

        return finalScore;
    }


    //references to display elements for UI display at the end of the level

    public TextMeshProUGUI levelCompletion;
    public TextMeshProUGUI numberOfDeathsText;
    public TextMeshProUGUI numberOfRicochetsText;
    public TextMeshProUGUI numberofBulletsFiredText;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI rankText;

    //resets all values of the score manager
    public void ResetScoreManager()
    {
        numberOfDeaths = 0;
        numberOfRicochets = 0;
        numberOfShotsFired = 0;
        finalScore = 0;
    }

    //sets text on endlevel panel to display score and ranking.
    public void DisplayFinalScore()
    {
        if (scoreCalculated)
            return;

        //TODO: stop the player from moving once the level is over.

        scoreCalculated = true;

        EndPanel.SetActive(true);

        levelCompletion.text = "10,000";
        numberofBulletsFiredText.text = (-numberOfShotsFired * shotsFiredMultiplier).ToString();
        numberOfDeathsText.text = (-numberOfDeaths * deathsMultiplier).ToString();
        numberOfRicochetsText.text  = (-numberOfRicochets * ricochetsMultiplier).ToString();
        finalScoreText.text = finalScore.ToString();


       //Deadeye

       //Average Joe

       //Molasses Man
       
        string finalRank;

        if (finalScore > 7000)
        {
            finalRank = "Deadeye";
        }
        else if (finalScore > 3000)
        {
            finalRank = "Average Joe";
        }
        else
        {
            finalRank = "Molassses Man";
        }

        rankText.text = finalRank;

        ResetScoreManager();
    }
}
