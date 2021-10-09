using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterEnemyReaction : MonoBehaviour
    {
        private Character Character { get; set; }
        
        private void Awake()
        {
            Character = GetComponent<Character>();
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Destroy(Character.gameObject);
            }
        }
    }
}
