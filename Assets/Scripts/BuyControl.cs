using System.Collections.Generic;
using UnityEngine;

public class BuyControl : MonoBehaviour
{
    [SerializeField] private TowerBuyControl _towerBuyPref;
    private List<TowerBuyControl> _activeControls;
    private RectTransform t;
    public float gizmoRad = 10.0f;
    private void Awake()
    {
        t = GetComponent<RectTransform>();
        BuildSite.OnClickEvent += MoveToBuiltSite;
        gameObject.SetActive(false);
    }

    private void MoveToBuiltSite(BuildSite buildSite)
    {
        if (buildSite)
        {
            gameObject.SetActive(true);
            print("MoveToBuiltSite");
            var position = Camera.main.WorldToScreenPoint(buildSite.transform.root.position);
            t.anchoredPosition = position;
            _activeControls = new List<TowerBuyControl>();
            foreach (var asset in buildSite.buildableTowers)
            {
                if (asset.isAvailable())
                {
                    var newControl = Instantiate(_towerBuyPref, transform);
                    _activeControls.Add(newControl);
                    newControl.SetTowerAsset(asset);
                }
            }

            if (_activeControls.Count > 0)
            {
                var angle = 360 / _activeControls.Count;
                for (int i = 0; i < _activeControls.Count; i++)
                {
                    var offset = Quaternion.AngleAxis(angle * i, Vector3.forward) * (Vector3.left * 80);
                    _activeControls[i].transform.position += offset;
                }
                foreach (var tbc in GetComponentsInChildren<TowerBuyControl>())
                {
                    tbc.SetBuildSite(buildSite.transform.root);
                }
            }

        }
        else
        {
            foreach (var control in _activeControls)
            {
                Destroy(control.gameObject);
            }
            _activeControls?.Clear();
            gameObject.SetActive(false);
        }

    }

    public void OnDrawGizmosSelected()
    {
        if (t == null)
            t = GetComponent<RectTransform>();

        Vector3 worldPos = t.position;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(worldPos, gizmoRad);
    }
    private void OnDestroy()
    {
        BuildSite.OnClickEvent -= MoveToBuiltSite;
    }
}
