using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField]
    float _attackRange = 0.5f;
    [SerializeField]
    int _attackDamage;
    [SerializeField]
    float _attackRate = 2f;

    [Header("Others")]
    [SerializeField]
    Transform _attackPoint;
    [SerializeField]
    LayerMask _damageableLayers;
    [SerializeField]
    Animator _anim;

    float _nextAttackTime = 0f;
    bool _inAttack;
    bool attacking;

    public bool InAttack => _inAttack;

    private void Update()
    {
        if (Time.time >= _nextAttackTime)
        {
            if (attacking && !_inAttack)
            {
                _anim.SetTrigger("Attack");
                StartCoroutine(Countdown());
                _nextAttackTime = Time.time + 1f / _attackRate;
                attacking = false;
            }
        }
    }

    public void AttackButton()
    {
        attacking = true;
    }
    void Attack()
    {
        Collider2D[] hittedColliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _damageableLayers);
        foreach (Collider2D collider in hittedColliders)
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.TakeDamage(_attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    IEnumerator Countdown()
    {
        _inAttack = true;
        for (float i = 0f; i < 1f; i += 0.2f)
        {
            yield return new WaitForSeconds(0.05f);
        }
        _inAttack = false;
    }
}
