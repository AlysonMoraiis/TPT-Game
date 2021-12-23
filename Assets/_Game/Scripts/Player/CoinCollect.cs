using UnityEngine;
using UnityEngine.UI;
public class CoinCollect : MonoBehaviour
{
    int score;
    [SerializeField]
    Text scoreText;



    private void Start()
    {
        score = PlayerPrefs.GetInt("SavedCoin");
        scoreText.text = "x" + score.ToString();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Score();
        }
    }



    void Score()
    {
        score += 1;
        scoreText.text = "x" + score.ToString();
        PlayerPrefs.SetInt("SavedCoin", score);
    }
}
