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

    public static int GetTotalCost()
    {
        int result = 0;
        foreach (var upgrade in Instance._saves)
        {
            for (int i = 0; i < upgrade.level; i++)
            {
                result += upgrade.asset.costByLvl[i];
            }
        }
        return result;
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
