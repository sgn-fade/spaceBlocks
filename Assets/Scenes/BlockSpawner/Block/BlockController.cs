using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.Player;
using Scenes.UI;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scenes.BlockSpawner.Block
{
    public class BlockController : MonoBehaviour, IBlockController
    {
        public static event Action<int> OnEnemyKilled;
        private readonly Vector2 _velocity = new (0, -1.5f);

        private Transform _transform;
        private GameObject _gameObject;
        [SerializeField] private GameObject hpObject;
        private IBlockModel _model;
        private IBlockView _view;

        private AudioSource _audioSource;
        private readonly Color[] _blockColors = new[] { Color.green, Color.cyan, Color.blue, Color.magenta, Color.red, };
        private bool _isPlayerAlive;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _transform = transform;
            _gameObject = gameObject;
            _view = gameObject.GetComponent<BlockView>();
            _model = new BlockModel();
        }

        private void Start()
        {
            UpdateHp(_model.Hp);
            ResetBlock();
        }
        private void Update()
        {
            Move();
        }
        
        public void TakeDamage(int value)
        {
            if (_model.Hp <= 0) return;
            UpdateHp(_model.Hp -value);
            _view.SetHpText(_model.Hp);
            _audioSource.Play();
            if (_model.Hp > 0) return;

            OnEnemyKilled?.Invoke(_model.Cost);
            StartCoroutine(DestroyBlock());

        }

        private IEnumerator DestroyBlock()
        {
            _view.DestroyBlock();
            if(Settings.IsAudioEnabled()) _audioSource.Play();

            yield return new WaitForSeconds(_audioSource.clip.length);
            _gameObject.SetActive(false);
        }


        public void ChangeDifficulty(float value)
        {
            _model.DifficultMultiplier = value;
        }
        public void Move()
        {
            _transform.Translate(_velocity * Time.deltaTime);
        }

        public void UpdateHp(int value)
        {
            _model.Hp = value;
            _view.SetHpText(_model.Hp);
        }

        public void ResetBlock()
        {
            var tier = Random.Range(1, 5);
            _view.SetBlockColor(_blockColors[tier - 1]);
            _model.Reset(tier);
            _view.SetHpText(_model.Hp);
        }
        private void OnEnable()
        {
            PlayerController.PlayerDead += OnPlayerDead;
        }
        private void OnDisable()
        {
            PlayerController.PlayerDead -= OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            StartCoroutine(DestroyBlock());
        }
    }
}
