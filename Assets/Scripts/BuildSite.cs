using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BuildSite : MonoBehaviour, IPointerDownHandler
{
    public static event Action<Transform> OnClickEvent;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnClickEvent(transform.root);
        print("asd");
    }
    public static void HideControls()
    {
        OnClickEvent(null);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
