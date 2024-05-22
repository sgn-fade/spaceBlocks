using System;
using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private Camera _camera;

        private IPlayerModel _model;
        private IPlayerView _view;
        private BulletManager.BulletManager _bulletManager;
        private Transform _transform;
        private static GameObject _gameObject;
        private void Awake()
        {
            _view = _gameObject.GetComponentInChildren<PlayerView>();
            _bulletManager = _gameObject.GetComponent<BulletManager.BulletManager>();
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
                var position = _transform.position;

                float targetXPosition = (_camera.ScreenToWorldPoint(Input.GetTouch(0).position).x - position.x)
                                        * (Time.deltaTime * _model.Speed);
                _transform.Translate(targetXPosition, 0, 0);
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
