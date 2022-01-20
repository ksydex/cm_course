using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD
{
    public class GameOverUiManager : MonoBehaviour
    {
        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private Text resultText;

        [SerializeField] private Text tableText;

        [SerializeField] private Text headingText;
        [SerializeField] private Text buttonText;

        // Start is called before the first frame update
        void Start()
        {
            gameObject.SetActive(false);
        }

        public void Show(bool isWin, int? score = null)
        {
            var hasNextLevel = levelSettings.NextLevelSceneName != "" && isWin;
            resultText.text = isWin ? "Победа!" : "Поражение";
            gameObject.SetActive(true);

            buttonText.text = hasNextLevel ? "Следующий уровень" : "Начать заново";
            headingText.text = hasNextLevel ? "Уровень пройден" : "Конец игры";
            resultText.text = hasNextLevel ? "" : isWin ? "Победа!" : "Поражение";


            ResultsManager.current!.Result = isWin;
            ResultsManager.current!.Score = isWin ? (ResultsManager.current!.Score ?? 0) + score : null;

            tableText.text = hasNextLevel ? "" : ResultsManager.instance.resultsInText;

            if (!hasNextLevel)
                ResultsManager.current = null;
        }

        public void OnRestartClick()
        {
            var sceneName = ResultsManager.current != null && levelSettings.NextLevelSceneName != ""
                ? levelSettings.NextLevelSceneName
                : "Level1";
            SceneManager.LoadScene(sceneName);
        }
    }
}