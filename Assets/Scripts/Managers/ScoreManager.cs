using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreManager instance;

    [HideInInspector]
    public int bulletsFired;

    public int bulletsFiredMultiplier;

    [HideInInspector]
    public int ricochets;

    public int ricochetMultiplier;

    [HideInInspector]
    public int deaths;

    public int deathMultiplier;
    
    private int finalScore;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void tallyScore()
    {
        finalScore = (bulletsFired * bulletsFiredMultiplier) + (ricochets * ricochetMultiplier) - (deaths * deathMultiplier);
    }
}
