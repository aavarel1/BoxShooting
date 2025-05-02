using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int Score = 0;
    public bool CanBeatLevel = false;
    public int BeatLevelScore = 0;
    public int StartTime = 5;
    public TMP_Text MainScoreDisplay;
    public TMP_Text MainTimerDisplay;
    public GameObject GameOverScoreOutline;
    public AudioClip MusicAudioSource;
    public GameObject PlayAgainButton;
    public String PlayAgainLevelToLoad;
    public GameObject NextLevelButton;
    public String NextLevelToLoad;
    private float currentTime;

    [HideInInspector]
    public bool gameIsOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = StartTime; // set the current time to the startTime specified
        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();
        MainScoreDisplay.text = "0"; // init scoreboard to 0
        // inactivate the gameOverScoreOutline gameObject, if is is set
        if (GameOverScoreOutline)
            GameOverScoreOutline.SetActive(false);
        // inactivate the PlayAgainButton gameObject, if is is set
        if (PlayAgainButton)
            PlayAgainButton.SetActive(false);
        // inactivate the NextLevelButton gameObject, if is is set
        if (NextLevelButton)
            NextLevelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
        { // check to see if game is over
            if (CanBeatLevel && Score >= BeatLevelScore)
            { // check to see if beat game
                BeatLevel();
            }
            else if (currentTime <= 0)
            { // check to see if time is up
                EndGame();
            }
            else
            { // game playing state, so update the timer
                currentTime -= Time.deltaTime; // decrement current time by the time since last frame
                MainTimerDisplay.text = currentTime.ToString("0"); // update the timer display
            }
        }
    }

    void EndGame()
    {
        // set the game over state
        gameIsOver = true;
        // repurpose the timer to display the game over message
        MainTimerDisplay.text = "Game Over";
        // activate the gameOverScoreOutline gameObject, if is is set
        if (GameOverScoreOutline)
            GameOverScoreOutline.SetActive(true);
        // activate the PlayAgainButton gameObject, if it is set
        if (PlayAgainButton)
            PlayAgainButton.SetActive(true);
    }

    void BeatLevel()
    {
        // set the game over state
        gameIsOver = true;
        // repurpose the timer to display the game over message
        MainTimerDisplay.text = "LEVEL COMPLETE";
        // activate the gameOverScoreOutline gameObject, if it is set
        if (GameOverScoreOutline)
            GameOverScoreOutline.SetActive(true);
        // activate the NextLevelButton gameObject, if it is set
        if (NextLevelButton)
            NextLevelButton.SetActive(true);
    }

    public void AddScore(int score)
    {
        Score += score; // add the score to the total
        MainScoreDisplay.text = Score.ToString(); // update the scoreboard display
    }

    public void NextLevel()
    {
        Debug.Log("Trying to load scene: " + NextLevelToLoad);
        SceneManager.LoadScene(NextLevelToLoad); // load the specified level
    }

    public void QuitGame()
    {
        Application.Quit(); // quit the game
    }

    public void RestartGame()
    {
        Debug.Log("Trying to load scene: " + PlayAgainLevelToLoad);
        SceneManager.LoadScene(PlayAgainLevelToLoad); // reload the current level
    }

    public void targetHit(int scoreAmount, float timeAmount)
    {
        Score += scoreAmount; // add the score to the total
        MainScoreDisplay.text = Score.ToString(); // update the scoreboard display
        currentTime += timeAmount; // add the timeAmount to the current time
        if (currentTime < 0)
        { // don't let it go negative
            currentTime = 0.0f;
        }
        MainTimerDisplay.text = currentTime.ToString("0.00"); // update the timer display
    }
}
