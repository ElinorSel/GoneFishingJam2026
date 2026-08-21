using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_ShoppingZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject interactionUI;
    [SerializeField] GameObject shopUI;
    [SerializeField] TextMeshProUGUI interactionText;
    [SerializeField] S_ShopManager shopManager;
    [SerializeField] Button storageSlotButton;
    [SerializeField] Button skillLvlButton;
    [SerializeField] Button luckLvlButton;
    [SerializeField] Button speedButton;
     [SerializeField] Button autofisher1;
     [SerializeField] Button autofisher2;
    [SerializeField] S_GameManager gameManager;


    //_______________price text ref


        [SerializeField] TextMeshProUGUI speedtxt;
    [SerializeField] TextMeshProUGUI skilltxt;
    [SerializeField] TextMeshProUGUI lucktxt;
    [SerializeField] TextMeshProUGUI autofisher1txt;
     [SerializeField] TextMeshProUGUI autofisher2txt;
    [SerializeField] TextMeshProUGUI storagetxt;



    private InputAction _interactAction;
    private bool inZone;



    void Start()
    {
       
        _interactAction = InputSystem.actions.FindAction("Interact1");
    }
    void OnTriggerEnter(Collider other)
    {
         interactionText.text = "Press F to Shop";
        interactionUI.SetActive(true);
        inZone = true;
    }

    void Update()
    {
        if (inZone)
        {
             if (_interactAction.WasPressedThisFrame())
            {
                shopUI.SetActive(!shopUI.activeSelf);
            }
        }
    }
    void OnTriggerStay()
    {
        interactionUI.SetActive(!shopUI.activeSelf);
        
        
        if (shopManager.storagedone != true)
        {
            UICheckStorageUnlock();
            
        }
        else
        {
            storageSlotButton.interactable = false;
        }

        if (shopManager.skilldone != true)
        {
             UISkillCheck();
            
        }
        else
        {
            skillLvlButton.interactable = false;
        }
        
       
        if (shopManager.autofish1Done != true)
        {
            Autofish1Check();
            
        }
        else
        {
            autofisher1.interactable = false;
        }
        if (!shopManager.autofish1Done)
        {
            Autofish2Check();
        }
        else
        {
            autofisher2.interactable = false;
        }

                if (shopManager.luckdone != true)
        {
             UIluckCheck();
            
        }
        else
        {
            luckLvlButton.interactable = false;
        }
        
                if (shopManager.speeddone != true)
        {
             UISpeedCheck();
            
        }
        else
        {
            speedButton.interactable = false;
        }
        
       
       

    }
    void OnTriggerExit(Collider other)
    {
        interactionUI.SetActive(false);
        shopUI.SetActive(false);
        inZone = false;
    }

    void UICheckStorageUnlock()
    {
        storagetxt.text = shopManager.storageSlotPrice.ToString();
        if(shopManager.storageSlotPrice > gameManager.Money)
        {
            storageSlotButton.interactable = false;
        }
        else
        {
            storageSlotButton.interactable = true;
        }
    
    }
    void UISkillCheck()
    {
        skilltxt.text = shopManager.skillUpgradePrice.ToString();
        if(shopManager.skillUpgradePrice > gameManager.Money)
        {
            skillLvlButton.interactable = false;
        }
        else
        {
            skillLvlButton.interactable = true;
        }
    }
     void UIluckCheck()
    {
        lucktxt.text = shopManager.luckUpgradePrice.ToString();
        if(shopManager.luckUpgradePrice > gameManager.Money)
        {
            luckLvlButton.interactable = false;
        }
        else
        {
            luckLvlButton.interactable = true;
        }
    }
         void UISpeedCheck()
    {
        speedtxt.text = shopManager.speedUpgradePrice.ToString();
        if(shopManager.speedUpgradePrice > gameManager.Money)
        {
            speedButton.interactable = false;
        }
        else
        {
            speedButton.interactable = true;
        }
    }
        void Autofish1Check()
    {
        autofisher1txt.text = shopManager.autoFisher1Price.ToString();
        if(shopManager.skillUpgradePrice > gameManager.Money)
        {
            autofisher1.interactable = false;
        }
        else
        {
            autofisher1.interactable = true;
        }
    }
            void Autofish2Check()
    {
        autofisher2txt.text = shopManager.autoFisher2Price.ToString();
        if(shopManager.skillUpgradePrice > gameManager.Money)
        {
            autofisher2.interactable = false;
        }
        else
        {
            autofisher2.interactable = true;
        }
    }
}
