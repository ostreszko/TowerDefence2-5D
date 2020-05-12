using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public float countdown = 2f;
    public float timeBetweenWaves = 5f;
    float waveNumber = 0;
    public int waveEnemiesNumber = 3;
    public float timeBetweenEnemiesSpawn = 0.5f;
    ObjectPooler objectPooler;
    public Text countdownText;
    LocalGameMaster lgm;
    public GameObject nextWaveButton;


    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        lgm = LocalGameMaster.LGM;
        GameEvents.current.onNextWaveTrigger += NextWaveSpawn;
        GameEvents.current.onNoEnemiesLeftTrigger += NoEnemiesLeft;
    }


    public void NextWave()
    {
        GameEvents.current.onNextWave();
        nextWaveButton.SetActive(false);
    }

    public void NoEnemiesLeft()
    {
        nextWaveButton.SetActive(true);
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
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemiesSpawn);
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
       //GameObject newEnemy = objectPooler.SpawnFromPool("NormalEnemy", transform.position, transform.rotation);
        GameObject newEnemy = objectPooler.SpawnFromEnemiesPoolRandomly(transform.position, transform.rotation);
        newEnemy.transform.position = transform.position;
    }
}
