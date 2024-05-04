using System.Collections;
using UnityEngine;

namespace Scenes.Block
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private BlockMain blockPrefab;
        private ObjectPool<BlockMain> _blockPool;
        [SerializeField] private BoxCollider2D spawnArea;
        private float _spacing;
        private float _gridSizeX;
        private float _gridSizeY;

        private const int GridSize = 7;
        private void Awake()
        {
            _blockPool = new ObjectPool<BlockMain>(blockPrefab);
            _gridSizeX = spawnArea.size.x;
            _gridSizeY = spawnArea.offset.y;
            _spacing = _gridSizeX / GridSize;
        }

        private void Start()
        {
            StartCoroutine(SpawnBlock());
        }

        private IEnumerator SpawnBlock()
        {
            while (true)
            {
                SpawnBlockLine(2);
                yield return new WaitForSeconds(2f);
            }
        }

        private void SpawnBlockLine(int number)
        {
            for (float y = _gridSizeY; y <= _gridSizeY + _spacing * number; y += _spacing)
            {
                for (float x = -_gridSizeX / 2 + _spacing / 2; x < _gridSizeX / 2; x += _spacing)
                {
                    BlockMain block = Get();
                    block.transform.position = new Vector3(x, y, 0);
                    block.gameObject.SetActive(true);
                    StartCoroutine(Release(block));
                }
            }
        }
        private BlockMain Get()
        {
            return _blockPool.Get();
        }
        private IEnumerator Release(BlockMain bullet)
        {
            yield return new WaitForSeconds(7);
            _blockPool.Release(bullet);
        }

    }
}
