using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerNivel2 : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float TimeToWinLevel = 10;
    [SerializeField] private TimeManager TimeManager;
    [SerializeField] private string NextLevelName;
    [SerializeField] private float TimeBeforeLoadNextLevel = 5;
#pragma warning restore 0649

    private bool finishedLevel = false;

    private void Awake()
    {
        if (TimeManager == null)
            Debug.LogError("EL " + typeof(TimeManager) + " ES NULO EN " + nameof(TimeManager));
        if(string.IsNullOrEmpty(NextLevelName))
            Debug.LogError("NO SE ESPECIFICO UN SIGUIENTE NIVEL EN " + nameof(NextLevelName));
    }

    private void Update()
    {
        if (finishedLevel == false)
        {
            if (TimeManager != null && TimeManager.TimeElapsed >= TimeToWinLevel)
            {
                finishedLevel = true;
                DisableAllAction();
                Invoke("LoadNextLevel", TimeBeforeLoadNextLevel);
            }
        }
    }

    private void DisableAllAction()
    {
        DisableObjectsOfType<GeneradorOleadas>();
        DisableObjectsOfType<MovimientoContinuo>();
        DisableObjectsOfType<RotacionContinua>();
        DisableObjectsOfType<Disparador>();
        DisableObjectsOfType<DisparadorAutomatico>();
        DisableObjectsOfType<Dañador>();
        DisableObjectsOfType<Bomba>();
        DisableObjectsOfType<MovimientoPersonaje>();
    }

    private void DisableObjectsOfType<T>() where T : MonoBehaviour
    {
        T[] entidades = GameObject.FindObjectsOfType<T>();
        if (entidades != null)
        {
            foreach (T entidad in entidades)
            {
                entidad.enabled = false;
            }
        }
    }

    private void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(NextLevelName))
            SceneManager.LoadScene(NextLevelName);
    }
}