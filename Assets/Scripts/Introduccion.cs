using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Introduccion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cargando;
    [SerializeField] private Slider barraProgreso;
    private void Start() {
        StartCoroutine(CargarMenu());
    }

    private void Update() 
    {
        cargando.SetText($"Cargando: {barraProgreso.value * 100:0}%");
    }

    private IEnumerator CargarMenu()
    {
        yield return new WaitForSeconds(3.25f);
        SceneManager.LoadScene("Menu");
    }
}
