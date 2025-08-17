using UnityEngine;

[CreateAssetMenu]
public class UpgradeAsset : ScriptableObject
{
    [Header("Visual")]
    public Sprite upgradeSprite;

    [Header("GameParams")]
    public int[] costByLvl = { 3 };




}
