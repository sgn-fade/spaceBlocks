using System.Collections;
using Scenes.bullet;
using UnityEngine;

namespace Scenes.Player.BulletManager
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        private ObjectPool<Bullet> _bulletPool;
        private float _shootRate;

        private void Awake()
        {
            _bulletPool = new ObjectPool<Bullet>(bulletPrefab);
        }

        private void Start()
        {
            StartCoroutine(Shoot());
        }
        private IEnumerator Shoot()
        {
            while (true)
            {
                StartCoroutine(Release(Get()));
                yield return new WaitForSeconds(_shootRate);
            }
        }

        private Bullet Get()
        {
            Bullet bullet = _bulletPool.Get();
            bullet.transform.position = transform.position;
            return bullet;
        }

        private IEnumerator Release(Bullet bullet)
        {
            yield return new WaitForSeconds(2);
            ResetBulletPosition(bullet);
            _bulletPool.Release(bullet);
        }

        private void ResetBulletPosition(Bullet bullet)
        {
            bullet.transform.position = transform.position;
        }

        public void SetShootRate(double dataShootRate)
        {
            _shootRate = (float)dataShootRate;
        }
    }
}
