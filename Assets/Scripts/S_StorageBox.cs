//using UnityEngine;

//using UnityEngine.UI;

public class S_StorageBox
{
    public (string nameID, int tier) _fish {get; private set;}
    public bool isUnlocked {get; private set;} = false;
    public  bool isEmpty  {get; private set;} = true;
    
    //[SerializeField] GameObject fishSprite;
    //[SerializeField] Animator m_Animator;
    //Image fishSpriteImage;


    void Start()
    {
        //fishSpriteImage = fishSprite.GetComponent<Image>();
    }
    public void AddFish((string nameID, int tier) fish)
    {
        _fish = fish;
        
        isEmpty = false;
    }

    public void RemoveFish()
    {
        isEmpty = true;
        //fishSprite.SetActive(false);
    }

    public void UnlockBox()
    {
        isUnlocked = true;
        //m_Animator.SetBool("IsUnlocked",true);
    }

    //TODO: onclick
}
