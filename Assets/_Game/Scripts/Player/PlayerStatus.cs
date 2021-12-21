using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField]
    public float health;
    [SerializeField]
    float maxHealth;
    [SerializeField]
    public float mana;
    [SerializeField]
    float maxMana;
    [SerializeField]
    public float stamina;
    [SerializeField]
    float maxStamina;
    [SerializeField]
    float regenTick;
    Coroutine regen;

    [Header("Others")]
    [SerializeField]
    Animator _animator;
    [SerializeField]
    bool _canDamage = true;
    [SerializeField]
    FlashEffect flashEffect;
    [SerializeField]
    Image healthBar;
    [SerializeField]
    Image manaBar;
    [SerializeField]
    Image staminaBar;

    public bool haveMana;
    public bool haveStamina;
    public event Action OnDeath;





    private void Start()
    {
        health = maxHealth;
        mana = maxMana;
        stamina = maxStamina;
        haveStamina = true;
    }



    private void Update()
    {
        manaBar.fillAmount = mana / maxMana;
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && _canDamage && health > 0)
        {
            TakeDamage();
        }
    }



    void TakeDamage()
    {
        health -= 1;

        if (health <= 0)
        {
            PlayerDeath();
            return;
        }

        _animator.SetTrigger("Hurt");
        StartCoroutine(Cooldown());
        healthBar.fillAmount = health / maxHealth;
    }



    public IEnumerator StaminaRegen()
    {
        staminaBar.fillAmount = stamina / maxStamina;
        yield return new WaitForSeconds(1);

        while (stamina < maxStamina)
        {
            staminaBar.fillAmount = stamina / maxStamina;
            stamina += regenTick;

            if(stamina >= 1)
            {
                haveStamina = true;
            }

            if(stamina > maxStamina)
            {
                stamina = maxStamina;
            }
            Debug.Log(stamina);
            yield return 0.1f;
        }

        regen = null;
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
        _animator.SetTrigger("Death");
        Destroy(gameObject, 3);
        OnDeath?.Invoke();
    }
}
