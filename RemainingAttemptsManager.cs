using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingAttemptsManager : MonoBehaviour
{
    public GameObject heartIconPrefab; // Prefab for the letter button
    public Transform remainingAttemptsPanel; // Panel to hold the buttons

    int attempts;

    
    void Start()
    {
        attempts = GameManager.Instance.GetDifficulty();
        Debug.Log(attempts + " instatiating heart");
       // UpdateRemainingsAttemptsDisplay();
    }

    public void UpdateRemainingsAttemptsDisplay(int attempts)
    {

        Debug.Log(" instatiating heart");
        foreach (Transform child in remainingAttemptsPanel)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < attempts; i++)
        {
            Debug.Log(i + " instatiating heart");
            Instantiate(heartIconPrefab, remainingAttemptsPanel);
        }        
    }    
}
