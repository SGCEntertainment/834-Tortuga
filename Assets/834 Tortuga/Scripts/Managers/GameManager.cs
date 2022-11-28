using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }
    public static Action OnHandlePulled { get; set; } = delegate { };
    public static Action OnGameFinsihed { get; set; } = delegate { };
}