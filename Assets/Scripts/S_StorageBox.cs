using UnityEngine;

using UnityEngine.UI;

public class S_StorageBox : MonoBehaviour
{
    public (string nameID, int tier) _fish {get; private set;}
    public bool isUnlocked {get; private set;} = false;
    public  bool isEmpty  {get; private set;} = true;
    
    [SerializeField] GameObject fishSprite;
    Image fishSpriteImage;

    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        fishSpriteImage = fishSprite.GetComponent<Image>();
    }
    public void AddFish((string nameID, int tier) fish)
    {
        _fish = fish;
        fishSpriteImage.sprite = S_FishData.Instance.GetFishSprite( fish.nameID, fish.tier);
        fishSprite.SetActive(true);
        isEmpty = false;
    }

    public void RemoveFish()
    {
        isEmpty = true;
        fishSprite.SetActive(false);
    }

    public void UnlockBox()
    {
        isUnlocked = true;
        m_Animator.SetBool("IsUnlocked",true);
    }

    //TODO: onclick
}
