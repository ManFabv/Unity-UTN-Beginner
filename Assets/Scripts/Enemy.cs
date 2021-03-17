using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager EnemyManager;

    public void SetEnemyManager(EnemyManager enemyManager)
    {
        if (enemyManager == null)
        {
            Debug.LogError("EL " + typeof(EnemyManager) + " ES NULO EN " + nameof(enemyManager));
        }
        else
        {
            EnemyManager = enemyManager;
        }
    }

    public void Murio()
    {
        EnemyManager?.EnemigoMurio();
    }
}