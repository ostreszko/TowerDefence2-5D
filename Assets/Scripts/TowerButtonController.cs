using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonController : MonoBehaviour
{
    LocalGameMaster lgm;    
    public Image selectedButtonSprite;
    List<Image> IsSelectedButtonSprites;

    public void Start()
    {
        lgm = LocalGameMaster.LGM;
        IsSelectedButtonSprites = GameObject.FindGameObjectsWithTag("IsSelectedButtonSprite").Select(x => x.GetComponent<Image>()).ToList();
    }

    public void SetSelectedTower()
    {
        if (lgm.selectedBuildingTag == gameObject.tag)
        {
            lgm.selectedBuildingTag = "";
            selectedButtonSprite.enabled = false;
        }
        else
        {
            IsSelectedButtonSprites.ForEach(x => x.enabled = false);
            lgm.selectedBuildingTag = gameObject.tag;
            selectedButtonSprite.enabled = true;
        }
    }

}
