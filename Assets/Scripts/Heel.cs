using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heel : MonoBehaviour
{
    
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
            other.GetComponent<PlayerController>()?.Heel();
            Destroy(gameObject);
        }
    }
}
