using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonDelay : MonoBehaviour
{

    public Button myButton; // Reference to the button you want to show
    public float delay = 2f; // Delay in seconds
    
    void Start()
    {
       // myButton.gameObject.SetActive(false);
        Debug.Log("starting courutine.....");
        StartCoroutine(ShowButtonAfterDelay());
    }

    IEnumerator ShowButtonAfterDelay()
    {
        myButton.gameObject.SetActive(false);
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        Debug.Log("starting courutine.....inside courutine...");
        // Show the button
        myButton.gameObject.SetActive(true);
    }
}
