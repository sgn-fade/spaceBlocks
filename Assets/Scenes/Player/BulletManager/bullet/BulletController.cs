using System;
using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.Player.BulletManager.bullet
{
    public class BulletController : MonoBehaviour
    {
        private IBulletModel _model;
        private readonly Vector2 _velocity = new Vector2(0, 5);

        private void Awake()
        {
            _model = new BulletModelCriticalChance();
        }

        private void Update()
        {
            transform.Translate(_velocity * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BlockController block))
            {
                gameObject.SetActive(false);
                block.TakeDamage(GetDamage());
            }
        }

        public int GetDamage()
        {
            return _model.Damage;
        }

        public void SetDamage(int value)
        {
            _model.Damage = value;
        }
    }
}