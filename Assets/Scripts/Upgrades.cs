using SpaceShooter;
using System;
using UnityEngine;
using static MapCompletion;

public class Upgrades : MonoSingleton<Upgrades>
{
    [Serializable]
    private class UpgradeSave
    {
        public UpgradeAsset asset;
        public int level = 0;
    }
    [SerializeField] private UpgradeSave[] _saves;
    public const string fileName = "upgrades.dat";
    public static void BuyUpgrade(UpgradeAsset upgradeAsset)
    {
        foreach (var upgrade in Instance._saves)
        {
            if (upgrade.asset == upgradeAsset)
            {
                upgrade.level++;
                Saver<UpgradeSave[]>.Save(fileName, Instance._saves);
            }
        }
    }
    private new void Awake()
    {
        base.Awake();
        Saver<UpgradeSave[]>.TryLoad(fileName, ref _saves);
    }

public static int GetUpgradeLevel(UpgradeAsset upgradeAsset)
    {
        foreach (var upgrade in Instance._saves)
        {
            if (upgrade.asset == upgradeAsset)
            {
                return upgrade.level;
            }
        }
        return 0;
    }
}
