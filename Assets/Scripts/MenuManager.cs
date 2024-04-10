using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayButtonPress()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButtonPress()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        Application.OpenURL("about:blank");
#elif UNITY_STANDALONE_OSX
        Application.Quit();
#endif
    }
}
