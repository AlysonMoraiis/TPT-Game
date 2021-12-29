using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float shootSpeed;



    void Start()
    {
        rb2d.velocity = new Vector2(shootSpeed, 0);
        StartCoroutine(TimeToDestroy());
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }



    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
