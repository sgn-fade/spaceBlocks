using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.BlockSpawner.Block
{
    public class BlockController : MonoBehaviour, IBlockController
    {
        public static event Action<int> OnEnemyKilled;
        private readonly Vector2 _velocity = new Vector2(0, -1);

        private BlockModel _model;
        private BlockView _view;
        private void Awake()
        {
            _view = gameObject.GetComponentInChildren<BlockView>();
            _model = new BlockModel(1);
        }

        private void Start()
        {
            UpdateHp(_model.Hp);
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
    }
}
