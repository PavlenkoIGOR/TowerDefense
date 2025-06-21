using System;
using UnityEngine;

public class BuyControl : MonoBehaviour
{
    private RectTransform t;
    private void Awake()
    {
        t = GetComponent<RectTransform>();
        BuildSite.OnClickEvent += MoveToTransform;
        gameObject.SetActive(false);
    }

    private void MoveToTransform(Transform target)
    {
        var position = Camera.main.WorldToScreenPoint(target.position);
        t.anchoredPosition = position;
        gameObject.SetActive(true);
    }
}
