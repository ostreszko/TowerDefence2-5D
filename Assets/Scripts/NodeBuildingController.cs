using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeBuildingController : MonoBehaviour
{
    [HideInInspector]
    public bool builded;
    [HideInInspector]
    public TowerDescription buildedTowerDescription;
    public Transform placeToBuild;
    ObjectPooler objectPooler;
    LocalGameMaster lgm;
    
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        lgm = LocalGameMaster.LGM;
    }
    
    private void OnMouseUpAsButton()
    {
        if (!GameEvents.IsPointerOverUIObject())
        {
            if (!builded && lgm.selectedBuildingTag != "" )
            {
                TowerDescription towerDescription = objectPooler.GetGameObjectFromPool(lgm.selectedBuildingTag).GetComponent<TowerDescription>();
                if (towerDescription.cost <= GuiClass.scoreResult)
                {
                    objectPooler.SpawnFromPool(lgm.selectedBuildingTag, placeToBuild.position, placeToBuild.rotation);
                    GameEvents.current.onScoreDeplate(towerDescription.cost);
                    builded = true;
                    towerDescription.buildedOnNode = this;
                    buildedTowerDescription = towerDescription;
                }
            }else if (builded)
            {

            }


        }
    }


}
