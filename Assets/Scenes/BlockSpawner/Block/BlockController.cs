using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scenes.BlockSpawner.Block
{
    public class BlockController : MonoBehaviour, IBlockController
    {
        public static event Action<int> OnEnemyKilled;
        private readonly Vector2 _velocity = new (0, -1);

        private IBlockModel _model;
        private IBlockView _view;
        private readonly Color[] _blockColors = new[] { Color.green, Color.cyan, Color.blue, Color.magenta, Color.red, };
        private void Awake()
        {
            _view = gameObject.GetComponentInChildren<BlockView>();
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
            UpdateHp(_model.Hp -value);
            _view.SetHpText(_model.Hp);

            if (_model.Hp > 0) return;

            OnEnemyKilled?.Invoke(_model.Cost);
            gameObject.SetActive(false);
        }

        public void Move()
        {
            transform.Translate(_velocity * Time.deltaTime);
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
    }
}
