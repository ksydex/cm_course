using HUD;
using UnityEngine;

namespace Character
{
    public class CharacterGameMode : MonoBehaviour
    {
        private int _score;

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

        private void UpdateUi()
        {
            hudUiManager.UpdateScore(_score);

            if (_score == levelSettings.ScoreToWin)
                gameOverUiManager.Show(true);
        }
    }
}