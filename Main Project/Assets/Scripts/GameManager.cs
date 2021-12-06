using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;

    // Main Menu aka Start menu variables.
    public Button startButton;
    public Button exitButton;
    public TextMeshProUGUI titleText;

    // Restart Menu (Game Over) variables
    public Button restartButton;
    public Button homeButton;
    public TextMeshProUGUI restartText;

    // Game Finished variables
    public Button continueButton;
    public TextMeshProUGUI levelCompletedText;
    public TextMeshProUGUI wellDoneText;



    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        StartMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMenu()
    {
        // Disabiling all Game Objects from GameOver()
        restartButton.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);

        // Disabiling all Game Objects from GameFinished()
        homeButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        levelCompletedText.gameObject.SetActive(false);
        wellDoneText.gameObject.SetActive(false);

        // Enabiling all Game Objects for this Menu
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        isGameActive = true;

        // Disabiling all Game Objects from StartMenu()
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        isGameActive = true;

        // Disabiling all Game Objects from GameOver()
        restartButton.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        isGameActive = false;

        // Enabiling all Game Objects for this Menu
        restartButton.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }

    public void GameFinished()
    {
        isGameActive = false;

        // Enabiling all Game Objects for this Menu
        homeButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        levelCompletedText.gameObject.SetActive(true);
        wellDoneText.gameObject.SetActive(true);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
