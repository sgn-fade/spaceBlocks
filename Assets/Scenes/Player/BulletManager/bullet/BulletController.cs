using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.Player.BulletManager.bullet
{
    public class BulletController : MonoBehaviour
    {
        private readonly Vector2 _velocity = new Vector2(0, 5);
        private void Update()
        {
            transform.Translate(_velocity * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BlockController block))
            {
                gameObject.SetActive(false);
                block.TakeDamage(1);
            }
        }
    }
}