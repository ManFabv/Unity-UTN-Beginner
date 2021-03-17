using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private GameManagerNivel4 GameManager;

    public void SetGameManager(GameManagerNivel4 gameManager)
    {
        if (gameManager == null)
            Debug.LogError("EL " + typeof(GameManagerNivel4) + " ES NULO EN " + nameof(gameManager));
        else
            GameManager = gameManager;
    }

    public void Murio()
    {
        GameManager?.OnJugadorMurio();
    }
}