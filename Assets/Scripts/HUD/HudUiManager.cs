using System;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class HudUiManager : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        [SerializeField] private LevelSettings levelSettings;

        private void Awake()
        {
            UpdateScore(0);
        }

        public void UpdateScore(int currentScore)
        {
            scoreText.text = $"{currentScore} / {levelSettings.ScoreToWin}";
        }
    }
}