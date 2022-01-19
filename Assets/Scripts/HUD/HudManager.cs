using System;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class HudManager : MonoBehaviour
    {
        public static HudManager Instance { get; private set; }

        [SerializeField]
        private Text scoreText;

        private void Awake()
        {
            Instance ??= this;
        }

        public void UpdateScore(int currentScore)
        {
            scoreText.text = $"{currentScore} / {GameSystem.Instance.ScoreToWin}";
        }
    }
}