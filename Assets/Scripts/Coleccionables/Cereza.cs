using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Cereza : Coleccionable
{
    [SerializeField] private int puntos = 2;
    protected override void Recoger()
    {
        Datos.Instancia.SumarPuntos(puntos);
    }
}
