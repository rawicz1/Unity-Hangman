using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance

    public UIManager uiManager;
    ButtonManager buttonManager;
    WordList wordList;
    RemainingAttemptsManager remainingAttemptsManager;
    LetterButtonManager letterButtonManager;

    public string currentWord;
    private List<char> guessedLetters = new List<char>();
    private int maxAttempts; // getter and setter below
    private int attemptsLeft;
    public enum GameState
    {
        MainMenu,
        Settings,
        GetWordFromPlayer,
        Playing,
        GameWon,
        GameLost,
        ExitGame
    }

    public GameState currentState;

    private void Awake()
    {
        maxAttempts = 7;
        // Ensure that there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        wordList = FindObjectOfType<WordList>(); // Find the WordListManager in the scene
        buttonManager = FindObjectOfType<ButtonManager>();
        remainingAttemptsManager = FindObjectOfType<RemainingAttemptsManager>();       
        
        ChangeState(GameState.MainMenu); // Start in the main menu

    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.MainMenu:
                uiManager.ResetScreen();               
                uiManager.ShowMainMenu();
                break;
            case GameState.Settings:
                uiManager.ResetScreen();
                uiManager.ShowSettingsMenu();
                break;
            case GameState.GetWordFromPlayer:
                uiManager.ShowGetInputFromPlayer();
                break;
            case GameState.Playing:
                uiManager.ResetScreen();
                StartNewGame();
                break;
            case GameState.GameWon:
                uiManager.ShowGameWon();
                uiManager.UpdateGameWonWordDisplay(GetWordDisplay());
                break;
            case GameState.GameLost:
                uiManager.UpdateGameLostWordDisplay(currentWord);
                uiManager.ShowGameLost();
                break;
            case GameState.ExitGame:
                buttonManager.ExitGame();
                break;
        }
    }

    public void SetDifficulty(int attempts)
    {
        maxAttempts = attempts;
        //Debug.Log("max attempts = " + maxAttempts);
    }

    public int GetDifficulty()
    {
        return maxAttempts;
    }

    void StartNewGame()
    {
        attemptsLeft = maxAttempts;
        guessedLetters.Clear();
        uiManager.ShowGameScreen();
        uiManager.UpdateWordDisplay(GetWordDisplay());
        remainingAttemptsManager.UpdateRemainingsAttemptsDisplay(attemptsLeft);
       // uiManager.UpdateAttemptsLeft(attemptsLeft);        
    }


    public void GuessLetter(char letter)
    {       
        if (guessedLetters.Contains(letter))
            return;

        guessedLetters.Add(letter);

        if (!currentWord.Contains(letter.ToString()))        
            attemptsLeft--;        

        if(attemptsLeft <=2)
        {
            letterButtonManager = FindObjectOfType<LetterButtonManager>();
            if(attemptsLeft == 2) letterButtonManager.ChangeWarninngColor(Color.yellow);
            if(attemptsLeft == 1) letterButtonManager.ChangeWarninngColor(Color.red);
        }

        uiManager.UpdateWordDisplay(GetWordDisplay());
        remainingAttemptsManager.UpdateRemainingsAttemptsDisplay(attemptsLeft);
        // uiManager.UpdateAttemptsLeft(attemptsLeft);

        if (IsGameWon())
        {
            ChangeState(GameState.GameWon);
        }

        if (IsGameLost())
        {
            ChangeState(GameState.GameLost);
        }
    }
    
    bool IsGameLost()
    {
        if(attemptsLeft <= 0)
        {
            return true;
        }
        return false;
    }

    bool IsGameWon()
    {
        return IsWordGuessed();
    }

    private bool IsWordGuessed()
    {
        foreach (char letter in currentWord)
        {
            if (!guessedLetters.Contains(letter))
                return false;
        }        
        return true;
    }

    private string GetWordDisplay()
    {
        string display = "";
        foreach (char letter in currentWord)
        {
            display += guessedLetters.Contains(letter) ? letter.ToString() + " " : "_ ";            
        }
        return display;
    }
}

