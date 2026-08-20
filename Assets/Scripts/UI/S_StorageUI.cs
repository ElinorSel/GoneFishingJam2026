using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class S_StorageUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //[SerializeField] Image InventoryBox;

    
    [SerializeField] Image[] test;
    [SerializeField] Image testImage;
    [SerializeField] Sprite testSprite;
    [SerializeField] S_StorageBoxVisual[] storageBoxVisuals;
    [SerializeField] GameObject[] storageBoxVisualsGO;
    [SerializeField] S_StorageManager storageManager;



    void OnEnable()
    {
        ReadState();
        storageManager.OnFishAdded += HandleFishAdded;
        storageManager.OnBoxUnlocked += HandleBoxUnlocked;
    }

    void OnDisable()
    {
        storageManager.OnFishAdded -= HandleFishAdded;
        storageManager.OnBoxUnlocked -= HandleBoxUnlocked;
    }

    void HandleFishAdded(int boxIndex )
    { 
        (string nameID, int tier) fish = storageManager.StorageBoxes[boxIndex]._fish;

        GameObject fishSpriteGO = storageBoxVisualsGO[boxIndex];
        //Image fishSpriteImage = fishSpriteGO.GetComponent<Image>();
        //fishSpriteImage.sprite = S_FishData.Instance.GetFishSprite( fish.nameID, fish.tier);
        test[boxIndex].sprite = S_FishData.Instance.GetFishSprite( fish.nameID, fish.tier);
        
        fishSpriteGO.SetActive(true);

    }

    void HandleBoxUnlocked(int boxIndex)
    {
        storageBoxVisuals[boxIndex].M_Animator.SetBool("IsUnlocked",true);
    }

    public void HandleRemoveFish(int boxIndex)
    {
        //storageBoxVisuals[boxIndex].FishSprite.SetActive(false);
    }

    void ReadState()
    {

        Debug.Log(storageManager.StorageBoxes);
        for(int i = 0; i< storageManager.StorageBoxes.Length; i++)
        {
            
            if (!storageManager.StorageBoxes[i].isEmpty)
            {
                (string nameID, int tier) fish = storageManager.StorageBoxes[i]._fish;

                GameObject fishSpriteGO = storageBoxVisualsGO[i];
                fishSpriteGO.SetActive(true);
                Image fishSpriteImage = fishSpriteGO.GetComponent<Image>();
                fishSpriteImage.sprite = S_FishData.Instance.GetFishSprite( fish.nameID, fish.tier);
            }

            if (storageManager.StorageBoxes[i].isUnlocked)
            {
                storageBoxVisuals[i].M_Animator.SetBool("IsUnlocked",true);
            }

            
        }
    }
}
