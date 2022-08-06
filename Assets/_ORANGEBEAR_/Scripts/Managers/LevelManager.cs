#region Header

// Developed by Onur ÖZEL

#endregion

using _ORANGEBEAR_.EventSystem;
using _ORANGEBEAR_.Scripts.GameVariables;
using _ORANGEBEAR_.Scripts.ScriptableObjects;
using UnityEngine;

namespace _ORANGEBEAR_.Scripts.Managers
{
    public class LevelManager : Bear
    {
        #region SerializeFields

        [SerializeField] private Level[] levels;

        #endregion

        #region Private Variables

        private Level _level;
        private int _levelCount;

        private int LevelIndex
        {
            get => PlayerPrefs.GetInt(GameStrings.LevelIndex, 1);
            set => PlayerPrefs.SetInt(GameStrings.LevelIndex, value);
        }

        private int LevelCount
        {
            get => PlayerPrefs.GetInt(GameStrings.LevelCount, 1);
            set => PlayerPrefs.SetInt(GameStrings.LevelCount, value);
        }

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            if (LevelIndex >= levels.Length)
            {
                LevelIndex = 1;
                _level = levels[LevelIndex - 1];
                Instantiate(_level.LevelPrefab);
            }

            else
            {
                _level = levels[LevelIndex - 1];
                Instantiate(_level.LevelPrefab);
            }

            Roar(GameEvents<object[]>.GetLevelNumber, LevelCount);
        }

        #endregion

        #region Event Methods

        private void OnEnable()
        {
            GameEvents<object[]>.OnGameComplete += OnGameComplete;
        }

        private void OnDisable()
        {
            GameEvents<object[]>.OnGameComplete -= OnGameComplete;
        }

        private void OnGameComplete(object[] obj)
        {
            bool status = (bool)obj[0];

            if (!status) return;

            LevelCount++;
            LevelIndex++;
        }

        #endregion
    }
}