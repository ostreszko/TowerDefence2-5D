using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class WaveSpawner : MonoBehaviour
{
    public float countdown = 2f;
    public float timeBetweenWaves = 5f;
    public int enemyWavesToDestroy;
    float waveNumber = 0;
    public int waveEnemiesNumber = 3;
    public float timeBetweenEnemiesSpawn = 0.5f;
    ObjectPooler objectPooler;
    public Text countdownText;
    LocalGameMaster lgm;
    public GameObject nextWaveButton;
    public GameObject winPanel;
    public Text wavesLeft;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        lgm = LocalGameMaster.LGM;
        GameEvents.current.onNextWaveTrigger += NextWaveSpawn;
        GameEvents.current.onNoEnemiesLeftTrigger += NoEnemiesLeft;
        wavesLeft.text = enemyWavesToDestroy.ToString();
    }

    public void NextWave()
    {
        GameEvents.current.onNextWave();
        nextWaveButton.SetActive(false);
    }

    public void NoEnemiesLeft()
    {
        enemyWavesToDestroy--;
        wavesLeft.text = enemyWavesToDestroy.ToString();

        if (enemyWavesToDestroy <= 0)
        {
            winPanel.SetActive(true);
            Level clearedLevel = new Level(GlobalGameMaster.loadedLevel, true, GuiClass.scoreResult);
            bool isAlreadyCleared = false;
            bool biggerHiScore = false;
            foreach(Level level in GlobalGameMaster.clearedLevelsData.Levels)
            {
                if (level.levelNumber == clearedLevel.levelNumber)
                {
                    if (level.cleared)
                    {
                        isAlreadyCleared = true;
                    }

                    if (level.hiScore < clearedLevel.hiScore)
                    {
                        level.hiScore = clearedLevel.hiScore;
                        biggerHiScore = true;
                    }
                }
            }
            if (!isAlreadyCleared)
            {
                Array.Resize(ref GlobalGameMaster.clearedLevelsData.Levels, GlobalGameMaster.clearedLevelsData.Levels.Length + 1);
                GlobalGameMaster.clearedLevelsData.Levels[GlobalGameMaster.clearedLevelsData.Levels.GetUpperBound(0)] = clearedLevel;
            }
            if(!isAlreadyCleared || biggerHiScore)
            {
                SaveSystem.SaveLevels(GlobalGameMaster.clearedLevelsData);
            }


        }
        else
        {
            nextWaveButton.SetActive(true);
        }


    }

    public void NextWaveSpawn()
    {
        StartCoroutine(SpawnWave(waveEnemiesNumber));
        waveEnemiesNumber++;
    } 

    IEnumerator SpawnWave(int enemiesAmount)
    {
        lgm.exisitingEnemiesNumber = enemiesAmount;
        for (int i = 0; i < enemiesAmount; i++)
        {
            SpawnEnemy(enemiesAmount - i);
            yield return new WaitForSeconds(timeBetweenEnemiesSpawn);
        }
        waveNumber++;
    }

    void SpawnEnemy(int enemiesLeftToSpawn)
    {
        GameObject newEnemy;
        if (enemiesLeftToSpawn == 1 && enemyWavesToDestroy == 1)
         newEnemy = objectPooler.SpawnFromPool("Boss", transform.position, transform.rotation);
        else
         newEnemy = objectPooler.SpawnFromEnemiesPoolRandomly(transform.position, transform.rotation);
        newEnemy.transform.position = transform.position;

    }
}
