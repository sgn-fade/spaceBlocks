using System;
using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private Camera _camera;

        private PlayerModel _model;
        private PlayerView _view;
        private BulletManager.BulletManager _bulletManager;

        private void Awake()
        {
            _view = gameObject.GetComponentInChildren<PlayerView>();
            _bulletManager = gameObject.GetComponent<BulletManager.BulletManager>();
            _model = new PlayerModel();
            _camera = Camera.main;
            SetShootRate(_model.ShootRate);
        }

        private void Start()
        {
            _view.SetHpText(_model.Hp);
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            if (Input.touchCount > 0)
            {
                Vector3 targetPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                var transform1 = transform;
                var position = transform1.position;
                targetPosition.z = position.z;
                transform1.up = (targetPosition - position).normalized;
            }
        }

        public void SetShootRate(double value)
        {
            _bulletManager.SetShootRate(value);
        }

        public void SetDamage(int value)
        {
            throw new NotImplementedException();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BlockController block))
            {
                UpdateHp(-1);
                block.gameObject.SetActive(false);
            }
        }

        public void UpdateHp(int value)
        {
            _model.Hp += value;
            _view.SetHpText(_model.Hp);
        }
    }
}
