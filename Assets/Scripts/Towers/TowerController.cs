using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("SomeShit")]
    public Transform target;
    public string enemyTag = "Enemy";
    public Transform shootingPlace;
    ObjectPooler objectPooler;
    Enemy targetedEnemy;
    public TowerDescription towerProperties;
    GlobalGameMaster ggm;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        InvokeRepeating("UpdateTerget", 0f, 0.5f);
        ggm = GlobalGameMaster.GGM;
    }

    // Update is called once per frame
    void Update()
    {
        //Jeżeli nie ma celu
        if (target == null)
            return;

        //Jeżeli znalazł cel
        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown += 1f / (fireRate * towerProperties.towerSpeedMultiplayer);
        }
        fireCountdown -= Time.deltaTime;
    }

    void UpdateTerget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetedEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
       GameObject projectileGO =  objectPooler.SpawnFromPool("Projectile", shootingPlace.position, shootingPlace.rotation);
        ggm.audioManager.Play("BowShooting");
       ProjectileController projectileController = projectileGO.GetComponent<ProjectileController>();
        if (projectileController != null)
        {
            projectileController.SeekTarget(target, targetedEnemy);
        }
    }
}
