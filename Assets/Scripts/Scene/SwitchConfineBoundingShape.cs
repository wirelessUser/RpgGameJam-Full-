using Cinemachine;
using UnityEngine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }
      private void SwitchBoundingShape()
    {
        PolygonCollider2D polygonCollide = GameObject.FindGameObjectWithTag(Tags.boundConfiner).GetComponent<PolygonCollider2D>();

        CinemachineConfiner cinemachienCOnfienr = GetComponent<CinemachineConfiner>();

        cinemachienCOnfienr.m_BoundingShape2D = polygonCollide;

        cinemachienCOnfienr.InvalidatePathCache();
    }









}
