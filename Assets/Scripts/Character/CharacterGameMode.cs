using System;
using HUD;
using UnityEngine;

namespace Character
{
    public class CharacterGameMode : MonoBehaviour
    {
        private int _score;
        private float timeLeft = 20.0f;

        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private HudUiManager hudUiManager;
        [SerializeField] private GameOverUiManager gameOverUiManager;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                UpdateUi();
            }
        }

        private void Update()
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0) gameOverUiManager.Show(false);
            }
        }

        private void UpdateUi()
        {
            hudUiManager.UpdateScore(_score);

            if (_score == levelSettings.ScoreToWin)
            {
                gameOverUiManager.Show(true, _score);
            }
        }
    }
}