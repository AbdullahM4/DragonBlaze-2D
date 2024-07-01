
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Game over")]
   [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    [Header("Pause ")]
    [SerializeField] private GameObject pauseScreen;
    


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // if pause screen is already active unpause and versa vica
            if(pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }
    #region GameOver
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManger.instance.PlaySound(gameOverSound);
    }
    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Activate game over screen
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Gameplay()
    {
        SceneManager.LoadScene(1);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)


         #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode
        #endif
        
    }
    #endregion


    #region pause
    public void PauseGame(bool status)
    {
        // if status == true = pause
        pauseScreen.SetActive(status);

        if(status)
            Time.timeScale=0;
        else
            Time.timeScale=1;
    }

    public void SoundVolume()
    {
        SoundManger.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManger.instance.ChangeMusicVolume(0.2f);
    }
    #endregion
}
