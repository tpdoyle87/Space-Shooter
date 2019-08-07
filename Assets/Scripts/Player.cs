using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 2f;
    [SerializeField]
    private float _canFire = -1f;
    [SerializeField]
    private float _hitCount = 3f;
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private bool _tripleshotActive = false;
void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.Log("Spawn Manager is NULL!");
        }
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            FireLaser();
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
            if (_tripleshotActive)
            {
                Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.73f, 0), Quaternion.identity);

            }

    }

    public void Damage()
    {

        _hitCount--;
        if (_hitCount < 1)
        {
            if (_spawnManager != null)
            {
                _spawnManager.onPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -10.6f, 0), 0);

        if (transform.position.x >= 19.75f)
        {
            transform.position = new Vector3(-20.50f, transform.position.y, 0);
        }
        else if (transform.position.x <= -20.75f)
        {
            transform.position = new Vector3(19.74f, transform.position.y, 0);
        }
    }
}
