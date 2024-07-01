using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{

    [SerializeField] private AudioClip MainMenuSound;

    private void Awake()
    {
    }

    #region 
    public void Main()
    {
        SoundManger.instance.PlaySound(MainMenuSound);
    }

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
        SceneManager.LoadScene(1);
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
