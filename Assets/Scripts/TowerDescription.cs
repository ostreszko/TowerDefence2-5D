using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerDescription : MonoBehaviour
{
    public int cost;
    public string towerName;
    public int towerLevel;
    public float towerSpeedMultiplayer = 1;
    public Text towerLevelGuiText;
    public GameObject towerCanvas;

    public NodeBuildingController buildedOnNode;

    private void OnEnable()
    {
        towerLevel = 1;
    }

    public void SellTower()
    {
        GameEvents.current.OnScore(cost);
        gameObject.transform.root.gameObject.SetActive(false);
        buildedOnNode.builded = false;
        buildedOnNode.buildedTowerDescription = null;
        buildedOnNode = null;
    }

    public void UpgradeTower()
    {
        if (GuiClass.scoreResult >= (int)(cost / 2))
        {
            towerLevel++;
            towerLevelGuiText.text = towerLevel.ToString();
            GameEvents.current.onScoreDeplate((int)(cost / 2));
            towerSpeedMultiplayer += 0.1f;
        }
    }

    public void CanvasManager()
    {
        towerCanvas.SetActive(!towerCanvas.activeSelf);
    }
    
}
