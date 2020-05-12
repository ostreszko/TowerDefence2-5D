using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    ParticleSystem thisParticleSystem;

    private void Awake()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        thisParticleSystem.Play();
        Invoke("DeactivateParticle", thisParticleSystem.main.duration);
    }
    void DeactivateParticle()
    {
        gameObject.SetActive(false);
    }
}
