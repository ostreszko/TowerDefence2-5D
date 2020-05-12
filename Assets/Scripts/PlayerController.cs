using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHp;
    public Text scoreText;
    public Text hpText;
    public GuiClass guiClassObj;
    public int startGold;
    // Start is called before the first frame update
    void Start()
    {
        guiClassObj = new GuiClass(startGold, scoreText, maxHp, hpText);
        guiClassObj.SetScore();
        guiClassObj.SetHP();
        GameEvents.current.onHPDeplateTrigger += guiClassObj.DeplateHP;
        GameEvents.current.onScoreTrigger += guiClassObj.AddScore;
        GameEvents.current.onScoreDeplateTrigger += guiClassObj.DeplateScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

