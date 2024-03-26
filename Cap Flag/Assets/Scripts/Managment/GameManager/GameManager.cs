using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float StartGameTimer = 0;
    public float playerScore = 0;
    public float aiScore = 0;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject AiEnemy;
    [SerializeField] GameObject AiEnemyFlag;
    [SerializeField] GameObject PlayerFlag;
    [SerializeField] TMP_Text PlayerScoreTXT;
    [SerializeField] TMP_Text AiScoreTXT;
    [SerializeField] GameObject playerStartPoint;
    [SerializeField] GameObject aiStartPoint;
    [SerializeField] GameObject playerFlagStartPoint;
    [SerializeField] GameObject aiFlagStartPoint;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TMP_Text GameOverWinner;
    [SerializeField] TMP_Text GameOverPlayerScoreTXT;
    [SerializeField] TMP_Text GameOverAiScoreTXT;
    [SerializeField] TMP_Text PlayerHasFlagTXT;
    [SerializeField] TMP_Text AiHasFlagTXT;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
           
        PlayerScoreTXT.text = "Player Score: " + playerScore;
        AiScoreTXT.text = "Ai Score: " + aiScore;
        PlayerNoFlag();
        AiNoFlag();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartGameTimer <= 5)
        {
            StartGameTimer = Time.unscaledTime;
        }
        if (StartGameTimer >= 5)
        {
            Time.timeScale = 1f;
        }
        if(playerScore >= 5)
        {
            playerWin();
        }
        if(aiScore >= 5)
        {
            EnemyWin();
        }
    }
    public void playerWin()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
        GameOverWinner.text = "Player Wins";
        GameOverPlayerScoreTXT.text = "Player Score: " + playerScore;
        GameOverAiScoreTXT.text = "Ai Score: " + aiScore;
    }
    public void EnemyWin()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
        GameOverWinner.text = "Ai Wins";
        GameOverPlayerScoreTXT.text = "Player Score: " + playerScore;
        GameOverAiScoreTXT.text = "Ai Score: " + aiScore;
    }
    public void ResetLevel()
    {
        PlayerFlag.transform.parent = null;
        AiEnemyFlag.transform.parent = null;    
        Player.transform.position = playerStartPoint.transform.position;
        AiEnemy.transform.position = aiStartPoint.transform.position;
        PlayerFlag.transform.position = playerFlagStartPoint.transform.position;
        AiEnemyFlag.transform.position = aiFlagStartPoint.transform.position;
        PlayerFlag.gameObject.tag = "Available";
        AiEnemyFlag.gameObject.tag = "Safe";
        PlayerNoFlag();
        AiNoFlag();
    }
    public void AddPlayerScore()
    {
        playerScore++;
        PlayerScoreTXT.text = "Player Score: " + playerScore;
    }
    public void AddAiEnemyScore()
    {
        aiScore++;
        AiScoreTXT.text = "Ai Score: " + aiScore;
    }
    public void PlayerHasFlag()
    {
        PlayerHasFlagTXT.text = "Has Flag: Yes";
    }
    public void PlayerNoFlag()
    {
        PlayerHasFlagTXT.text = "Has Flag: No";
    }
    public void AiHasFlag()
    {
        AiHasFlagTXT.text = "Has Flag: Yes";
    }
    public void AiNoFlag()
    {
        AiHasFlagTXT.text = "Has Flag: No";
    }
}
