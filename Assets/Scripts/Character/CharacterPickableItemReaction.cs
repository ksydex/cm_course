using System;
using Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterPickableItemReaction : MonoBehaviour
    {
        private CharacterGameMode CharacterGameMode { get; set; }

        public GameObject prefabToSpawn;

        private void Awake()
        {
            CharacterGameMode = GetComponent<CharacterGameMode>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && CharacterGameMode.Score > 0)
            {
                Debug.Log("Mouse");
                SpawnItem();
                CharacterGameMode.Score -= 1;
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
            => PickUpItem(other);

        private void SpawnItem()
        {
            var position = CharacterGameMode.transform.position;
            var toSpawnAt = new Vector3(position.x, position.y + 3, 0);
            Instantiate(prefabToSpawn, toSpawnAt, Quaternion.identity);
        }

        private void PickUpItem(Component other)
        {
            if (other.GetComponent<PickableItem>())
            {
                Debug.Log("kkkkkkkkkkkk");
                Destroy(other.gameObject);
                CharacterGameMode.Score += 1;
            }
        }
    }
}