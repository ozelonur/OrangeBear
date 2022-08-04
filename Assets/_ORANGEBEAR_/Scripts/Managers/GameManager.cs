#region Header

// Developed by Onur ÖZEL

#endregion

using _ORANGEBEAR_.EventSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _ORANGEBEAR_.Scripts.Managers
{
    public class GameManager : Bear
    {
        #region Serialize Fields

        #region Panels

        [Header("Panels")] [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject gameFailPanel;
        [SerializeField] private GameObject gameCompletePanel;

        #endregion

        #region Buttons

        [Header("Buttons")] [SerializeField] private Button startButton;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button nextButton;

        #endregion

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            ActivatePanel(mainMenuPanel);

            startButton.onClick.AddListener(StartGame);
            retryButton.onClick.AddListener(NextLevel);
            nextButton.onClick.AddListener(NextLevel);
        }

        private void OnEnable()
        {
            GameEvents<object[]>.OnGameComplete += OnGameComplete;
        }

        private void OnDisable()
        {
            GameEvents<object[]>.OnGameComplete -= OnGameComplete;
        }

        #endregion

        #region Event Methods

        private void OnGameComplete(object[] obj)
        {
            bool status = (bool) obj[0];

            ActivatePanel(status ? gameCompletePanel : gameFailPanel);
        }

        #endregion

        #region Private Methods

        private void NextLevel()
        {
            SceneManager.LoadScene("Main");
        }

        private void StartGame()
        {
            Roar(GameEvents<object[]>.OnGameStart);
            ActivatePanel(gamePanel);
        }

        private void ActivatePanel(GameObject panel)
        {
            mainMenuPanel.SetActive(false);
            gamePanel.SetActive(false);
            gameFailPanel.SetActive(false);
            gameCompletePanel.SetActive(false);

            panel.SetActive(true);
        }

        #endregion
    }
}