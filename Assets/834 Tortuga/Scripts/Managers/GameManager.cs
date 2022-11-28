using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private bool GameStarted { get; set; }
    private float GameSpeed { get; set; } = 6.0f;
    public float Score { get; set; }
    private Player Player { get; set; }


    public static Action OnHandlePulled { get; set; } = delegate { };
    public static Action<float> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Player = Resources.Load<Player>("player");
    }

    private void Update()
    {
        if(!GameStarted)
        {
            return;
        }

        Score += GameSpeed * Time.deltaTime;
    }

    public void RestartGame()
    {
        Score = 0;

        Instantiate(Player, GameObject.Find("Environment").transform).transform.position = new Vector2(0, -3.47f);
        GameStarted = true;
    }

    public void GameOver()
    {
        OnGameFinsihed?.Invoke(Score);

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach(Obstacle ob in obstacles)
        {
            Destroy(ob.gameObject);
        }

        GameStarted = false;
    }

    public void ExitToMenu()
    {
        Destroy(FindObjectOfType<Player>().gameObject);
        GameStarted = false;
    }
}