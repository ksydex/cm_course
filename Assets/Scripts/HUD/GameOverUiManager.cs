using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD
{
    public class GameOverUiManager : MonoBehaviour
    {
        [SerializeField]
        private Text resultText;
    
        // Start is called before the first frame update
        void Start()
        {
            gameObject.SetActive(false);
        }

        public void Show(bool isWin)
        {
            resultText.text = isWin ? "Победа!" : "Поражение";
            gameObject.SetActive(true);
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}