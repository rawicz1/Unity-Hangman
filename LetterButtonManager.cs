using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterButtonManager : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab for the letter button
    public Transform buttonPanel; // Panel to hold the buttons

    private List<GameObject> buttons = new List<GameObject>(); // List to hold all button instances

    private void Start()
    {
        CreateLetterButtons();
    }

    private void CreateLetterButtons()
    {
        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            CreateButton(letter.ToString());
        }
    }

    private void CreateButton(string letter)
    {
        GameObject button = Instantiate(buttonPrefab, buttonPanel);
        button.GetComponentInChildren<TextMeshProUGUI>().text = letter; // Set button text
        button.GetComponent<Button>().onClick.AddListener(() => OnLetterButtonClicked(letter, button));
        buttons.Add(button); // Add the button to the list
    }

    private void OnLetterButtonClicked(string letter, GameObject button)
    {
        Debug.Log("letter = " + letter);
        button.GetComponentInChildren<TextMeshProUGUI>().color = Color.black; // Set button text color
        GameManager.Instance.GuessLetter(letter[0]); // Call the GuessLetter method in GameManager
    }

    public void ChangeWarninngColor(Color color)
    {
        foreach (GameObject button in buttons) // Iterate through all buttons
        {
            if(button.GetComponentInChildren<TextMeshProUGUI>().color != Color.black)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().color = color; // Reset button text color
            }
            
        }
    }
    public void ResetButtons()
    {
        foreach (GameObject button in buttons) // Iterate through all buttons
        {
            button.GetComponentInChildren<TextMeshProUGUI>().color = Color.white; // Reset button text color
        }
    }
}
