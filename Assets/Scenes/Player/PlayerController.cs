using System.Collections;
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
        private Transform _transform;

        private Vector3 _targetPosition;
        private GameObject _gameObject;
        private Rigidbody2D _rigidBody;

        private bool _isPlayerDead;

        public delegate void OnPlayerDead();
        public static event OnPlayerDead PlayerDead;
        public delegate void OnPlayerRevive();
        public static event OnPlayerDead PlayerRevive;
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
            if (settings.activeSelf || _isPlayerDead) return;

            if (Input.touchCount > 0)
            {
                var targetWorldPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                _targetPosition = new Vector3(targetWorldPosition.x, 0, 0);
            }

            Vector3 direction = (_targetPosition - _transform.position);
            _rigidBody.velocity = direction * _model.Speed;

            // if (Vector3.Distance(_transform.position, _targetPosition) < 0.1f)
            // {
            //     _rigidBody.velocity = Vector3.zero;
            // }
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
            if (_model.Hp <= 0)
            {
                PlayerDeath();
            }
            _view.SetHpText(_model.Hp);
        }
        private IEnumerator AutoRevive()
        {
            yield return new WaitForSeconds(300);
            RevivePlayer();
        }

        private void RevivePlayer()
        {
            PlayerRevive?.Invoke();
            _model.Hp = _model.MaxHp;
            _isPlayerDead = false;
            _view.SetHpText(_model.Hp);
        }

        public void OnReviveButtonPressed()
        {
            RevivePlayer();
        }
        private void PlayerDeath()
        {
            StartCoroutine(AutoRevive());
            PlayerDead?.Invoke();
            _isPlayerDead = true;
            _view.StartDeathTimer();

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
