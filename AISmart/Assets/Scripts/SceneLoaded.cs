using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaded : MonoBehaviour
{
    [SerializeField]
    private int indexScene;

    public void LoadScene2D()
    {
        SceneManager.LoadScene(indexScene);
    }

    public void ButtunLoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ButtunExitGame()
    {

    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
