using UnityEngine;

namespace Scenes.BlockSpawner.Block
{
    public class BlockController : MonoBehaviour, IBlockController
    {
        private readonly Vector2 _velocity = new Vector2(0, -2);

        private BlockModel _model;
        private void Awake()
        {
            _model = new BlockModel(1);
        }

        private void Update()
        {
            Move();
        }
        
        public void TakeDamage(int value)
        {
            _model.Hp -= value;
            if (_model.Hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        public void Move()
        {
            transform.Translate(_velocity * Time.deltaTime);
        }

        public void UpdateHp(int value)
        {
            _model.Hp = value;
        }
    }
}
