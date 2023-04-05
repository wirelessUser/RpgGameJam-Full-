using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObscutingItemFader : MonoBehaviour
{


    private SpriteRenderer spriteRendere;


    private void Awake()
    {
        spriteRendere = GetComponent<SpriteRenderer>();
    }



    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }


    private IEnumerator FadeOutRoutine()
    {
        float currentAlpha = spriteRendere.color.a;
        float distance = currentAlpha - Setting.targetAlpha;

        while (currentAlpha- Setting.targetAlpha>0.01f)
        {
            currentAlpha = currentAlpha - distance / Setting.fadeOutSeconds * Time.deltaTime;
            spriteRendere.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }

        spriteRendere.color = new Color(1f, 1f, 1f, Setting.targetAlpha);
    }
    private IEnumerator FadeInRoutine()
    {
        float currentAlpha = spriteRendere.color.a;
        float distance = 1f - currentAlpha;

        while (1f - currentAlpha > 0.01f)
        {
            currentAlpha = currentAlpha + distance / Setting.fadeInSeconds * Time.deltaTime;
            spriteRendere.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }
        spriteRendere.color = new Color(1f, 1f, 1f, 1f);
    }
}
