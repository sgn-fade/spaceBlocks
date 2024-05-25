using UnityEngine;

namespace Scenes.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject game;
        [SerializeField] private GameObject gameUi;

        public void OnPlayPressed()
        {
            game.SetActive(true);
            gameUi.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
