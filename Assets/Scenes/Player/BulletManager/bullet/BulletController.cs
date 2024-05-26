using System;
using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.Player.BulletManager.bullet
{
    public class BulletController : MonoBehaviour
    {
        private readonly Vector2 _velocity = new Vector2(0, 10);
        private GameObject _gameObject;

        private int _damage = 1;
        private void Awake()
        {
            _gameObject = gameObject;
        }

        private void Update()
        {
            transform.Translate(_velocity * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BlockController block))
            {
                _gameObject.SetActive(false);
                block.TakeDamage(_damage);
            }
        }

        public void SetDamage(int value)
        {
            _damage = value;
        }
    }
}