using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int EnemigosMuertos { get; private set; }

    public void EnemigoMurio()
    {
    	Debug.LogError("EnemigosMuertos: " + (EnemigosMuertos+1));
        EnemigosMuertos++;
    }
}