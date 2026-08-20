using UnityEngine;
using UnityEngine.InputSystem;

public class S_Interactor : MonoBehaviour
{
    [SerializeField] private GameObject _interactionUI;
    private InputAction _interactAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        _interactionUI.SetActive(true);
    }
}
