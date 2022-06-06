using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Datos : MonoBehaviour
{
    [SerializeField] private int tiempoNivel = 300;
    [SerializeField] private int vidasIniciales = 3;
    [SerializeField] private int gemasIniciales = 9;
    private float tiempoInicio;
    private int tiempoRestante;
    private int puntos;
    private int vidas;
    private int gemas;

    #region Eventos
    public delegate void ManejadorTiempoActualizado(int tiempo);
    public event ManejadorTiempoActualizado OnTiempoRestanteActualizado;
    public delegate void ManejadorPuntosActualizados(int puntos);
    public event ManejadorPuntosActualizados OnPuntosActualizados;
    public delegate void ManejadorVidasActualizadas(int vidas);
    public event ManejadorVidasActualizadas OnVidasActualizadas;
    public delegate void ManejadorGemasActualizadas(int gemas);
    public event ManejadorGemasActualizadas OnGemasActualizadas;
    #endregion

    #region Singleton
    public static Datos Instancia { get; private set; }
    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    #endregion
    private void Start()
    {
        ReiniciarValores();
    }

    private void Update()
    {
        ActualizarTiempoRestante();
    }

    public void ReiniciarValores()
    {
        SetTiempoInicio(Time.time);
        tiempoRestante = tiempoNivel;
        OnTiempoRestanteActualizado?.Invoke(tiempoRestante);
        vidas = vidasIniciales;
        OnVidasActualizadas?.Invoke(vidas);
        puntos = 0;
        OnPuntosActualizados?.Invoke(puntos);
        SetGemasIniciales();
    }

    public void SetTiempoInicio(float tiempoInicio)
    {
        this.tiempoInicio = tiempoInicio;
        ActualizarTiempoRestante();
    }

    public void SetGemasIniciales()
    {
        gemas = gemasIniciales;
        OnGemasActualizadas?.Invoke(gemas);
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        OnPuntosActualizados?.Invoke(puntos);
    }
    public void QuitarVida()
    {
        vidas--;
        OnVidasActualizadas?.Invoke(vidas);
    }

    public void DecrementarGemas()
    {
        gemas--;
        OnGemasActualizadas?.Invoke(gemas);
    }

    private void ActualizarTiempoRestante()
    {
        var tiempoTranscurrido = Time.time - tiempoInicio;
        tiempoRestante = tiempoNivel - (int)tiempoTranscurrido;
        OnTiempoRestanteActualizado?.Invoke(tiempoRestante);
    }
}
