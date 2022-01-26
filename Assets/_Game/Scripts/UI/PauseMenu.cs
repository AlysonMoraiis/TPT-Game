using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public void Pause()
    {
        Time.timeScale = 0f;
    }


    
    public void Resume()
    {
        Time.timeScale = 1f;
    }



    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

}
