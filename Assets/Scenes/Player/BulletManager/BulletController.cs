using System;
using UnityEngine;

namespace Scenes.bullet
{
    public class Bullet : MonoBehaviour
    {
        private readonly Vector2 _velocity = new Vector2(0, 5);
        
        private void Update()
        {
            transform.Translate(_velocity * Time.deltaTime);
        }
    }
}
