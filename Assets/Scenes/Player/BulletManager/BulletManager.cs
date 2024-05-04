using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.Player.BulletManager
{
    public class BulletManager : MonoBehaviour
    {
        [FormerlySerializedAs("bulletPrefab")] [SerializeField] private BulletController bulletControllerPrefab;
        private ObjectPool<BulletController> _bulletPool;
        
        private float _shootRate;

        private void Awake()
        {
            _bulletPool = new ObjectPool<BulletController>(bulletControllerPrefab);
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

        private BulletController Get()
        {
            BulletController bulletController = _bulletPool.Get();
            bulletController.gameObject.SetActive(true);
            bulletController.transform.position = transform.position;
            return bulletController;
        }

        private IEnumerator Release(BulletController bulletController)
        {
            yield return new WaitForSeconds(2);
            ResetBulletPosition(bulletController);
            _bulletPool.Release(bulletController);
        }

        private void ResetBulletPosition(BulletController bulletController)
        {
            bulletController.transform.position = transform.position;
        }

        public void SetShootRate(double dataShootRate)
        {
            _shootRate = (float)dataShootRate;
        }
    }
}
