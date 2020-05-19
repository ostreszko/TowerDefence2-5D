using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    NavMeshAgent navMeshAgent;
    public Image healthBar;
    public float maxHp;
    float currentHp;
    LocalGameMaster lgm;
    public int scoreAmount;
    bool targetable = true;

    public enum enemyActions
    {
        Idle = 0,
        Death = 1
    }
    private void OnEnable()
    {
        currentHp = maxHp;
        healthBar.fillAmount = 1f;
        targetable = true;
        gameObject.tag = "Enemy";
        //anim.SetInteger("Action", (int)enemyActions.Idle);
    }
    private void OnDisable()
    {

    }
    private void Awake()
    {

    }
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(transform.position);
        lgm = LocalGameMaster.LGM;
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
        if (currentHp <= 0 && targetable)
        {
            GameEvents.current.OnScore(scoreAmount);
            anim.SetInteger("Action", (int)enemyActions.Death);
            navMeshAgent.isStopped = true;
            targetable = false;
            gameObject.tag = "KilledEnemy";
            
            Invoke("SetEnemyUnactive", 2f);
        }
    }

    void SetEnemyUnactive()
    {
        DeplateEnemyCount();
        gameObject.SetActive(false);
    }

    void DeplateEnemyCount()
    {
        lgm.exisitingEnemiesNumber--;
        if (lgm.exisitingEnemiesNumber <= 0)
            GameEvents.current.onNoEnemiesLeft();
    }

    private void EnemyHasReachedExit()
    {
        GameEvents.current.onHPDeplate(1);
        DeplateEnemyCount();
        gameObject.SetActive(false);
    }
}
