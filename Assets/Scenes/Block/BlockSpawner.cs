using System.Collections;
using UnityEngine;

namespace Scenes.Block
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private BlockMain blockPrefab;
        private ObjectPool<BlockMain> _blockPool;

        private void Awake()
        {
            _blockPool = new ObjectPool<BlockMain>(blockPrefab);
        }

        private void Start()
        {
            StartCoroutine(SpawnBlock());
        }

        private IEnumerator SpawnBlock()
        {
            while (true)
            {
                StartCoroutine(Release(Get()));
                yield return new WaitForSeconds(0.3f);
            }
            
        }
        private BlockMain Get()
        {
            var block = _blockPool.Get();
            block.gameObject.SetActive(true);
            var position = transform.position;
            position.x = Random.Range(-2.3f, 2.3f);
            block.transform.position = position;
            return block;
        }
        private IEnumerator Release(BlockMain bullet)
        {
            yield return new WaitForSeconds(2);
            _blockPool.Release(bullet);
        }

    }
}
