using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IDamageable
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject explosionRef;
    [SerializeField] Enemy_IA enemyIA;
    [SerializeField] float startDazedTime;
    [SerializeField] int maxHealth = 100;

    [SerializeField] float inChase;
    [SerializeField] float inPatrol;

    int currentHealth;
    float dazedTime;



    void Start()
    {
        currentHealth = maxHealth;
    }



    private void Update()
    {
        if (dazedTime <= 0 && enemyIA.inRange == true)
        {
            enemyIA.moveSpeed = inChase;
        }
        else if (dazedTime <= 0 && enemyIA.inRange == false)
        {
            enemyIA.moveSpeed = inPatrol;
        }
        else
        {
            enemyIA.moveSpeed = 0f;
            dazedTime -= Time.deltaTime;
        }
    }



    IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        currentHealth -= damage;
        StartCoroutine(Damage());

        if (currentHealth <= 0)
        {
            Die();
        }
    }



    void Die()
    {
        Destroy(gameObject);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
