using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private float _x;
    Vector3 position;
    [SerializeField]
    private float _speedIncreaseTimer = 10f;
    [SerializeField]
    private float _speedIncrease = .5f;
    private float _timePassed;

    void Start()
    {
        _x = Random.Range(19.75f, -20.75f);
        transform.position = new Vector3(_x, 10.6f, 0);
    }

    void Update()
    {
        _timePassed = Time.realtimeSinceStartup;
        if (_speedIncreaseTimer < _timePassed)
        {
            _speed += _speedIncrease;
            _speedIncreaseTimer += _speedIncreaseTimer;
        }
        _x = Random.Range(9f, -12f);
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -10.45f)
        {
            transform.position = new Vector3(_x, 10.6f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if( player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }
    }

}
