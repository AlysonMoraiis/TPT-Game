using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField] float maxHealth;
    public float health;

    [Header("Others")]
    [SerializeField] Animator _animator;
    [SerializeField] bool _canDamage = true;
    [SerializeField] FlashEffect flashEffect;
    [SerializeField] Image healthBar;
    [SerializeField] Rigidbody2D rb;

    public event Action OnDeath;



    private void Start()
    {
        health = maxHealth;
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && _canDamage && health > 0)
        {
            TakeDamage(1);
        }

        if (other.CompareTag("EndWall"))
        {
            TakeDamage(999);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }



    void TakeDamage(int value)
    {
        health -= value;

        healthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            PlayerDeath();
            return;
        }

        _animator.SetTrigger("Hurt");
        StartCoroutine(Cooldown());
    }



    //criar metodo de alterar vida, pra quando encher ou levar dano. ela vai piscar qnd for chamada.
    IEnumerator Cooldown()
    {
        _canDamage = false;
        flashEffect.FlashOn();
        yield return new WaitForSeconds(0.15f);
        flashEffect.FlashOff();
        yield return new WaitForSeconds(0.15f);
        flashEffect.FlashOn();
        yield return new WaitForSeconds(0.15f);
        flashEffect.FlashOff();
        yield return new WaitForSeconds(0.15f);
        flashEffect.FlashOn();
        yield return new WaitForSeconds(0.15f);
        flashEffect.FlashOff();
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }



    void PlayerDeath()
    {
        _animator.SetTrigger("Dead");
        Destroy(gameObject, 3);
        OnDeath?.Invoke();
    }
}
