using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    int life = 5;
    [SerializeField]
    SpriteRenderer sprite;

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
    }

    IEnumerator DamageFlash()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
