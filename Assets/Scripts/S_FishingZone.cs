using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class S_FishingZone : MonoBehaviour
{
    [SerializeField] GameObject interactionUI;
    [SerializeField] TextMeshProUGUI interactionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        interactionText.text = "fish";
    }
    void OnTriggerEnter(Collider other)
    {
        interactionUI.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exited");
    }
}
