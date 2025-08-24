using SpaceShooter;
using TD;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class TowerAsset : ScriptableObject
{
    public int gold = 15;
    public Sprite towerGUI;
    public Sprite sprite;
    public Tower tower;
    public TurretProperties turretProperties;
}

