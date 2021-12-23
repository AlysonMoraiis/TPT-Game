using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] GameObject cameraPlayer;
    [SerializeField] float speedParallax;

    float length, startPos;



    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }



    void FixedUpdate()
    {
        float temp = (cameraPlayer.transform.position.x * (1 - speedParallax));
        float dist = (cameraPlayer.transform.position.x * speedParallax);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length / 2)
        {
            startPos += length;
        }
        else if (temp < startPos - length / 2)
        {
            startPos -= length;
        }

    }
}