using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    NavMeshAgent navMeshAgent;
    public Image healthBar;
    public float maxHp;
    float currentHp;
    LocalGameMaster lgm;
    public int scoreAmount;
    private void OnEnable()
    {
        currentHp = maxHp;
        healthBar.fillAmount = 1f;
    }
    private void OnDisable()
    {
        lgm.exisitingEnemiesNumber--;
        if (lgm.exisitingEnemiesNumber <= 0)
            GameEvents.current.onNoEnemiesLeft();
    }
    private void Awake()
    {
        lgm = LocalGameMaster.LGM;
    }
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            EnemyHasReachedExit();
        }
    }


    public void GetHit(float damage)
    {
        currentHp -= damage;
        healthBar.fillAmount = currentHp / maxHp;
        if (currentHp <= 0)
        {
            GameEvents.current.OnScore(scoreAmount);
            gameObject.SetActive(false);
        }
    }

    private void EnemyHasReachedExit()
    {
        GameEvents.current.onHPDeplate(1);
        gameObject.SetActive(false);
    }
}
