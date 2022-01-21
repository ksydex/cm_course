using HUD;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterEnemyReaction : MonoBehaviour
    {
        private Character Character { get; set; }
        [SerializeField] private AudioClip onDeathAudio;
        [SerializeField] private GameOverUiManager gameOverUiManager;
        
        private void Awake()
        {
            Character = GetComponent<Character>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                OnDeath(other);
                Destroy(Character.gameObject);
            }
        }

        public void OnDeath(Collider2D other)
        {
            var audioSource = other.gameObject.AddComponent<AudioSource>();
            audioSource.clip = onDeathAudio;
            audioSource.Play();
            gameOverUiManager.Show(false);
        }
    }
}