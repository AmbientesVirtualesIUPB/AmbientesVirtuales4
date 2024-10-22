
using TMPro;
using UnityEngine;

public class CanvasPersonalizacion : MonoBehaviour
{
    public PersonalizarFurtivo personalizarFurtivo; // Referencia al script de personalizacion del furtivo
    public TextMeshProUGUI txtAmperios, txtVoltaje, txtKilovatios, txtPeso, txtInformacion; // Textos con la informacion de las baterias
    public TextMeshProUGUI txtChasis, txtAleron, txtLlanta, txtPesoTotal; // Textos con la informacion del furtivo
    private int pesoCarroceria, pesoAleron, pesoLlantas, pesoBateria, pesoTotal; // Variables para el manejo del peso de los elementos
    private bool flag; // Bandera

    public void ActualizarPanelInformativo()
    {
        // Validamos que carroceria se tiene seleccionada en la personalizacion y a raiz de esto modificamos el tipo de chasis y el peso
        if (personalizarFurtivo.carroceriaIndex == 0)
        {
            txtChasis.text = "Sin carroceria";
            pesoCarroceria = 100;
        }
        else if (personalizarFurtivo.carroceriaIndex <= 2)
        {
            txtChasis.text = "Fibra Carbono";
            pesoCarroceria = 200;
        }
        else if (personalizarFurtivo.carroceriaIndex <= 4)
        {
            txtChasis.text = "Plastico Reforzado";
            pesoCarroceria = 300;
        }
        else if (personalizarFurtivo.carroceriaIndex <= 6)
        {
            txtChasis.text = "Aluminio";
            pesoCarroceria = 400;
        }
        else if (personalizarFurtivo.carroceriaIndex <= 8)
        {
            txtChasis.text = "Acero";
            pesoCarroceria = 500;
        }

        // Validamos que alerones se tiene seleccionado en la personalizacion y a raiz de esto modificamos el tipo de aleron y el peso
        if (personalizarFurtivo.aleronIndex == 0)
        {
            txtAleron.text = "Sin aleron";
            pesoAleron = 0;
        }
        else if (personalizarFurtivo.aleronIndex <= 2)
        {
            txtAleron.text = "Fibra Carbono";
            pesoAleron = 100;
        }
        else if (personalizarFurtivo.aleronIndex <= 4)
        {
            txtAleron.text = "Plastico Reforzado";
            pesoAleron = 200;
        }
        else if (personalizarFurtivo.aleronIndex == 5)
        {
            txtAleron.text = "Acero";
            pesoAleron = 300;
        }

        // Validamos que llantas se tiene seleccionadas en la personalizacion y a raiz de esto modificamos el tipo de llanta y el peso
        if (personalizarFurtivo.llantaIndex == 0)
        {
            txtLlanta.text = "Sin llantas";
            pesoLlantas = 0;
        }
        else if (personalizarFurtivo.llantaIndex <= 3)
        {
            txtLlanta.text = "Fibra Carbono";
            pesoLlantas = 50;

            DatosCanvasInformativo.llantasFrenado = 100; // Guardamos el dato de las llanatas para aumentarle la fuerza de frenado a nuestro furtivo
        }
        else if (personalizarFurtivo.llantaIndex <= 6)
        {
            txtLlanta.text = "Goma natural";
            pesoLlantas = 70;

            DatosCanvasInformativo.llantasFrenado = 200; // Guardamos el dato de las llanatas para aumentarle la fuerza de frenado a nuestro furtivo
        }
        else if (personalizarFurtivo.llantaIndex <= 8)
        {
            txtLlanta.text = "Caucho sintetico";
            pesoLlantas = 90;

            DatosCanvasInformativo.llantasFrenado = 300; // Guardamos el dato de las llanatas para aumentarle la fuerza de frenado a nuestro furtivo
        }

        // Validamos que bateria se tiene seleccionadas en la personalizacion y a raiz de esto modificamos la informacion de la bateria
        if (personalizarFurtivo.bateriaIndex - 1 == 0)
        {
            txtAmperios.text = "10 (Ah)";
            txtVoltaje.text = "48 (V)";
            txtKilovatios.text = "0.48 (Kw)";
            txtPeso.text = "50 (Kg)";
            pesoBateria = 50;

            DatosCanvasInformativo.amperiosCarga = 48; // Guardamos el dato del amperio para aumentarle la carga a nuestro furtivo
            DatosCanvasInformativo.voltiosVelocidad = 10; // Guardamos el dato del voltaje para aumentarle la velocidad a nuestro furtivo
            DatosCanvasInformativo.kilovatiosAceleracion = 2; // Guardamos el dato de los kilovatios para aumentarle la aceleracion a nuestro furtivo
        }
        else if (personalizarFurtivo.bateriaIndex - 1 == 1)
        {
            txtAmperios.text = "20 (Ah)";
            txtVoltaje.text = "60 (V)";
            txtKilovatios.text = "1.2 (Kw)";
            txtPeso.text = "80 (Kg)";
            pesoBateria = 80;

            DatosCanvasInformativo.amperiosCarga = 60; // Guardamos el dato del amperio para aumentarle la carga a nuestro furtivo
            DatosCanvasInformativo.voltiosVelocidad = 20; // Guardamos el dato del voltaje para aumentarle la velocidad a nuestro furtivo
            DatosCanvasInformativo.kilovatiosAceleracion = 4; // Guardamos el dato de los kilovatios para aumentarle la aceleracion a nuestro furtivo
        }
        else if (personalizarFurtivo.bateriaIndex - 1 == 2)
        {
            txtAmperios.text = "30 (Ah)";
            txtVoltaje.text = "80 (V)";
            txtKilovatios.text = "2.4 (Kw)";
            txtPeso.text = "100 (Kg)";
            pesoBateria = 100;

            DatosCanvasInformativo.amperiosCarga = 80; // Guardamos el dato del amperio para aumentarle la carga a nuestro furtivo
            DatosCanvasInformativo.voltiosVelocidad = 30; // Guardamos el dato del voltaje para aumentarle la velocidad a nuestro furtivo
            DatosCanvasInformativo.kilovatiosAceleracion = 6; // Guardamos el dato de los kilovatios para aumentarle la aceleracion a nuestro furtivo
        }

        pesoTotal = pesoCarroceria + pesoAleron + pesoLlantas + pesoBateria; // Sumamos el peso total de cada parte 
        txtPesoTotal.text = pesoTotal.ToString() + "Kg"; // lo mostramos en el canvas

        DatosCanvasInformativo.pesoFurtivo = pesoTotal; // Guardamos el peso para poder utilizarlo en el script de conducir y aumentarle el peso a nuestro furtivo
    }

