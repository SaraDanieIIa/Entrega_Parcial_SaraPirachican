using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gamePaused = false;
    bool win = false;
    bool gameOver = false;
    bool pressButton = false;
    bool isSlow = false;
    int count = 0;
    float secondsTime = 30f;
    float timeSlow = 1.5f;
    int anterioresPuntosDeVida;
    [SerializeField] Text textTimer;
    [SerializeField] Spaceship player;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] int numEnemies;
    [SerializeField] int puntosVida;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        winUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && win == false)
            PauseGame();
        if (Input.GetKeyDown(KeyCode.T))
            pressButton = true;
        showTime();
        slowTime();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Nivel1");
        Time.timeScale = 1;
    }

    void showTime()
    {
        
        if(secondsTime <= 0)
        {
            Perder();
            secondsTime = 0;
        }
        else
        {
            secondsTime = secondsTime - Time.deltaTime;
        }
        textTimer.text = secondsTime.ToString("f0");
    }

    void slowTime()
    {
        if (pressButton == true)
        {
            if (isSlow =! true)
            {
                count++;
                if (count <= 3)
                {
                    pressButton = true;
                    isSlow = true;
                    timeSlow = 1.5f;
                }
                else
                {
                    Debug.Log("Limite de intentos alcanzado");
                }
            }
            else
            {
                if (pressButton == true)
                {
                    if (timeSlow <= 0)
                    {
                        pressButton = false;
                        isSlow = false;
                        timeSlow = 0;
                        Time.timeScale = 1;
                        Animal.puntosDeVida = anterioresPuntosDeVida;
                    }
                    else
                    {
                        timeSlow = timeSlow - Time.deltaTime;
                        Time.timeScale = 0.5f;
                        anterioresPuntosDeVida = Animal.puntosDeVida;
                        Animal.puntosDeVida = 1;
                    }
                }
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;

        player.gamePaused = gamePaused;
        
        pauseUI.SetActive(gamePaused);

        Time.timeScale = gamePaused ? 0 : 1;
    }

    public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if(numEnemies < 1)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        win = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        winUI.SetActive(true);
    }

    void Perder()
    {
        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        gameOverUI.SetActive(true);
    }

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
