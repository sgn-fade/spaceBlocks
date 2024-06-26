using System;
using System.Collections;
using Scenes.BlockSpawner.Block;
using Scenes.CoinManager;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private Camera _camera;
        [SerializeField] private GameObject settings;
        [SerializeField] private MonoBehaviour coinManager;
        [SerializeField] private Button targetTouch;

        private IPlayerModel _model;
        private IPlayerView _view;
        private BulletManager.BulletManager _bulletManager;
        private Transform _transform;

        private Vector3 _targetPosition;
        private GameObject _gameObject;
        private Rigidbody2D _rigidBody;

        private bool _isPlayerDead;
        private ICoinController _coinManagerController;
        private bool _positionTargeted;

        public delegate void OnPlayerDead();

        public static event OnPlayerDead PlayerDead;

        public delegate void OnPlayerRevive();

        public static event OnPlayerRevive PlayerRevive;

        private void Awake()
        {
            _gameObject = gameObject;
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            _coinManagerController = coinManager as ICoinController;
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


        public void Move()
        {

            StartCoroutine(MoveCoroutine());
        }

        private IEnumerator MoveCoroutine()
        {
            while (!settings.activeSelf || !_isPlayerDead)
            {
                if (Input.touchCount > 0)
                {
                    var targetWorldPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                    if (targetWorldPosition.y > 3) break;
                    _targetPosition = new Vector3(targetWorldPosition.x, 0, 0);
                }

                Vector3 direction = (_targetPosition - _transform.position);
                _rigidBody.velocity = direction * _model.Speed;

                if (Vector3.Distance(_transform.position, _targetPosition) < 0.1f)
                {
                    _rigidBody.velocity = Vector3.zero;
                }

                yield return new WaitForSeconds(Time.deltaTime);
            }
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
            if (!_coinManagerController.PayMoney(100)) return;
            PlayerRevive?.Invoke();
            _model.Hp = _model.MaxHp;
            _isPlayerDead = false;
            _view.SetHpText(_model.Hp);
        }


        private void PlayerDeath()
        {
            _transform.position = new Vector3(0, -4.4f, 0);
            _rigidBody.velocity = Vector3.zero;
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
        }

        public void UpgradeShootRate()
        {
            SetShootRate(++_model.ShootRate);
        }

        public int GetDamage()
        {
            return (int)_model.Damage;
        }

        private void OnEnable()
        {
            targetTouch.onClick.AddListener(Move);
        }

        private void OnDisable()
        {
            targetTouch.onClick.RemoveListener(Move);
        }


        public void OnYesConfirmPressed()
        {
            RevivePlayer();
        }
    }
}