using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    // ID numbers for each powerup: 0-Triple Shot, 1-Speed, 2-Shield
    [SerializeField] private int _powerupID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move down the screen at 3 meters per second,
        // when powerup moves offscreen, destroy this game object
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only the player can collect this powerup
        // When this powerup is collected, destroy this object
        if (other.CompareTag("Player"))
        {
            // Communicate with the Player script,
            // and create a handle to the component we need access to
            PlayerBehavior player = other.transform.GetComponent<PlayerBehavior>();

            if (player != null)
            {
                switch (_powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                    default:
                        Debug.Log("Default value!");
                        break;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
