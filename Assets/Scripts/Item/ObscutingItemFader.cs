using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObscutingItemFader : MonoBehaviour
{
    // Obscruting Item, fade ....


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
        //float distance = currentAlpha - Setting.targetAlpha;

        //public const float fadeInSeconds = 0.25f;
        //public const float fadeOutSeconds = 0.35f;
        //public const float targetAlpha = 0.45f;
        while (currentAlpha- Setting.targetAlpha>0.01f)
        {
            currentAlpha = currentAlpha - /*distance /*/ Setting.fadeOutSeconds * Time.deltaTime;
            spriteRendere.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
            Debug.Log("spriteRendere.color>>"+spriteRendere.color);
        }

        //spriteRendere.color = new Color(1f, 1f, 1f, Setting.targetAlpha);
        Debug.Log("spriteRendere.color = new Color(1f, 1f, 1f, Setting.targetAlpha)>>" + (spriteRendere.color = new Color(1f, 1f, 1f, Setting.targetAlpha)));
       
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
