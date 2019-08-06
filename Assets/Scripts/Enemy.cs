using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private float x;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(9, -12);
        position = new Vector3(x, 9, 0);
    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(9f, -12f);
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -3)
        {
            transform.position = new Vector3(x, 9, 0);
        }
    }
}
