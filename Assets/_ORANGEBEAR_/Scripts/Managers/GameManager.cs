#region Header

// Developed by Onur ÖZEL

#endregion

using _ORANGEBEAR_.EventSystem;
using _ORANGEBEAR_.Scripts.Enums;
using UnityEngine.SceneManagement;

namespace _ORANGEBEAR_.Scripts.Managers
{
    public class GameManager : Bear
    {
        #region Public Variables

        public static GameManager Instance;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void OnEnable()
        {
            GameEvents<object[]>.NextLevel += NextLevel;
            GameEvents<object[]>.OnGameComplete += OnGameComplete;
        }

        private void OnDisable()
        {
            GameEvents<object[]>.NextLevel -= NextLevel;
            GameEvents<object[]>.OnGameComplete -= OnGameComplete;
        }

        #endregion

        #region Event Methods

        private void NextLevel(object[] args)
        {
            SceneManager.LoadScene("Main");
        }

        private void OnGameComplete(object[] obj)
        {
            bool status = (bool) obj[0];
            Roar(GameEvents<object[]>.ActivatePanel,
                status ? PanelsEnums.GameWin : PanelsEnums.GameOver);
        }

        #endregion
    }
}