using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour
{
    public float moveSpeed; //helps me adjust the speed of the enemy movement without code
    
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) // ontrigger for an object it touches
    {
        if (collision.gameObject.tag == "Boundary") //added a tag called "Boundary" to ensure the satellites detect only the borders
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z); //satellites move down after colliding with either border
            moveSpeed *= -1; //after collision, on either border, the satellites will change direction to the other side
        }

        if (collision.gameObject.tag =="DesBoundary") // Satellite destroys when it gets to the lower border
        {
            Destroy(gameObject);
        }
        
    }
}
