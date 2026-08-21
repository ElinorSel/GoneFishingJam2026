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
    [SerializeField] S_GameManager gameManager;
    private InputAction _interactAction;
    private bool inZone;
    void Start()
    {
       
        _interactAction = InputSystem.actions.FindAction("Interact1");
    }
    void OnTriggerEnter(Collider other)
    {
         interactionText.text = "press f to Shop";
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
        UICheckStorageUnlock();
        UISkillCheck();

    }
    void OnTriggerExit(Collider other)
    {
        interactionUI.SetActive(false);
        shopUI.SetActive(false);
        inZone = false;
    }

    void UICheckStorageUnlock()
    {
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
        if(shopManager.skillUpgradePrice > gameManager.Money)
        {
            skillLvlButton.interactable = false;
        }
        else
        {
            skillLvlButton.interactable = true;
        }
    }
}
