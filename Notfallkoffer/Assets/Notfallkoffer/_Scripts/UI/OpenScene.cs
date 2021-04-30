using Lean.Gui;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Notfallkoffer._Scripts.UI
{
    [RequireComponent(typeof(LeanButton))]
    public class OpenScene : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        [SerializeField] private LeanButton button;

        // Start is called before the first frame update
        void Start()
        {
            button.OnClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            button.OnClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}