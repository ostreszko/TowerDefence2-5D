﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteHandler : MonoBehaviour
{
    Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(mainCamera.position, Vector3.up); //Obraca się za kamerą
        transform.forward = -mainCamera.forward; // Po prostu obraca w górę
    }
}
