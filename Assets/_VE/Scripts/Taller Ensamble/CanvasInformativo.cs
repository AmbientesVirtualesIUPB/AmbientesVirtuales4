using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasInformativo : MonoBehaviour
{
    public TextMeshProUGUI txtInformacion;
    public TextMeshProUGUI txtTitulo;

    public void DetallarCarrocerias()
    {
        
        txtInformacion.text = "";
        txtInformacion.text = "Fibra De Carbono: De una ligereza extrema, mejorando la aceleración, maniobrabilidad y consumo de carga, tiene una resistencia y rigidez superior a la" +
            " del acero, buena capacidad de resistencia a los impactos, pero aun así se debe tener en consideración que es un producto costoso, con dificultad en su reparación, con una" +
            "personalización limitada por su material y una conductividad termina baja. \n\nAluminio: Mas ligero que el acero, mejorando el rendimiento y la aceleración. A pesar de ser" +
            "mas ligero que el acero tiene una resistencia alta, resiste la corrosión, es un material muy maleable y personalizable, una capacidad de absorción de impactos bastante alta," +
            "es resistente al calor, reciclable y se puede reparar muy facilmente. \n\nPlástico Reforzado: Mas ligeras que las de acero o de aluminio lo que reduce el peso de nuestro furtivo" +
            "y mejora el rendimiento y consumo de bateria, puede ser reforzado con materiales de fibras de vidrio o de carbono lo que ofrece una gran resistencia a los impactos, tiene" +
            "una alta durabilidad y resistencia a la corrosión, es flexible en su diseño y personalización, de bajos costos en sus reparaciones y de alta sostenibilidad. ";
    }

    public void DetallarAlerones()
    {
        txtInformacion.text = "";
        txtInformacion.text = "Alerones";
    }

    public void DetallarLlantas()
    {
        txtInformacion.text = "";
        txtInformacion.text = "Llantas";
    }

    public void DetallarBaterias()
    {
        txtInformacion.text = "";
        txtInformacion.text = "Baterias";
    }
}


