using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;


public class InfoDatos : MonoBehaviour
{
    public ScriptableMolecula SMolecula;

    
    public Text InfoNombre;
    public Text InfoAtomo;

    void Start()
    {
        Instantiate(SMolecula.atomoPrefab, Vector3.zero, Quaternion.identity,this.transform);
    }

}
