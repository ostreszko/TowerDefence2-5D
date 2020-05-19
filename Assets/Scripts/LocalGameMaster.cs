using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalGameMaster : MonoBehaviour
{
    public static LocalGameMaster LGM;
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
        GlobalGameMaster.loadedLevel = SceneManager.GetActiveScene().buildIndex;
    }
}
