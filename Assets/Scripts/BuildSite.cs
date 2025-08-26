using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildSite : MonoBehaviour, IPointerDownHandler
{
    public TowerAsset[] buildableTowers;

    public void SetBuildableTowers(TowerAsset[] towers)
    {
        if (towers == null || towers.Length == 0) 
        {
            //gameObject.SetActive(false);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            buildableTowers = towers;

        }
    }
    public static event Action<BuildSite> OnClickEvent;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnClickEvent(this);
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
