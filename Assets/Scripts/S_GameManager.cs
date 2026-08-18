using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    [SerializeField] float _money;
    [SerializeField] S_Aquarium aquarium;

    
    public float Money => _money;

    public void AddMoney(float value)
    {
        _money += value;
    }
    public bool RemoveMoney(float value)
    {
        if(value > _money)
        {
            return false;
        }
        _money -= value;
        return true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerFish()
    {
        aquarium.AddFish("Aborre", 0); 
    }
}
