using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GuiClass
{
    Text scoreText;
    Text hpText;
    public static int scoreResult;
    public int MaxHp;
    public int currentHp;

    public GuiClass(int scoreAmount, Text scoreResult, int maxHp, Text hpText)
    {
        this.scoreText = scoreResult;
        GuiClass.scoreResult = scoreAmount;
        this.MaxHp = maxHp;
        this.currentHp = maxHp;
        this.hpText = hpText;
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
    }

    public void SetHP()
    {
        hpText.text = currentHp.ToString();
    }
}
