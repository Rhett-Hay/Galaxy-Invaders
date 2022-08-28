using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    // Speed of the laser
    [SerializeField]
    private float _speed = 8.0f;
    
    // Update is called once per frame
    void Update()
    {
        // Moving the lasers upward with a speed of 8 and in real-time
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // If laser moves greater than 8 on Y-axis
        // destroy game object
        if (transform.position.y >= 8f)
        {
            // Check if the object has a parent
            // If so, destroy the parent with the game object
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
