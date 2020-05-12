using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
