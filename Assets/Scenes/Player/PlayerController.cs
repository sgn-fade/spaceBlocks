using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 position;
        private Camera _camera;
        private float speed = 20;

        private PlayerData _data;
        private BulletManager.BulletManager _bulletManager; 
        private void Awake()
        {
            _bulletManager = gameObject.GetComponent<BulletManager.BulletManager>();
            _data = new PlayerData();
            _camera = Camera.main;
            position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        private void Start()
        {
            _bulletManager.SetShootRate(_data.ShootRate);
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
        
        
    }
}
