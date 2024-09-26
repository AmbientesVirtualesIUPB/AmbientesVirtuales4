using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;


public class InfoDatos : MonoBehaviour
{
    public ScriptableMolecula SMolecula;

    public float[] datosGrafica;
    public string[] infoGrafica;

    public Text InfoNombre;
    public Text InfoAtomo;

    void Start()
    {
        Instantiate(SMolecula.atomoPrefab, Vector3.zero, Quaternion.identity,this.transform);
        string InfoNombre = SMolecula.nombreAtomo;

        for (int i = 0; i < SMolecula.graficas.Length; i++)
        {
            datosGrafica[i] = SMolecula.graficas[i];
        }
        for (int i = 0; i < SMolecula.graficas.Length; i++)
        {
            infoGrafica[i] = SMolecula.textoGraficas[i];
        }
    }

}
