using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayDifficulty;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDifficultyDisplay();
    }

    public void UpdateDifficultyDisplay()
    {
        displayDifficulty.text = "Difficulty: " + GameManager.Instance.GetDifficulty() + " attempts";
    }
}
