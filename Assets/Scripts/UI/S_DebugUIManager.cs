using UnityEngine;
using TMPro;

public class S_DebugUIManager : MonoBehaviour
{
    S_GameManager gameManager;
    [SerializeField] TMP_Text moneyLable;
    [SerializeField] TMP_Text passiveIncomeLable;

    

    void Start()
    {
        gameManager = FindFirstObjectByType<S_GameManager>();
    }

    void Update()
    {
        moneyLable.text = gameManager.Money.ToString();
        passiveIncomeLable.text = gameManager.GetCurrentPassiveIncome().ToString() + " per second";
    }
}
