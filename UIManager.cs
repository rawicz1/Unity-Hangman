using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // Reference to the main menu panel
    public GameObject settingsPanel;
    public GameObject gameOverPanel;
    public GameObject gamePanel;
    public GameObject remainingAttemptsPanel;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;
    public GameObject getWordFromPlayerPanel;

    public ButtonManager buttonManager;
    public LetterButtonManager letterButtonManager;

    WordList wordList;

    public TextMeshProUGUI wordDisplay;
    public TextMeshProUGUI gameWonWordDisplay;
    public TextMeshProUGUI gameLostWordDisplay;
 
    void Start()
    {
        //ResetScreen();       
        wordList = FindObjectOfType<WordList>(); // Find the WordListManager in the scene
        buttonManager = FindObjectOfType<ButtonManager>();        
    }

    public void OnStartGAmeButtonClicked()
    {
        GameManager.Instance.currentWord = wordList.GetRandomWord();
        //Debug.Log("word ===== " + GameManager.Instance.currentWord);
        GameManager.Instance.ChangeState(GameManager.GameState.Playing);
    }

    public void OnTwoPlayersGameButtonClicked()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.GetWordFromPlayer);
    }

    public void ResetScreen()
    {
        Debug.Log("resetting screen");
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(false);
        //remainingAttemptsPanel.SetActive(false);
        gameWonPanel.SetActive(false);      
        gameLostPanel.SetActive(false);
        getWordFromPlayerPanel.SetActive(false);       
    }

    public void ShowMainMenu()
    {        
        mainMenuPanel.SetActive(true); // Show the main menu at the start        
    }

    public void ShowSettingsMenu()
    {
        settingsPanel.SetActive(true);
    }

    public void ShowGameScreen()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        
        letterButtonManager = FindObjectOfType<LetterButtonManager>();
        letterButtonManager.ResetButtons();
    }

    public void ShowGameWon()
    {
        gamePanel.SetActive(false);
        gameWonPanel.SetActive(true);
    }

    public void ShowGameLost()
    {
        gamePanel.SetActive(false);
        gameLostPanel.SetActive(true);
    }

    public void UpdateWordDisplay(string display)
    {
        wordDisplay.text = display;
    }
    public void UpdateGameWonWordDisplay(string display)
    {
        gameWonWordDisplay.text = display;
    }

    public void UpdateGameLostWordDisplay(string display)
    {
        gameLostWordDisplay.text = display;
    }

    //public void UpdateAttemptsLeft(int attempts)
    //{
    //    attemptsLeftDisplay.text = "Attempts left: " + attempts;
    //}

    public void ShowGetInputFromPlayer()
    {
        mainMenuPanel.SetActive(false);
        getWordFromPlayerPanel.SetActive(true);
    }

    public void ExitGame()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.ExitGame);

    }


}



//using UnityEngine;
//using UnityEngine.UI;

//public class UIManager : MonoBehaviour
//{
//    public Text wordDisplay;
//    public Text attemptsLeftDisplay;
//    public InputField inputField;
//    public GameObject gameOverPanel;
//    public GameObject mainMenuPanel; // Reference to the main menu panel

//    private void Start()
//    {
//        gameOverPanel.SetActive(false);
//        mainMenuPanel.SetActive(true); // Show the main menu at the start
//    }

//    public void OnGuessButtonClicked()
//    {
//        string input = inputField.text.ToLower();
//        if (input.Length == 1)
//        {
//            GameManager.Instance.GuessLetter(input[0]); // Accessing the singleton instance
//        }
//        inputField.text = "";
//    }

//    public void UpdateWordDisplay(string display)
//    {
//        wordDisplay.text = display;
//    }

//    public void UpdateAttemptsLeft(int attempts)
//    {
//        attemptsLeftDisplay.text = "Attempts Left: " + attempts;
//    }

//    public void ShowGameOver(bool won)
//    {
//        gameOverPanel.SetActive(true);
//        gameOverPanel.GetComponentInChildren<Text>().text = won ? "You Won!" : "Game Over! The word was: " + GameManager.Instance.currentWord;
//    }

//    public void ShowMainMenu()
//    {
//        mainMenuPanel.SetActive(true);
//    }

//    public void HideMainMenu()
//    {
//        mainMenuPanel.SetActive(false);
//    }
//}
