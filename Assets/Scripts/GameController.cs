using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour


{
      // Controle Dos Pontos //

    public int ScoreTotal;
    public Text scoreText;

    public static GameController istance;

    // Start is called before the first frame update
    void Start()
    {
        istance = this;
    }

    public void UpdateSocoreText()
    {
        scoreText.text = ScoreTotal.ToString();
    }

    // Controle Do GAME OVER //

    public GameObject gameOver;

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    // Botão Restarte //
    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Sair()
    {
        Application.Quit();   
    }
}
