using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }



    private int Score { get; set; }
    private Player Player { get; set; }



    public static Action OnHandlePulled { get; set; } = delegate { };
    public static Action<int> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Player = Resources.Load<Player>("player");
    }

    private void Start()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        Instantiate(Player, GameObject.Find("Environment").transform).transform.position = new Vector2(0, -3.47f);
    }

    public void GameOver()
    {
        OnGameFinsihed?.Invoke(Score);
    }
}