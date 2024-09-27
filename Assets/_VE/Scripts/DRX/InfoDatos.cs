using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoDatos : MonoBehaviour
{
    public ScriptableMolecula SMolecula;

    public GameObject canvas;

    private GameObject objetoInstanciado;

    float[] datosGrafica;
    string[] infoGrafica;

    public TextMeshProUGUI InfoNombre;
    public TextMeshProUGUI InfoAtomo;

    [Header("Infos")]
    public RectTransform[] barrasI;
    public TextMeshProUGUI[] barrasT;



    void Start()
    {
       objetoInstanciado = Instantiate(SMolecula.atomoPrefab, Vector3.zero, Quaternion.identity,this.transform);
       InfoNombre.text = SMolecula.nombreAtomo;
       InfoAtomo.text = SMolecula.infoAtomo;

       datosGrafica = new float[SMolecula.graficas.Length];
       infoGrafica = new string[SMolecula.graficas.Length];

        for (int i = 0; i < SMolecula.graficas.Length; i++)
        {
            datosGrafica[i] = SMolecula.graficas[i];
            infoGrafica[i] = SMolecula.graficas[i].ToString();
            barrasI[i].sizeDelta = new Vector2(barrasI[i].sizeDelta.x, SMolecula.graficas[i]);
            barrasT[i].text = SMolecula.graficas[i].ToString();

        }
      


    }
    void Update()
    {
        if (canvas != null && objetoInstanciado != null)
        {
            canvas.transform.position = objetoInstanciado.transform.position;
            canvas.transform.rotation = objetoInstanciado.transform.rotation;
        }
    }

    public void ApagarInfo() 
    {
        canvas.SetActive(false);
    
    }

    public void EncenderInfo()
    {
        canvas.SetActive(true);

    }
}
