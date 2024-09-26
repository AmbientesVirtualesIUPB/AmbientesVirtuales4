using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atomo_", menuName = "DRX/InfoAtomo")]
public class ScriptableMolecula : ScriptableObject
{
    

    public GameObject atomoPrefab; // El GameObject que representará el átomo
    public string nombreAtomo; // El nombre del átomo
    [TextArea(minLines: 1, maxLines: 5)]
    public string infoAtomo; // Informacion basica sobre el atomo (fecha de i
    public float[] graficas; // La Informacion delas graficas 
    public string[] textoGraficas; // La Informacion delas graficas 

}