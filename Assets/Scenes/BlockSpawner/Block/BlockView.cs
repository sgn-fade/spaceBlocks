using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.BlockSpawner.Block
{
    public class BlockView : MonoBehaviour, IBlockView
    {
        [SerializeField] private GameObject textUi;
        private Text _text;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private ParticleSystem _particles;

        private void Awake()
        {
            _particles = GetComponent<ParticleSystem>();
            _text = textUi.GetComponent<Text>();
        }

        public void SetHpText(int value)
        {
            _text.text = value.ToString();
        }

        public void SetBlockColor(Color blockColor)
        {
            spriteRenderer.color = blockColor;
            var particlesMain = _particles.main;
            particlesMain.startColor = blockColor;
        }

        public void DestroyBlock()
        {
            textUi.SetActive(false);
            spriteRenderer.enabled = false;
            _particles.Play();
        }
        private void OnEnable()
        {
            textUi.SetActive(true);
            spriteRenderer.enabled = true;
        }
    }
}
