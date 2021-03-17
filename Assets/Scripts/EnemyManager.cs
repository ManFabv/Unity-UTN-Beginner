using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int EnemigosMuertos { get; private set; }

    public void EnemigoMurio()
    {
        EnemigosMuertos++;
        
        if(EnemigosMuertos >= 1)
            Debug.LogError("FIN DEL JUEGO");
    }
}