using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Datos.Instancia.OnTiempoRestanteActualizado += ActualizarTiempoRestante;
        Datos.Instancia.OnVidasActualizadas += ActualizarVidas;
        Datos.Instancia.OnGemasActualizadas += ActualizarGemas;
    }

    public void ActualizarTiempoRestante(int tiempoRestante)
    {
        if (tiempoRestante <= 0)
        {
            Debug.Log("Has perdido, se ha acabado el tiempo!!!!!");
            ReiniciarNivel();
        }
    }

    public void ActualizarVidas(int vidas)
    {
        if (vidas <= 0)
        {
            Debug.Log("Has perdido todas las vidas....");
            ReiniciarNivel();
        }
    }

    public void ActualizarGemas(int gemas)
    {
        if (gemas <= 0)
        {
            Debug.Log("Recogidas todas las gemas -> Pasas de nivel.");
            ReiniciarNivel();
        }
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
