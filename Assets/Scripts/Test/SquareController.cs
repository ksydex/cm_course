using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Test;
using UnityEngine;

public class SquareController : BaseController
{
    // Start is called before the first frame update

    private Vector3 minScreenBounds;
    private Vector3 maxScreenBounds;

    public override float speed => 4.0f;

    protected override void  Start()
    {
        const float padding = 30.0f; 
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(padding, padding, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - padding, Screen.height - padding, 0));
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        var currentPos = transform.position;
        
        
        if (currentPos.y > maxScreenBounds.y)
        {
            y = 0;
            x = 1;
        }

        if (currentPos.x > maxScreenBounds.x)
        {
            y = -1;
            x = 0;
        }
        
        if (currentPos.y < minScreenBounds.y)
        {
            y = 0;
            x = -1;
        }
        
        
        // bug is here
        if (currentPos.x < minScreenBounds.x)
        {
            y = 1;
            x = 0;
        }

        base.Update();
    }
}
