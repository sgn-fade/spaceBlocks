using System.Collections;
using Scenes.Player.BulletManager.bullet;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.Player.BulletManager
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour player;
        [SerializeField] private BulletController bulletControllerPrefab;
        private ObjectPool<BulletController> _bulletPool;

        private IPlayerController _playerController;
        private float _shootRate;

        private void Awake()
        {
            _bulletPool = new ObjectPool<BulletController>(bulletControllerPrefab);
            _playerController = player as IPlayerController;
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
            bulletController.SetDamage(_playerController.GetDamage());
            bulletController.gameObject.SetActive(true);
            bulletController.transform.position = transform.position;
            return bulletController;
        }

        private IEnumerator Release(BulletController bulletController)
        {
            yield return new WaitForSeconds(2);
            bulletController.gameObject.SetActive(false);
            _bulletPool.Release(bulletController);
        }


        public void SetShootRate(double dataShootRate)
        {
            _shootRate = (float)dataShootRate;
        }
    }
}
