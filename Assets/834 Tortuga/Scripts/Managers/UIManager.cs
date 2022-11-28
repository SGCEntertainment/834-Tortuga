using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject game;

    private void Awake()
    {
        LoadingGO.OnLoadingStarted += () =>
        {
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            game.SetActive(true);
        };

        GameManager.OnGameFinsihed += (score) =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(score, () =>
            {
                GameManager.Instance.RestartGame();
            });
        };
    }
}