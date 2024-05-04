using System;
using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private Vector3 _position;
        private Camera _camera;
        private const float Speed = 20;

        private PlayerModel _model;
        private PlayerView _view;
        private BulletManager.BulletManager _bulletManager;

        private void Awake()
        {
            _view = gameObject.GetComponentInChildren<PlayerView>();
            _bulletManager = gameObject.GetComponent<BulletManager.BulletManager>();
            _model = new PlayerModel();
            _camera = Camera.main;
            _position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        private void Start()
        {
            _view.SetHpText(_model.Hp);
            SetShootRate(_model.ShootRate);
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            if (Input.touchCount > 0)
            {
                _position = _camera!.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position;
                _position.z = 0;
                transform.Translate(_position.normalized * (Time.deltaTime * Speed));
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
