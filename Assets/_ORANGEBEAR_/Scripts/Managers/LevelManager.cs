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

        private int LevelIndex
        {
            get => PlayerPrefs.GetInt(GameStrings.LevelIndex, 1);
            set => PlayerPrefs.SetInt(GameStrings.LevelIndex, value);
        }

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            _level = levels[LevelIndex - 1];

            if (_level != null)
            {
                Instantiate(_level.LevelPrefab);
            }

            else
            {
                LevelIndex = 1;
                _level = levels[LevelIndex - 1];
                Instantiate(_level.LevelPrefab);
            }

            Roar(GameEvents<object[]>.GetLevelNumber, LevelIndex);
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
            bool status = (bool) obj[0];

            if (status)
            {
                LevelIndex++;
            }
        }

        #endregion
    }
}