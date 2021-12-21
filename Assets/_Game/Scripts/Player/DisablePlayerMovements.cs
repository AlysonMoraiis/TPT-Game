using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DisablePlayerMovements : MonoBehaviour
{
    [Header("Disabled")]
    [SerializeField]
    ScreenMovement screenMovement;
    [SerializeField]
    PlayerAttack playerAttack;
    [SerializeField]
    PlayerJump playerJump;

    [Header("Others")]
    [SerializeField]
    PlayerStatus playerStatus;


    private void OnEnable()
    {
        playerStatus.OnDeath += DisablePlayer;
    }



    private void OnDisable()
    {
        playerStatus.OnDeath -= DisablePlayer;
    }



    private void DisablePlayer()
    {
        screenMovement.enabled = false;
        playerAttack.enabled = false;
        playerJump.enabled = false;
        StartCoroutine(RestartScene());
    }



    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
