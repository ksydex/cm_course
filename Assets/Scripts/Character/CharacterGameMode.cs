using HUD;
using UnityEngine;

namespace Character
{
    public class CharacterGameMode : MonoBehaviour
    {
        private int _score;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                UpdateUi();
            } }

        private void UpdateUi()
        {
            HudManager.Instance.UpdateScore(_score);
        }
    }
}