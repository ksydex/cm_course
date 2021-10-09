using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    public class CharacterEnemyReaction : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
