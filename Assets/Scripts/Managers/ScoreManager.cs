using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject EndPanel;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private int numberOfDeaths;
    private int numberOfRicochets;
    private int numberOfShotsFired;

    public float deathsMultiplier;
    public float ricochetsMultiplier;
    public float shotsFiredMultiplier;

    private int finalScore;

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

    public TextMeshProUGUI levelCompletion;
    public TextMeshProUGUI numberOfDeathsText;
    public TextMeshProUGUI numberOfRicochetsText;
    public TextMeshProUGUI numberofBulletsFiredText;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI rankText;

    public void ResetScoreManager()
    {
        numberOfDeaths = 0;
        numberOfRicochets = 0;
        numberOfShotsFired = 0;
        finalScore = 0;
    }

    public void DisplayFinalScore()
    {
        EndPanel.SetActive(true);

        levelCompletion.text = "10,000";
        numberofBulletsFiredText.text = (-numberOfShotsFired * shotsFiredMultiplier).ToString();
        numberOfDeathsText.text = (-numberOfDeaths * deathsMultiplier).ToString();
        numberOfRicochetsText.text  = (-numberOfRicochets * ricochetsMultiplier).ToString();
        finalScoreText.text = finalScore.ToString();

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

//Deadeye

//Average Joe

//Molasses Man