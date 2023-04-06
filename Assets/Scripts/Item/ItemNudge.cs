using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNudge : MonoBehaviour
{
    private WaitForSeconds pause;
    private bool isAnimating = false;


    private void Awake()
    {
        pause = new WaitForSeconds(0.04f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAnimating==false)
        {
            if (gameObject.transform.position.x < collision.transform.position.x)
            {
                StartCoroutine(RotateAntiClockWise());
            }
            else
            {
                StartCoroutine(RotateClockWise());
            }
        }
       
    }// Ends On Trigger 



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isAnimating == false)
        {
            if (gameObject.transform.position.x > collision.transform.position.x)
            {
                StartCoroutine(RotateAntiClockWise());
            }
            else
            {
                StartCoroutine(RotateClockWise());
            }
        }


    }// Ends On Trigger




    IEnumerator RotateAntiClockWise()
    {

        isAnimating = true;

        for (int i = 0; i < 5; i++)
        {
            // gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 2f));
            gameObject.transform.GetChild(0).Rotate(0, 0, 2f);

            yield return null;
        }

        for (int i = 0; i < 5; i++)
        {
            // gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 2f));
            gameObject.transform.GetChild(0).Rotate(0, 0, -2f);

            yield return null;
        }
        //  gameObject.transform.GetChild(0).Rotate(0, 0, 2f);

        yield return null;

        isAnimating = false;

    }

    IEnumerator RotateClockWise()
    {
        isAnimating = true;

        for (int i = 0; i < 5; i++)
        {
            // gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 2f));
            gameObject.transform.GetChild(0).Rotate(0, 0, -2f);

          yield return null;
        }

        for (int i = 0; i < 5; i++)
        {
            // gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 2f));
            gameObject.transform.GetChild(0).Rotate(0, 0, 2f);

            yield return null;
        }
       // gameObject.transform.GetChild(0).Rotate(0, 0, -2f);

        yield return null;

        isAnimating = false;
    }

}// Ends Class
