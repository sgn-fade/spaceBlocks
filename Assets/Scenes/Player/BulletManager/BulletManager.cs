using System.Collections;
using System.Collections.Generic;
using Scenes.bullet;
using UnityEngine;

namespace Scenes.Player.BulletManager
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        private Queue<Bullet> _bullets;
        private void Start()
        {
            _bullets = new Queue<Bullet>();
            StartCoroutine(Shoot());
        }
        private IEnumerator Shoot()
        {
            while (true)
            {
                StartCoroutine(Release(Get()));
                yield return new WaitForSeconds(0.4f);
            }
        }

        private Bullet Get()
        {
            return _bullets.Count > 0 ? _bullets.Dequeue() : Create();
        }

        private Bullet Create()
        {
            return Instantiate(bullet, transform.position, Quaternion.identity);
        }

        private IEnumerator Release(Bullet bullet)
        {
            yield return new WaitForSeconds(2.4f);
            Reset(bullet);
            _bullets.Enqueue(bullet);
        }

        private void Reset(Bullet bullet)
        {
            bullet.transform.position = transform.position;
        }
    }
}
