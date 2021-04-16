using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private int MaxScoreParaGanar = 10;
    [SerializeField] private float TimeToLoseLevel = 10;
    [SerializeField] private TimeManager TimeManager;
    [SerializeField] private ScoreManager ScoreManager;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] private string NextWinLevelName;
    [SerializeField] private string NextLoseLevelName;
    [SerializeField] private float TimeBeforeLoadNextLevel = 9;
#pragma warning restore 0649

    private enum LevelEndState
    {
        PLAYING,
        WIN,
        LOSE
    }

    private bool finishedLevel = false;
    private LevelEndState levelEndState = LevelEndState.PLAYING;
    private bool jugadorMurio = false;

    public void OnJugadorMurio()
    {
        jugadorMurio = true;
    }

    private void Awake()
    {
        if (ScoreManager == null)
            Debug.LogError("EL " + typeof(ScoreManager) + " ES NULO EN " + nameof(ScoreManager));
        if (TimeManager == null)
            Debug.LogError("EL " + typeof(TimeManager) + " ES NULO EN " + nameof(TimeManager));
        if (AudioManager == null)
            Debug.LogError("EL " + typeof(AudioManager) + " ES NULO EN " + nameof(AudioManager));
        if(string.IsNullOrEmpty(NextWinLevelName))
            Debug.LogError("NO SE ESPECIFICO UN SIGUIENTE NIVEL EN " + nameof(NextWinLevelName));
        if(string.IsNullOrEmpty(NextLoseLevelName))
            Debug.LogError("NO SE ESPECIFICO UN SIGUIENTE NIVEL EN " + nameof(NextLoseLevelName));
    }

    private void Update()
    {
        if (finishedLevel == false)
        {
            bool win = (ScoreManager != null && ScoreManager.Score >= MaxScoreParaGanar);
            bool lose = (TimeManager != null && TimeManager.TimeElapsed >= TimeToLoseLevel) || jugadorMurio;

            if (win || lose)
            {
                if (win)
                {
                    levelEndState = LevelEndState.WIN;
                    AudioManager?.PlayWinMusic();
                }
                else if (lose)
                {
                    levelEndState = LevelEndState.LOSE;
                    AudioManager?.PlayLoseMusic();
                }
                
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
        DisableObjectsOfType<MovimientoHorizontal>();
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
        string levelToLoad = string.Empty;
        if (levelEndState == LevelEndState.WIN)
            levelToLoad = NextWinLevelName;
        else if (levelEndState == LevelEndState.LOSE)
            levelToLoad = NextLoseLevelName;

        if (!string.IsNullOrEmpty(levelToLoad))
            SceneManager.LoadScene(levelToLoad);
    }
}