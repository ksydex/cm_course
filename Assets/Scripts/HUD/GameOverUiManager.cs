using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD
{
    public class GameOverUiManager : MonoBehaviour
    {
        [SerializeField]
        private Text resultText;

        [SerializeField] private Text tableText;
    
        // Start is called before the first frame update
        void Start()
        {
            gameObject.SetActive(false);
        }

        public void Show(bool isWin, int? score = null)
        {
            resultText.text = isWin ? "Победа!" : "Поражение";
            gameObject.SetActive(true);
            
            ResultsManager.current!.Result = isWin;
            ResultsManager.current!.Score = score;
            
            tableText.text = ResultsManager.instance.resultsInText;
            ResultsManager.current = null;
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}