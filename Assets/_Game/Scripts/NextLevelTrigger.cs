using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    [Header("Disabled")]
    [SerializeField] ScreenMovement screenMovement;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerJump playerJump;
    [SerializeField] GameObject nextLevelMenu;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            nextLevelMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }



    public void RestartAlllevels()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
