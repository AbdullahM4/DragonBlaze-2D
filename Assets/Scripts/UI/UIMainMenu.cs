using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{


    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    #region 
    
    // Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Activate main menu screen
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Start gameplay
    public void Gameplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit game/exit play mode if in Editor
    public void Quit()
    {
        
        Application.Quit(); // Quits the game (only works in build)

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exits play mode
        #endif
    }
    #endregion
}
