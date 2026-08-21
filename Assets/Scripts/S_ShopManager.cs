using UnityEngine;

public class S_ShopManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] S_GameManager gameManager;
    [SerializeField] S_StorageManager storageManager;
    [SerializeField] int storageSlotBuys = 10;
    [SerializeField] int maxspeedIncreases = 5;
    public float skillUpgradePrice = 500;
    public float storageSlotPrice = 50f;
     public float autoFisher1Price = 600;
     public float autoFisher2Price = 1000;
     public float autoFisher3Price = 2000;
     public float luckUpgradePrice = 2000;
    public float speedUpgradePrice = 100;
    int boxsBought = 0;
    int speedIncreasesBought = 0;


    public void BuyStorageSlot()
    {
        if (boxsBought < 10)
        {
            if (gameManager.TryBuy(storageSlotPrice))
            {
                storageManager.UnlockBox();
                boxsBought++;
                //storageSlotPrice += 100f;
            }
        }

    }
        public void BuyAutoFisher1()
    {
            if (gameManager.TryBuy(autoFisher1Price))
            {
                gameManager.AddAutoFisher("Svante");
                //storageSlotPrice += 100f;
            }
    }
        public void BuyAutoFisher2()
    {
            if (gameManager.TryBuy(autoFisher2Price))
            {
                gameManager.AddAutoFisher("Fjodor");
                //storageSlotPrice += 100f;
            }
    }


    public void UpgradeSkillLevel()
    {
        if (gameManager.PlayerFisher.Stats.skill < 2)
        {
            if (gameManager.TryBuy(skillUpgradePrice))
            {
                gameManager.IncreaseSkillLvl();
                skillUpgradePrice += 500f;
            }
        }
    }

        public void UpgradeLuckLevel()
    {
        if (gameManager.PlayerFisher.Stats.luck < 2)
        {
            if (gameManager.TryBuy(luckUpgradePrice))
            {
                gameManager.IncreaseLuckLvl();
                luckUpgradePrice += 1000f;
            }
        }
    }
    
        public void UpgradeSpeedLevel()
    {
        if (speedIncreasesBought < 5)
        {
            if (gameManager.TryBuy(speedUpgradePrice))
            {
                gameManager.IncreaseSpeed();
                speedIncreasesBought++;
                speedUpgradePrice += 80f;
            }
        }
    }

}
