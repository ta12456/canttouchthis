using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagementScript : MonoBehaviour
{
    public void pauseGame()
    {
        Time.timeScale = 0;
    }
    public void unPauseGame()
    {
        Time.timeScale = 1;
    }
    public void quitToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
