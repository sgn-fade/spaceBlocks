using System.Collections;
using Scenes.BlockSpawner.Block;
using UnityEngine;

namespace Scenes.BlockSpawner
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private BlockController blockPrefab;
        private ObjectPool<BlockController> _blockPool;
        [SerializeField] private BoxCollider2D spawnArea;
        private float _spacing;
        private float _gridSizeX;
        private float _gridSizeY;

        private int _difficulty = 1;
        private bool isGameActive = true;

        private const int GridSize = 7;
        private void Awake()
        {
            _blockPool = new ObjectPool<BlockController>(blockPrefab);
            _gridSizeX = spawnArea.size.x;
            _gridSizeY = spawnArea.offset.y;
            _spacing = _gridSizeX / GridSize;
        }

        private void Start()
        {
            StartCoroutine(SpawnBlock());
            StartCoroutine(DifficultyCap());
        }

        private IEnumerator DifficultyCap()
        {
            while (isGameActive)
            {
                _difficulty++;
                yield return new WaitForSeconds(10);
            }
        }

        private IEnumerator SpawnBlock()
        {
            while (isGameActive)
            {
                SpawnBlockLine(1);
                yield return new WaitForSeconds(4f);
            }
        }

        public void OffGame()
        {
            isGameActive = false;
        }
        public void OnGame()
        {
            isGameActive = true;
        }

        private void SpawnBlockLine(int number)
        {
            for (float y = 0; y < number; y++)
            {
                for (float x = 0; x < GridSize; x++)
                {
                    BlockController block = Get();
                    block.ChangeDifficulty(_difficulty);
                    block.ResetBlock();
                    block.transform.position = new Vector3(( _spacing - _gridSizeX) / 2 + x * _spacing, _gridSizeY + y * _spacing, 0);
                    block.gameObject.SetActive(true);
                    StartCoroutine(Release(block));
                }
            }
        }
        private BlockController Get()
        {
            return _blockPool.Get();
        }
        private IEnumerator Release(BlockController bullet)
        {
            yield return new WaitForSeconds(10);
            _blockPool.Release(bullet);
        }

    }
}
