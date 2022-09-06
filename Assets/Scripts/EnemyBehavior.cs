using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Minimum movement along the X-axis
    [SerializeField]
    private float _minX = -9;
    // Maximum movement along the X-axis
    [SerializeField]
    private float _maxX = 9;
    // Handle to Player
    private PlayerBehavior _player;

    EnemyBehavior _enemy;
    Collider2D _collider;
    Animator _anim;
    AudioSource _audioSource;
    [SerializeField] GameObject _thruster;
    [SerializeField] GameObject _enemyExplosion;

    // Start is called before the first frame update
    void Start()
    {
        // Use handle to get the Player's component
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        _enemy = GetComponent<EnemyBehavior>();
        _collider = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        if (_enemy == null)
        {
            Debug.LogError("Enemy script component is NULL!");
        }

        if (_collider == null)
        {
            Debug.LogError("Collider is NULL!");
        }

        if (_anim == null)
        {
            Debug.LogError("Animator is NULL!");
        }

        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is NULL!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // If the Player moves down off-screen,
        // respawn at the top of the screen at a Random X-axis position
        if (transform.position.y <= -6f)
        {
            float randomX = Random.Range(_minX, _maxX);
            transform.position = new Vector3(randomX, 8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // IF other equals the Player's tag
        // Damage the player,
        // AND destroy ourselves
        if (other.CompareTag("Player"))
        {     
            if (_player != null)
            {
                _player.Damage();
            }

            // Use the Animator's OnPlayerDeath trigger.
            _anim.SetTrigger("OnPlayerDeath");
            _thruster.SetActive(false);
            // Turn the enemies speed off.
            _speed = 0;
            // Play explosion sound
            _audioSource.Play();
            // Destroy the Enemy's script component.
            Destroy(_enemy);
            Destroy(this.gameObject, 2.8f);
        }
        // IF other equals Laser tag
        // Destroy Laser and ourselves
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            // Add 20 points to player
            if (_player != null)
            {
                _player.AddScore(20);
            }

            _anim.SetTrigger("OnPlayerDeath");
            _thruster.SetActive(false);
            _speed = 0;
            _audioSource.Play();
            Destroy(_enemy);
            // Destroy the Enemy's collider component.
            Destroy(_collider);
            Destroy(this.gameObject, 2.8f);
        }
    }
}
