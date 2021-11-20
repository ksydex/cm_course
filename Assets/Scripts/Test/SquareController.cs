using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Test;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 minScreenBounds;
    private Vector3 maxScreenBounds;
    
    public float speed = 50.0f;

    protected void  Start()
    {
        const float padding = 30.0f; 
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(padding, padding, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - padding, Screen.height - padding, 0));
        
        transform.position = minScreenBounds;

        
        points = new List<Vector2>
        {
            minScreenBounds,
            new Vector2(minScreenBounds.x, maxScreenBounds.y),
            maxScreenBounds,
            new Vector2(maxScreenBounds.x, minScreenBounds.y),
        };
    }

    private List<Vector2> points;
    private int nextPointIndex = 0;

    // Update is called once per frame
    protected void Update()
    {
        var reachedNextPoint = new Vector2(transform.position.x, transform.position.y) == points[nextPointIndex];
 
        if (reachedNextPoint)
        {
            nextPointIndex++;
            if (nextPointIndex >= points.Count)
            {
                nextPointIndex = 0;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, points[nextPointIndex], speed * Time.deltaTime);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject.FindObjectOfType<SquareSpawnerController>().DecrementAmount();
        }
    }
}
