using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public TMP_InputField inputField; // Reference to the InputField

    public void OnWordInput()
    {
        string inputData = inputField.text.ToUpper(); // Get the text from the InputField
        GameManager.Instance.currentWord = inputData;
        inputField.text = "ENTER YOUR WORD HERE...";
        GameManager.Instance.ChangeState(GameManager.GameState.Playing);
        Debug.Log("from input manager" + inputData);
    }
}
