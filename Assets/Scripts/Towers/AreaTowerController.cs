using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTowerController :MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("SomeShit")]
    public string enemyTag = "Enemy";
    [System.NonSerialized]
    public List <GameObject> enemiesToDamage = new List<GameObject>();
    public Animator anim;
    public TowerDescription towerDescription;

    void Start()
    {
        InvokeRepeating("UpdateTerget", 0f, 0.5f);
        anim.SetFloat("Speed", 0.25f  );
    }

    // Update is called once per frame
    void Update()
    {
        //Jeżeli nie ma celu
        if (enemiesToDamage.Count == 0)
        {
            anim.SetInteger("TowerAction", 0);
            return;
        }
            

        //Jeżeli znalazł cel
        if (fireCountdown <= 0)
        {
            anim.SetInteger("TowerAction",1);
            fireCountdown += 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void UpdateTerget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        enemiesToDamage.Clear();
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
            if (distanceToEnemy < range)
            {
                enemiesToDamage.Add(enemy);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void UpgradeSpeed()
    {
        anim.SetFloat("Speed", anim.GetFloat("Speed") + 0.1f);
    }

}
