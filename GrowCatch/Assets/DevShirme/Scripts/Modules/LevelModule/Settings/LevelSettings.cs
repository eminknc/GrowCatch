using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "DevShirme/Settings/Level Settings", order = 1)]
    public class LevelSettings : ScriptableObject
    {
        #region Fields
        [Header("Level Settings Fields")]
        [SerializeField] private List<Level> levels;
        #endregion

        #region Getters
        public Level GetLevel()
        {
            int index = (DataManager.PlayerDataSet.MyData.Level - 1) % levels.Count;
            GameManager.OnLevelCreated?.Invoke(DataManager.PlayerDataSet.MyData.Level);
            return levels[index];
        }
        #endregion
    }
}
