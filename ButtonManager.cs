using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    GameManager gameManager;
    public SettingsManager settingsManager;

    private void Start()
    {
        //settingsManager = GetComponent<SettingsManager>();
       // Debug.Log("settings manager = " +settingsManager);
    }
    public void ChangeDifficultyButton(GameObject buttonObject)
    {
        // Get the Button component from the GameObject
        Button button = buttonObject.GetComponent<Button>();
        string buttonName = button.name;
       // Debug.Log("Button clicked: " + buttonName);

        switch (buttonName)
        {
            case "SettingsEasyButton":
                GameManager.Instance.SetDifficulty(9);
                Debug.Log("difficulty in gamemanager = " + GameManager.Instance.GetDifficulty());
                break;
            case "SettingsNormal":
                GameManager.Instance.SetDifficulty(7);
                Debug.Log("difficulty in gamemanager = " + GameManager.Instance.GetDifficulty());
                break;
            case "SettingsHard":
                GameManager.Instance.SetDifficulty(5);
                Debug.Log("difficulty in gamemanager = " + GameManager.Instance.GetDifficulty());
                break;
        }
        settingsManager = FindObjectOfType<SettingsManager>();
        settingsManager.UpdateDifficultyDisplay();
    }
    public void ShowSettingsButton()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Settings);
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("from button script changing to main menu");
        GameManager.Instance.ChangeState(GameManager.GameState.MainMenu);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        // If we are in the Unity editor, stop playing the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Otherwise, quit the application
        Application.Quit();
#endif
    }
}
