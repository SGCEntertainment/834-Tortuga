using UnityEngine;

public class Player : MonoBehaviour
{
    Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D _)
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}