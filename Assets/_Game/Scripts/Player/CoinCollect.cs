using UnityEngine;
using UnityEngine.UI;
public class CoinCollect : MonoBehaviour
{
    int score;
    Text scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    void Score()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
}
