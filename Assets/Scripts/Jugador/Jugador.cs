using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private GameLevelManager GameManager;

    public void SetGameManager(GameLevelManager gameManager)
    {
        if (gameManager == null)
            Debug.LogError("EL " + typeof(GameLevelManager) + " ES NULO EN " + nameof(gameManager));
        else
            GameManager = gameManager;
    }

    public void Murio()
    {
        GameManager?.OnJugadorMurio();
    }
}