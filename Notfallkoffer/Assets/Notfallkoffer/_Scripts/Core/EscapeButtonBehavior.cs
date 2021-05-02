using UnityEngine;
using UnityEngine.SceneManagement;

namespace Notfallkoffer._Scripts.Core
{
    public class EscapeButtonBehavior : MonoBehaviour
    {
        [SerializeField] private string sceneToOpen = "MainMenu";


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (sceneToOpen.Length > 0)
                {
                    SceneManager.LoadScene(sceneToOpen);
                }
                else
                {
                    Application.Quit();
                }
            }
        }
    }
}