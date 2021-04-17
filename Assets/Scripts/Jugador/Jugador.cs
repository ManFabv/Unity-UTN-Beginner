using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Vida))]
public class Jugador : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameLevelManager GameManager;
    [SerializeField] private GameObject DeathEffect;
    [SerializeField] private Slider HealthBar;
#pragma warning enable 0649

    private Vida cachedVida;

    private void Awake()
    {
        cachedVida = this.GetComponent<Vida>();

        HealthBar.MinValue = 0;
        HealthBar.MaxValue = cachedVida.CurrentVida();
        HealthBar.Value = cachedVida.CurrentVida();
        
        if (HealthBar == null)
            Debug.LogError("EL " + typeof(Slider) + " ES NULO EN " + nameof(HealthBar));
    }

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

    public void TakeDamage()
    {
        HealthBar.Value = cachedVida.CurrentVida();
    }
}