using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LockedLevelController : MonoBehaviour
{
    [System.Serializable]
    public class LevelGameObjectButton
    {
        public Button myButton;
        public Image lockedImage;
        public GameObject yyy;
        public int elo;
    }
    public List<LevelGameObjectButton> levelButtonList;
    List<GameObject> levels;
    Image levelLockImage;
    GameObject levelScoreGroup;
    Text highScoreGuiText;


    void Start()
    {
        levels = GameObject.FindGameObjectsWithTag("Level").ToList();
        int levelNumber;
        int nextToUnlock = 1;
        Button levelButton;


        foreach (GameObject level in levels)
        {
            foreach (Transform tran in level.transform)
            {
                if (tran.CompareTag("LockImage"))
                {
                    levelLockImage = tran.GetComponent<Image>();
                }else if (tran.CompareTag("LevelScoreGroup"))
                {
                    levelScoreGroup = tran.gameObject; 
                    foreach(Transform scoreTran in levelScoreGroup.transform)
                    {
                        if (scoreTran.CompareTag("LevelScore"))
                        {
                            highScoreGuiText = scoreTran.gameObject.GetComponent<Text>();
                        }
                    }
                }
            }
            levelButton = level.GetComponent<Button>();
            levelNumber = Convert.ToInt32(level.name.Substring(level.name.Length - 1));
            foreach (Level clearedLevel in GlobalGameMaster.clearedLevelsData.Levels)
            {
                if(clearedLevel.levelNumber == levelNumber && clearedLevel.cleared)
                {
                    nextToUnlock = levelNumber + 1;
                    levelButton.enabled = true;
                    levelLockImage.enabled = false;
                    levelScoreGroup.gameObject.SetActive(true);
                    highScoreGuiText.text = clearedLevel.hiScore.ToString();

                }
            }
            if(nextToUnlock == levelNumber && !levelButton.enabled)
            {
                levelButton.enabled = true;
                levelLockImage.enabled = false;
            }
        }
    }
}

