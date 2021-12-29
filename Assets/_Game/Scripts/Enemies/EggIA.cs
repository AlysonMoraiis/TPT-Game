using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggIA : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject bullet;
    [SerializeField] float direction;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attacking());
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu");
            StopAllCoroutines();
            animator.SetTrigger("Idle");
        }
    }



    public void InstantiateBullet()
    { 
        Instantiate(bullet, new Vector2(transform.position.x + direction, transform.position.y), Quaternion.identity);
    }



    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Atacou");
        animator.SetTrigger("Shooting");
        yield return new WaitForSeconds(0.2f);
        InstantiateBullet();
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(Attacking());
    }
}
