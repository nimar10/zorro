using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator jugar;
    [SerializeField] private Animator creditos;
    [SerializeField] private Animator salir;
    [SerializeField] private Animator infoCreditos;
    private void Start()
    {
        jugar.SetBool("estaOculto", false);
        creditos.SetBool("estaOculto", false);
        salir.SetBool("estaOculto", false);
    }

    public void MostrarInfoCreditos()
    {
        OcultarBotones();
        infoCreditos.SetBool("estaOculto", false);
    }
    public void OcultarInfoCreditos()
    {
        infoCreditos.SetBool("estaOculto", true);
        jugar.SetBool("estaOculto", false);
        creditos.SetBool("estaOculto", false);
        salir.SetBool("estaOculto", false);
    }
    private void OcultarBotones()
    {
        jugar.SetBool("estaOculto", true);
        creditos.SetBool("estaOculto", true);
        salir.SetBool("estaOculto", true);
    }
    public void Jugar()
    {
        StartCoroutine(OcultarBotonesYJugar());
    }
    public void Salir()
    {
        StartCoroutine(OcultarBotonesYSalir());
    }

    private IEnumerator OcultarBotonesYJugar()
    {
        OcultarBotones();
        yield return new WaitForSeconds(1.0f);
        Debug.Log("JUGARRR!!!!!");
    }
    private IEnumerator OcultarBotonesYSalir()
    {
        OcultarBotones();
        yield return new WaitForSeconds(1.0f);
        Debug.Log("SALIRRR!!!!!");
    }
}
