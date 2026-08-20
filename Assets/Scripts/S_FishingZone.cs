using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class S_FishingZone : MonoBehaviour
{
    [SerializeField] GameObject interactionUI;
    [SerializeField] TextMeshProUGUI interactionText;
    [SerializeField] S_GameManager gameManager;
    private InputAction _interactAction;
    private bool inZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        interactionText.text = "press f to fish";
        _interactAction = InputSystem.actions.FindAction("Interact1");
    }
    void OnTriggerEnter(Collider other)
    {
        interactionUI.SetActive(true);
        inZone = true;
    }

    void Update()
    {
        if (inZone && !gameManager.PlayerIsFishing)
        {
             if (_interactAction.WasPressedThisFrame())
            {
                //Debug.Log("tried to fish");
                gameManager.PlayerFish();
            }
        }
    }
    void OnTriggerStay()
    {
        if (!gameManager.PlayerIsFishing)
        {
            interactionUI.SetActive(true);
           
        }
        else
        {
            interactionUI.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        interactionUI.SetActive(false);
        inZone = false;
    }
}
