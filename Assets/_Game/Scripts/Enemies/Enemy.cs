using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int life = 5;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject explosionRef;



    public void TakeDamage(int attackDamage)
    {
        life -= attackDamage;
        StartCoroutine(DamageFlash());
        if (life <= 0)
        {
            GameObjectDead();
        }
    }



    void GameObjectDead()
    {
        Destroy(gameObject);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }



    IEnumerator DamageFlash()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
