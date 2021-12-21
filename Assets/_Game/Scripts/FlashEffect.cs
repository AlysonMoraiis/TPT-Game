using System.Collections;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField]
    Material flashMaterial;
    [SerializeField]
    float duration;

    SpriteRenderer spriteRenderer;
    Material originalMaterial;
    Coroutine flashCoroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    public void FlashOn()
    {
        spriteRenderer.material = flashMaterial;
    }

    public void FlashOff()
    {
        spriteRenderer.material = originalMaterial;
    }
    IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = originalMaterial;

        flashCoroutine = null;
    }
}
