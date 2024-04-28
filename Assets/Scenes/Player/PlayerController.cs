using System;
using System.Collections;
using Scenes.bullet;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 position;
        private Camera _camera;
        private float speed = 10;

        [SerializeField] private Bullet bullet; 
        
        private void Awake()
        {
            _camera = Camera.main;
            position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        private void Start()
        {
            StartCoroutine(Shoot());
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                position = _camera!.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position;
                position.z = 0;
                transform.Translate(position.normalized * (Time.deltaTime * speed));
            }
        }
        
        private IEnumerator Shoot()
        {
            while (true)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}