    private void LateUpdate()
    {
        // Cargamos inicialmente los datos segun la informacion guardada en la personalizacion con anterioridad
        if (!flag)
        {
            ActualizarPanelInformativo();
            flag = true;
        }
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionBateria()
    {
        txtInformacion.text = "Este tipo de bateria es conocida por su alta densidad de energia, ligereza, durabilidad y capacidad para mantener su carga durante periodos prolongados de tiempo";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionAmperios()
    {
        txtInformacion.text = "Los amperios se refieren a la cantidad de energia de carga que tendremos para movernos, a mayor amperaje, mayor tiempo de carga para nuestro furtivo";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionVoltaje()
    {
        txtInformacion.text = "Capacidad de la bateria, nos indica cuanta corriente suministra durante cierto tiempo, a mayor voltaje, mayor sera la velocidad máxima de nuesto furtivo";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionKilovatios()
    {
        txtInformacion.text = "Estos afectan directamente a la potencia de empuje de nuestro furtivo, entre mas alto sea el valor, mayor sera nuestro multiplicador de aceleracion";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionPeso()
    {
        txtInformacion.text = "Peso de nuestra bateria, entre mas pesada sea, afectara el peso total de nuestro furtivo y al mismo tiempo reducirá nuestra velocidad de empuje";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionFurtivo()
    {
        txtInformacion.text = "Utilizado cada año en competencias de traccion electrica, enmarcado en un proyecto de investigacion de la decanatura de ingenieria";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionChasis()
    {
        txtInformacion.text = "Tambien llamado carroceria, este afecta el peso y el aerodinamismo del vehiculo, nos afectara en la velocidad de empuje y la velocidad maxima de nuestro furtivo";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionAlerones()
    {
        txtInformacion.text = "Estructura aerodinamica de forma plana y curva, ubicada en la parte trasera, este afectara nuestra estabilidad y rendimiento aerodinamico de nuestro furtivo";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionLlantas()
    {
        txtInformacion.text = "Hechas con caracteristicas unicas para mejorar el rendimiento y la eficiencia de nuestro furtivo, dependiendo del material estas frenan de forma diferente";
    }

    /// <summary>
    /// Metodo invocado al pasar el cursor por encima de los campos (Pointer Enter) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void InformacionPesoFurtivo()
    {
        txtInformacion.text = "Peso total del vehiculo, este es modificado directamente por todos nuestros componentes, afectara nuestra velocidad de empuje y estabilidad del furtivo";
    }

    /// <summary>
    /// Metodo invocado al sacar el cursor de los campos (Pointer Exit) en el panel informativo del Canvas Personalizacion
    /// </summary>
    public void LimpiarPanel()
    {
        txtInformacion.text = "";
    }
}

public static class DatosCanvasInformativo
{
    public static int pesoFurtivo;
    public static int amperiosCarga;
    public static int voltiosVelocidad;
    public static int kilovatiosAceleracion;
    public static int llantasFrenado;
}
