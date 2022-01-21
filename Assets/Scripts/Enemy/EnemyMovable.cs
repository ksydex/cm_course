using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovable : Enemy
    {
        [SerializeField] private Transform leftPoint;
        [SerializeField] private Transform rightPoint;

        private Vector2 left;
        private Vector2 right;

        private Vector2 moveTo;
        
        private void Awake()
        {
            moveTo = left = new Vector2(leftPoint.position.x, leftPoint.position.y);
            right = new Vector2(rightPoint.position.x, rightPoint.position.y);
        }

        private void Update()
        {
            var position = transform.position;
            if (position.x == moveTo.x)
                moveTo = moveTo == left ? right : left;

            transform.position =
                Vector3.MoveTowards(transform.position, new Vector2(moveTo.x, moveTo.y),
                    1.0f * Time.deltaTime);
        }
    }
}