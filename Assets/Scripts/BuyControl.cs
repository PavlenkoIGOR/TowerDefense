using System.Collections.Generic;
using UnityEngine;

public class BuyControl : MonoBehaviour
{
    [SerializeField] private TowerBuyControl _towerBuyPref;
    [SerializeField] private TowerAsset[] _towerAssets;
    [SerializeField] private UpgradeAsset _mageTowerUpgrade;
    private List<TowerBuyControl> _activeControls;
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
            _activeControls = new List<TowerBuyControl>();
            for (int i = 0; i < _towerAssets.Length; i++)
            {

                if (i != 1 || Upgrades.GetUpgradeLevel(_mageTowerUpgrade) > 0)
                {
                    var newControl = Instantiate(_towerBuyPref, transform);
                    _activeControls.Add(newControl);
                    newControl.transform.position += Vector3.left * 88 * i;
                    newControl.SetTowerAsset(_towerAssets[i]);
                }

            }

        }
        else
        {
            foreach (var control in _activeControls)
            {
                Destroy(control.gameObject);
            }
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
    private void OnDestroy()
    {
        BuildSite.OnClickEvent -= MoveToBuiltSite;
    }
}
