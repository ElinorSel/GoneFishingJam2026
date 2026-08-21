using UnityEngine;
using TMPro;

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

    public bool autofish1Done = false;
    public bool autofish2Done = false;
      public bool speeddone = false;
        public bool luckdone = false;
          public bool skilldone = false;
          public bool storagedone = false;






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

        if (boxsBought == 10)
        {
            storagedone = true;
        }

    }
        public void BuyAutoFisher1()
    {
            if (gameManager.TryBuy(autoFisher1Price))
            {
                gameManager.AddAutoFisher("Svante");
                //storageSlotPrice += 100f;
                autofish1Done = true;
            }
    }
        public void BuyAutoFisher2()
    {
            if (gameManager.TryBuy(autoFisher2Price))
            {
                gameManager.AddAutoFisher("Fjodor");
                //storageSlotPrice += 100f;
                autofish2Done = true;
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
        if (gameManager.PlayerFisher.Stats.skill == 2)
        {
            skilldone = true;
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

        if (gameManager.PlayerFisher.Stats.luck == 2)
        {
            luckdone = true;
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

        if (speedIncreasesBought == 3)
        {
            speeddone = true;
        }
    }

}
