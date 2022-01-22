using HUD;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private AudioClip onCollideAudio;

        protected void PlaySound()
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = onCollideAudio;
            audioSource.Play();
        }

        public virtual void OnCharacterCollide(Character.Character character)
        {
            PlaySound();

            var vec = character.transform.position - transform.position;
            var rigidBody = character.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(rigidBody);
            rigidBody.AddForce(vec * 50, ForceMode2D.Impulse);
        }
    }
}