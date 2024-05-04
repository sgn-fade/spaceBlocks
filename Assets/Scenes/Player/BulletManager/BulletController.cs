using System.Security.Cryptography;
using Scenes.Block;
using Scenes.BlockSpawner.Block;
using Unity.VisualScripting;
using UnityEngine;

namespace Scenes.Player.BulletManager
{
    public class BulletController : MonoBehaviour
    {
        private readonly Vector2 _velocity = new Vector2(0, 10);

        private void Update()
        {
            transform.Translate(_velocity * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BlockController block))
            {
                block.TakeDamage(1);
                gameObject.SetActive(false);
            }
        }
    }
}