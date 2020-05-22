using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Assets.Scripts;

public class AreaTowerControllerAttack : MonoBehaviour
{
    ObjectPooler objectPooler;
    public AreaTowerController areaTowerControler; 
    GlobalGameMaster ggm;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        ggm = GlobalGameMaster.GGM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        areaTowerControler.enemiesToDamage.ForEach(x => x.GetComponent<Enemy>().GetHit(1f));
        ggm.audioManager.Play("PseudoExplosion");
        objectPooler.SpawnFromPool("AreaTowerParticle", transform.position, transform.rotation);
    }
}
