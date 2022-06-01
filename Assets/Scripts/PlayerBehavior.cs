using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // private or public access modifier
    // Data types commonly used(int, float, bool, string)
    // every variable must have a name
    // optional - can equal a value   
    [SerializeField]
    private float _speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        // starting position of the player when the game starts.
        transform.position = new Vector3(-20, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
