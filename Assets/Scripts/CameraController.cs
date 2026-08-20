using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject _standardCamera;
    [SerializeField] private GameObject _fishingCamera;
    [SerializeField] private GameObject _aquariumCamera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _standardCamera.SetActive(true);
        _fishingCamera.SetActive(false);
        _aquariumCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Aquarium"))
        {
            _aquariumCamera.SetActive(true);
        }
        else if (other.CompareTag("Fishing"))
        {
            _fishingCamera.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Aquarium"))
        {
            _aquariumCamera.SetActive(false);
        }
        else if (other.CompareTag("Fishing"))
        {
            _fishingCamera.SetActive(false);
        }
    }
}
