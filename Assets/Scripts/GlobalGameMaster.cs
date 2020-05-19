using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class GlobalGameMaster : MonoBehaviour
    {
        public static GlobalGameMaster GGM;
        public static int loadedLevel = 0;
        [System.NonSerialized]
        public static ClearedLevelsData clearedLevelsData;

        private void Awake()
        {
            if (GGM != null)
            {
                Destroy(GGM);
            }
            else
            {
                GGM = this;
            }
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            clearedLevelsData = SaveSystem.LoadPlayer();
            if (clearedLevelsData == null)
            {
                SaveSystem.SaveLevels(new ClearedLevelsData(new Level[] { new Level(1, false, 0) }));
                clearedLevelsData = SaveSystem.LoadPlayer();
            }
        }
    }
}