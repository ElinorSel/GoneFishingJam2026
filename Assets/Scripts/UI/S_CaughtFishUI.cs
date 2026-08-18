using UnityEngine;
using TMPro;

public class S_CaughtFishUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    S_GameManager gameManager;
    [SerializeField] TMP_Text sellLabel;

    [SerializeField] GameObject caughtFishUI;
    private float _sellPrice;
    string _nameID;
    int _tier;

    

    void Start()
    {
        gameManager = FindFirstObjectByType<S_GameManager>();
        gameManager.OnFishCaught += OpenUI;
    }

      private void OnDestroy()
    {
        gameManager.OnFishCaught -= OpenUI;
    }


    void OpenUI(string nameID, int tier)
    {
          _sellPrice = S_FishData.Instance.GetFishSellPrice(nameID, tier);
          sellLabel.text = _sellPrice.ToString(); 
          _nameID = nameID;
          _tier = tier;

        caughtFishUI.SetActive(true);

    }

    public void KeepFish()
    {
        gameManager.HandleAddFish(_nameID, _tier);
        caughtFishUI.SetActive(false);
    }

    public void SellFish()
    {
        gameManager.HandleSellFish(_nameID, _tier);
        caughtFishUI.SetActive(false);
        
    }
}
