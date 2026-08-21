using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class S_StorageZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject interactionUI;
    [SerializeField] GameObject storageUI;
    [SerializeField] TextMeshProUGUI interactionText;
    [SerializeField] S_GameManager gameManager;
    private InputAction _interactAction;
    private bool inZone;

        void Start()
    {
       
        _interactAction = InputSystem.actions.FindAction("Interact1");
    }
    void OnTriggerEnter(Collider other)
    {
        interactionText.text = "press f to open storage";
        interactionUI.SetActive(true);
        inZone = true;
    }

    void Update()
    {
        if (inZone)
        {
             if (_interactAction.WasPressedThisFrame())
            {
                storageUI.SetActive(!storageUI.activeSelf);
            }
        }
    }
    void OnTriggerStay()
    {
        interactionUI.SetActive(!storageUI.activeSelf);
    }
    void OnTriggerExit(Collider other)
    {
        interactionUI.SetActive(false);
        storageUI.SetActive(false);
        inZone = false;
    }
}
