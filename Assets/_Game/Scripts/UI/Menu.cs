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
}
