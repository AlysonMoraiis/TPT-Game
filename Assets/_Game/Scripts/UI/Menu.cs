using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ContinueButton()
    {
        SceneManager.LoadScene("Level 1");  
        Debug.Log("Continue");
    }



    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        Debug.Log("Menu");
    }
}
