using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiClass
{
    Text scoreText;
    Text hpText;
    public static int scoreResult;
    public int MaxHp;
    public static int currentHp;
    GameObject gameOverPanel;

    public GuiClass(int scoreAmount, Text scoreResult, int maxHp, Text hpText, GameObject GameOverPanel)
    {
        this.scoreText = scoreResult;
        GuiClass.scoreResult = scoreAmount;
        this.MaxHp = maxHp;
        currentHp = maxHp;
        this.hpText = hpText;
        gameOverPanel = GameOverPanel;
    }

    public void SetScore()
    {
        scoreText.text = scoreResult.ToString();
    }

    public void AddScore(int amount)
    {
        scoreResult += amount;
        scoreText.text = scoreResult.ToString();
    }

    public void DeplateScore(int amount)
    {
        scoreResult -= amount;
        scoreText.text = scoreResult.ToString();
    }

    public void DeplateHP(int amount)
    {
        currentHp -= amount;
        hpText.text = currentHp.ToString();
        PlayerDied();
    }

    public void PlayerDied()
    {
        if (currentHp <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void SetHP()
    {
        hpText.text = currentHp.ToString();
    }
}
