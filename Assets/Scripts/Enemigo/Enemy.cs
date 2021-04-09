using UnityEngine;

public class Enemy : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject DeathEffect;
#pragma warning enable 0649

    private EnemyManager EnemyManager;

    public void SetEnemyManager(EnemyManager enemyManager)
    {
        if (enemyManager == null)
            Debug.LogError("EL " + typeof(EnemyManager) + " ES NULO EN " + nameof(enemyManager));
        else
            EnemyManager = enemyManager;
    }

    public void Murio()
    {
        EnemyManager?.EnemigoMurio();

        if (DeathEffect != null)
        {
            Instantiate(DeathEffect, this.transform.position, this.transform.rotation);
        }
    }
}