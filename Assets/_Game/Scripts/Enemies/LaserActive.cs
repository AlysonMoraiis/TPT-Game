using System.Collections;
using UnityEngine;

public class LaserActive : MonoBehaviour
{
    [SerializeField] BoxCollider2D laserCollider;
    [SerializeField] SpriteRenderer laserSprite;



    private void Start()
    {
        StartCoroutine(ActiveOnTrigger());
    }



    IEnumerator ActiveOnTrigger()
    {
        yield return new WaitForSeconds(1f);
        laserCollider.enabled = true;
        laserSprite.enabled = true;
        yield return new WaitForSeconds(1f);
        laserCollider.enabled = false;
        laserSprite.enabled = false;
        StartCoroutine(ActiveOnTrigger());
    }
}
