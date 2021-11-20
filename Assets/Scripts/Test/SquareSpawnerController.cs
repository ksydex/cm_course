using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Test;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareSpawnerController : MonoBehaviour
{
    public GameObject prefab;
    public int amount;
    private int destroyed;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var _ in Enumerable.Range(0, amount))
            Spawn();

        destroyed = amount;
    }

    private void Spawn()
    {
        var obj = Instantiate(prefab, transform.position, Quaternion.identity);
        var controller = obj.GetComponent<SquareController>();
        controller.speed = GetRandomSpeed(5, 50);
    }

    public void DecrementAmount()
    {
        destroyed -= 1;
        if (destroyed == 0)
        {
            Application.Quit();
        }
    }

    private float GetRandomSpeed(float min, float max)
    {
        return Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
    }
}