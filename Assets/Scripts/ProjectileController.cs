using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f;
    [System.NonSerialized]
    public Transform target;
    [System.NonSerialized]
    public Vector3 dir;
    Enemy targetedEnemy;
    ObjectPooler objectPooler;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget()
    {
        targetedEnemy.GetHit(1f);
        objectPooler.SpawnFromPool("DamageParticle",transform.position,transform.rotation);
        gameObject.SetActive(false);

    }

    public void SeekTarget(Transform _target, Enemy _targetedEnemy)
    {
        target = _target;
        targetedEnemy = _targetedEnemy;
    }
}
