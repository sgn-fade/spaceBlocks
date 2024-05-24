using UnityEngine;

namespace Scenes.UI
{
    public class Settings : MonoBehaviour
    {

        public void OnSettingsPressed()
        {
            Debug.Log(1);
            gameObject.SetActive(true);
        }
        public void OnExitPressed()
        {
            gameObject.SetActive(false);
        }

    }
}
