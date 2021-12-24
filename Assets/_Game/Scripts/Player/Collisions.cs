using UnityEngine;
using UnityEngine.UI;
public class Collisions : MonoBehaviour
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



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("AutomaticPlat"))
        {
            this.transform.parent = other.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("AutomaticPlat"))
        {
            this.transform.parent = null;
        }
    }



    void Score()
    {
        score += 1;
        scoreText.text = "x" + score.ToString();
        PlayerPrefs.SetInt("SavedCoin", score);
    }
}
