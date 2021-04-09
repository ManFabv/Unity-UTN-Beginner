using UnityEngine;

public class Jugador : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameLevelManager GameManager;
    [SerializeField] private GameObject DeathEffect;
#pragma warning enable 0649

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

        if (DeathEffect != null)
        {
            Instantiate(DeathEffect, this.transform.position, this.transform.rotation);
        }
    }
}