using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.UI
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private GameObject loadScreen;
        public void OnPlayPressed()
        {
            StartCoroutine(LoadAsyncScene());
            loadScreen.SetActive(true);
            gameObject.SetActive(false);
        }

        private IEnumerator LoadAsyncScene()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("MainScene");

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / 0.9f);
                progressBar.value = progress;
                yield return null;
            }
            loadScreen.SetActive(false);
        }
        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}