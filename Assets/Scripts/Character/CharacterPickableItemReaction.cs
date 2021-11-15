using System;
using Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    [RequireComponent(typeof(Character))]
    public class CharacterPickableItemReaction : MonoBehaviour
    {
        private Character Character { get; set; }

        public GameObject prefabToSpawn;
        
        private void Awake()
        {
            Character = GetComponent<Character>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && Character.itemsCount > 0)
            {
                Debug.Log("Mouse");
                SpawnItem();
                Character.itemsCount--;
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
            => PickUpItem(other);

        private void SpawnItem()
        {
            var position = Character.transform.position;
            var toSpawnAt = new Vector3(position.x, position.y + 3, 0);
            Instantiate(prefabToSpawn, toSpawnAt, Quaternion.identity);
        }
        
        private void PickUpItem(Component other)
        {
            if (other.GetComponent<PickableItem>())
            {
                Destroy(other.gameObject);
                Character.itemsCount++;
            }
        }
    }
}
