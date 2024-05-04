using UnityEngine;

namespace Scenes.Block
{
    public class BlockMain : MonoBehaviour
    {
        private readonly Vector2 _velocity = new Vector2(0, -5);
        
        private void Update()
        {
            transform.Translate(_velocity * Time.deltaTime);
        }

        public void TakeDamage(int value)
        {
            gameObject.SetActive(false);
        }
    }
}
