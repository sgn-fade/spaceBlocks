using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Player
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Text text;

        public void SetHpText(int value)
        {
            text.text = value.ToString();
        }
    }
}
