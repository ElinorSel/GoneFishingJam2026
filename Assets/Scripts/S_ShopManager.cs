using UnityEngine;

public class S_ShopManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] S_GameManager gameManager;
    [SerializeField] S_StorageManager storageManager;
    [SerializeField] int storageSlotBuys = 10;
    public float storageSlotPrice = 50f;
    int boxsBought = 0;


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


}
