using Enemy;
using HUD;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterEnemyReaction : MonoBehaviour
    {
        private Character Character { get; set; }
        [SerializeField] private GameOverUiManager gameOverUiManager;
        
        private void Awake()
        {
            Character = GetComponent<Character>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
                other.gameObject.GetComponent<IEnemy>().OnCharacterCollide(Character);
        }
    }
}