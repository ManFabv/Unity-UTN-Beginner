using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float velocidadMovimiento = 10;
    [SerializeField] private float velocidadRotacion = 45;
    [SerializeField] private string ArribaNombreAccion = "Arriba";
    [SerializeField] private string AbajoNombreAccion = "Abajo";
    [SerializeField] private string DerechaNombreAccion = "Derecha";
    [SerializeField] private string IzquierdaNombreAccion = "Izquierda";
#pragma warning restore 0649

    private Transform cachedTransform;
    private float bonusVelocidad = 1;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();

        if(ArribaNombreAccion == null)
            Debug.LogError("NO SE ASIGNO UN NOMBRE A LA ACCION EN " + nameof(ArribaNombreAccion));
        if(AbajoNombreAccion == null)
            Debug.LogError("NO SE ASIGNO UN NOMBRE A LA ACCION EN " + nameof(AbajoNombreAccion));
        if(DerechaNombreAccion == null)
            Debug.LogError("NO SE ASIGNO UN NOMBRE A LA ACCION EN " + nameof(DerechaNombreAccion));
        if(IzquierdaNombreAccion == null)
            Debug.LogError("NO SE ASIGNO UN NOMBRE A LA ACCION EN " + nameof(IzquierdaNombreAccion));
    }

    private void Update()
    {
        if (Input.GetButton(ArribaNombreAccion))
        {
            cachedTransform.Translate(0, 0,velocidadMovimiento * Time.deltaTime * bonusVelocidad);
        }

        if (Input.GetButton(AbajoNombreAccion))
        {
            cachedTransform.Translate(0, 0, -velocidadMovimiento * Time.deltaTime * bonusVelocidad);
        }

        if (Input.GetButton(DerechaNombreAccion))
        {
            cachedTransform.Rotate(0,velocidadRotacion * Time.deltaTime * bonusVelocidad,0, Space.Self);
        }

        if (Input.GetButton(IzquierdaNombreAccion))
        {
            cachedTransform.Rotate(0,-velocidadRotacion * Time.deltaTime * bonusVelocidad,0, Space.Self);
        }
    }

    public void AplicarBonusVelocidad(float bonus, float tiempoDeBonus)
    {
        if (tiempoDeBonus <= 0)
        {
            Debug.LogError("EL TIEMPO DE BONUS DE VELOCIDAD DEBERIA SER MAYOR QUE CERO PARA " + nameof(tiempoDeBonus));
            tiempoDeBonus = 0;
        }
        if (bonus <= 0)
        {
            Debug.LogError("EL BONUS DE VELOCIDAD DEBERIA SER MAYOR QUE CERO PARA " + nameof(bonus));
            bonus = 0;
        }

        bonusVelocidad = bonus;
        Invoke("QuitarBonusVelocidad", tiempoDeBonus);
    }

    private void QuitarBonusVelocidad()
    {
        bonusVelocidad = 1;
    }
}