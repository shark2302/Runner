using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Vector3 _targetPos;
   private float _yChange = 3f;
   private float _minPos = -3f;
   private float _maxPos = 3f;
   [SerializeField] private float _speed;
   [SerializeField] private int _health;
   private bool _canMove;
   [SerializeField] private GameObject _particleSystem;
   [SerializeField] private GameObject _spawner;
   [SerializeField] private HealthBar _healthBar;

   private void Start()
   {
      _healthBar.SetMaxHealth(_health);
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < _maxPos && _canMove)
      {
         _targetPos = new Vector3(transform.position.x, transform.position.y + _yChange);
         _canMove = false;
      }
      else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > _minPos && _canMove)
      {
         _targetPos = new Vector3(transform.position.x, transform.position.y - _yChange);
         _canMove = false;
      }
   }

   private void FixedUpdate()
   {
      transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.fixedDeltaTime);
      if (transform.position == _targetPos)
         _canMove = true;
   }

   public void TakeDamage(int damage)
   {
      _health -= damage;
      _healthBar.SetHealth(_health);
      if (_health <= 0)
      {
         Die();
      }
   }

   private void Die()
   {
      Instantiate(_particleSystem, transform.position, Quaternion.identity);
      _spawner.SetActive(false);
      Destroy(gameObject);
   }

   public void Heel()
   {
      _health += 1;
      if (_health > 3)
         _health = 3;
         _health = 3;
      _healthBar.SetHealth(_health);
   }

   
}
