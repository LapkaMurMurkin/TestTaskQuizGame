using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestTaskQuizGame
{
    public class WinSceen : MonoBehaviour
    {
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Image _loadingSceen;
        private CanvasGroup _canvasGroup;

        public void Initialize()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.blocksRaycasts = false;

            LevelLoader.GameEnded += ShowWinScreen;

            _restartButton.onClick.AddListener(RestartGame);
        }

        private void OnDestroy()
        {
            LevelLoader.GameEnded -= ShowWinScreen;
        }

        private void ShowWinScreen()
        {
            _canvasGroup.blocksRaycasts = true;
            DOTweenAnimator.FadeInUI(_canvasGroup);
        }

        private void RestartGame()
        {
            _loadingSceen.gameObject.SetActive(true);
            DOTweenAnimator.FadeInUI(_loadingSceen)
            .OnComplete(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}
