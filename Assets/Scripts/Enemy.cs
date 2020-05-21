using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Transform StartPostition;
    Transform endPosition;
    public Animator anim;
    NavMeshAgent navMeshAgent;
    public Image healthBar;
    public float maxHp;
    float currentHp;
    LocalGameMaster lgm;
    public int scoreAmount;
    bool targetable = true;

    string endTag = "End";
    string startTag = "Start";

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
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartPostition = GameObject.FindGameObjectWithTag(startTag).transform;
        endPosition = GameObject.FindGameObjectWithTag(endTag).transform;
        transform.position = StartPostition.position;
    }

    void Start()
    {
        lgm = LocalGameMaster.LGM;
    }

    void Update()
    {
        navMeshAgent.SetDestination(endPosition.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(endTag))
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
