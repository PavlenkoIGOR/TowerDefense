using UnityEngine;

public class BuyControl : MonoBehaviour
{
    private RectTransform t;
    public float gizmoRad = 10.0f;
    private void Awake()
    {
        t = GetComponent<RectTransform>();
        BuildSite.OnClickEvent += MoveToBuiltSite;
        gameObject.SetActive(false);


    }

    private void MoveToBuiltSite(Transform target)
    {
        if (target)
        {
            var position = Camera.main.WorldToScreenPoint(target.position);
            t.anchoredPosition = position;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        foreach (var tbc in GetComponentsInChildren<TowerBuyControl>())
        {
            tbc.SetBuildSite(target);
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (t == null)
            t = GetComponent<RectTransform>();

        Vector3 worldPos = t.position; // или преобразуйте из anchoredPosition при необходимости
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(worldPos, gizmoRad);
    }
}
