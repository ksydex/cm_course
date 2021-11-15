using System;
using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEngine;

public class CircleSpawnerController : MonoBehaviour
{
    public GameObject prefab;
    public bool toRight = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseDown()
    {
        Spawn();   
    }

    private void Spawn()
    {
        var obj = Instantiate(prefab, transform.position, Quaternion.identity);
        var controller = obj.GetComponent<BaseController>();
        controller.y = 0;
        controller.x = toRight ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }
}
