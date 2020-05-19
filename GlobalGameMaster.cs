using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameMaster : MonoBehaviour
{
    public static GlobalGameMaster GGM;
    public string selectedBuildingTag = "";
    public int exisitingEnemiesNumber = 0;
    public PlayerController playerController;

    private void Awake()
    {
        if (LGM != null)
        {
            GameObject.Destroy(LGM);
        }
        else
        {
            LGM = this;
        }
    }

    private void Start()
    {
        //playerController.Scored += (sender, args) => playerController.scoreObj.AddScore(args.Amount);
    }
}
