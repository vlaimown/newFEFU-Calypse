using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayers : MonoBehaviour
{
    public float offset = 0;
    private int sortingOrderBase = 0;
    private Renderer myrenderer;

    private void Awake()
    {
        myrenderer = GetComponent<Renderer>();
        sortingOrderBase = myrenderer.sortingOrder;
    }

    private void LateUpdate()
    {
        myrenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y + offset);
    }
}
