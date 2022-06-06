using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instancia { get; private set; }
    [SerializeField] private TextMeshProUGUI puntos;
    [SerializeField] private TextMeshProUGUI tiempo;
    [SerializeField] private TextMeshProUGUI vidas;
    [SerializeField] private TextMeshProUGUI gemas;
    [SerializeField] private float retardoAnimacionPuntos = 0.1f;
    private void Awake() {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    private void Start() 
    {
        Datos.Instancia.OnTiempoRestanteActualizado += ActualizarTiempo;
        Datos.Instancia.OnPuntosActualizados += ActualizarPuntos;
        Datos.Instancia.OnVidasActualizadas += ActualizarVidas;
        Datos.Instancia.OnGemasActualizadas += ActualizarGemas;
    }

    public void ActualizarPuntos(int puntos)
    {
        var puntosActuales = int.Parse(this.puntos.text);
        StartCoroutine(AnimarPuntos(puntosActuales, puntos));
    }
    private IEnumerator AnimarPuntos(int anteriores, int actuales)
    {
        var incremento = (anteriores < actuales) ? 1 : -1;
        while (anteriores != actuales)
        {
            anteriores += incremento;
            puntos.SetText($"{anteriores:D5}");
            yield return new WaitForSeconds(retardoAnimacionPuntos);
        }
    }

    public void ActualizarTiempo(int tiempo)
    {
        this.tiempo.SetText($"{tiempo / 60:00}:{tiempo % 60:00}");
    }

    public void ActualizarVidas(int vidas)
    {
        this.vidas.SetText($"{vidas}");
    }
    public void ActualizarGemas(int gemas)
    {
        this.gemas.SetText($"{gemas}");
    }
}
