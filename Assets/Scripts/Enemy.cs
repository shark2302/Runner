using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>()?.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
