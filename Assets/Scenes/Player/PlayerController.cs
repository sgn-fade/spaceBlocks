using System;
using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private Camera _camera;
        [SerializeField] private GameObject settings;
        private IPlayerModel _model;
        private IPlayerView _view;
        private BulletManager.BulletManager _bulletManager;
        private Vector3 _position;
        private Transform _transform;
        private GameObject _gameObject;
        private Rigidbody2D _rigidBody;
        private void Awake()
        {
            _gameObject = gameObject;
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            _transform = transform;
            _view = _gameObject.GetComponentInChildren<IPlayerView>();
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
            if (Input.touchCount <= 0 || settings.activeSelf) return;
            var targetXPosition = (_camera.ScreenToWorldPoint(Input.GetTouch(0).position).x - _transform.position.x);
            var direction = new Vector3(targetXPosition, 0, 0);
            _rigidBody.velocity = direction * _model.Speed;
        }

        public void SetShootRate(double value)
        {
            _bulletManager.SetShootRate(value);
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

        public void UpgradeHp()
        {
            _model.MaxHp++;
            _model.Hp++;
            _view.SetHpText(_model.Hp);
        }

        public void UpgradeDamage()
        {
            _model.Damage++;
            Debug.Log(_model.Damage);
        }

        public int GetDamage()
        {
            return (int)_model.Damage;
        }
    }
}
