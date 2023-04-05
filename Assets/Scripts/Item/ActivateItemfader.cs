
using UnityEngine;

public class ActivateItemfader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObscutingItemFader[] obscuringItemfader = collision.gameObject.GetComponentsInChildren<ObscutingItemFader>();

        if (obscuringItemfader.Length>0)
        {
            for (int i = 0; i < obscuringItemfader.Length; i++)
            {
                obscuringItemfader[i].FadeOut();
            }
        }
    }// End trigger enter


    private void OnTriggerExit2D(Collider2D collision)
    {
        ObscutingItemFader[] obscuringItemfader = collision.gameObject.GetComponentsInChildren<ObscutingItemFader>();
        if (obscuringItemfader.Length > 0)
        {
            for (int i = 0; i < obscuringItemfader.Length; i++)
            {
                obscuringItemfader[i].FadeIn();
            }
        }
    }// End triger Exit
}
