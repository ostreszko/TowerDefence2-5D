using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;   
    }

    public event Action<int> onScoreTrigger;
    public void OnScore(int Amount)
    {
        if(onScoreTrigger != null)
        {
            onScoreTrigger(Amount);
        }
    }

    public event Action<int> onScoreDeplateTrigger;
    public void onScoreDeplate(int Amount)
    {
        if (onScoreDeplateTrigger != null)
        {
            onScoreDeplateTrigger(Amount);
        }
    }

    public event Action<int> onHPDeplateTrigger;
    public void onHPDeplate(int Amount)
    {
        if (onHPDeplateTrigger != null)
        {
            onHPDeplateTrigger(Amount);
        }
    }

    public event Action onNextWaveTrigger;
    public void onNextWave()
    {
        if (onNextWaveTrigger != null)
        {
            onNextWaveTrigger();
        }
    }

    public event Action onNoEnemiesLeftTrigger;
    public void onNoEnemiesLeft()
    {
        if (onNoEnemiesLeftTrigger != null)
        {
            onNoEnemiesLeftTrigger();
        }
    }
}
