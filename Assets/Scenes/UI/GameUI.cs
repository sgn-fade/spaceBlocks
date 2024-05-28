using System.Collections;
using UnityEngine;

namespace Scenes.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject tutor;
        void Start()
        {
            StartCoroutine(RemoveTutorial());
        }

        IEnumerator RemoveTutorial()
        {
            yield return new WaitForSeconds(5);
            Destroy(tutor);
        }
    }
}
