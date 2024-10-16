
using UnityEngine;

public class PersonalizacionFurtivo : MonoBehaviour
{
    public GameObject[] furtivos; // Referencia para almacenar todos los furtivos
    public GameObject   baterias; // Referencia a las baterias para su personalizacion
    public SaveManager  saveManager; // Objeto de guardado
    public int[]        activo; // Para validar que objetos estan actrivos en cada item de personalizacion
    private int         numBat = 0; // Para validar que bateria esta activa

    public EnvioDatosBD managerBD; //Referencia al administrador de bases de datos

    private void Start()
    {
        // Cargamos los datos que se puedan tener guardados
        if (saveManager != null)
        {
            saveManager.CargarDatos();
        }
        else
        {
            Debug.LogError("Falta asignar referencia del saveData al script personalizacionFurtivo");
        }


        // Busca el objeto por nombre para buscar la referencia al objeto que administra la base de datos, ya que este pasara entre escenas
        GameObject obj = GameObject.Find("EnvioBD");
        // O por tag
        // GameObject obj = GameObject.FindWithTag("TagDelObjeto");

        if (obj != null)
        {
            managerBD = obj.GetComponent<EnvioDatosBD>(); // Si encuentra el objeto lo almacenamos en la variable
        }
        else
        {
            managerBD = null;
        }
        
    }


    /// <summary>
    /// Metodo invodado desde BtnCarroceria en el CanvasPersonalizacion
    /// </summary>
    public void SiguienteCarroceria()
    {
        // Asignamos a activo un valor dependiendo del punto del array donde estemos
        activo[0] = (activo[0] + 1) % furtivos.Length;
        
        // Recorremos al array para encontrar cada parte
        for (int i = 0; i < furtivos.Length; i++)
        {
            // Si el objeto coincide con el siguiente numero
            if (i == activo[0])
            {
                // Recorremos todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("cro")) // En este caso buscamos activar las carrocerias
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas las demas carrocerias
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("cro")) // En este caso buscamos desactivar las carrocerias
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
        // Convertimos a texto para su posterior guardado
        ConvertirATexto();
    }


    /// <summary>
    /// Metodo invodado desde BtnAlerones en el CanvasPersonalizacion
    /// </summary>
    public void SiguienteAleron()
    {
        // Asignamos a activo un valor dependiendo del punto del array donde estemos
        activo[1] = (activo[1] + 1) % furtivos.Length;  
        // Variable para validar los coches que si tengan aleron
        bool encontrado = false;

        // Recorremos al array para encontrar cada parte
        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[1])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("ale")) // En este caso buscamos activar los alerones
                    {
                        encontrado = true;
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }                
                }
                // Sino tiene aleron pasamos al siguiente
                if (encontrado == false)
                {
                    activo[1]++;
                }
            }
            else
            {
                // En caso contrario, desactivamos todas los demas alerones
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("ale")) // En este caso buscamos desactivar los alerones
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
        // Convertimos a texto para su posterior guardado
        ConvertirATexto();
    }


    /// <summary>
    /// Metodo invodado desde BtnSillas en el CanvasPersonalizacion
    /// </summary>
    public void SiguienteSilla()
    {
        // Asignamos a activo un valor dependiendo del punto del array donde estemos
        activo[2] = (activo[2] + 1) % furtivos.Length;

        // Recorremos al array para encontrar cada parte
        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[2])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("sil")) // En este caso buscamos activar las sillas
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas las demas sillas
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("sil")) // En este caso buscamos desactivar las sillas
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
        // Convertimos a texto para su posterior guardado
        ConvertirATexto();
    }


    /// <summary>
    /// Metodo invodado desde BtnVolante en el CanvasPersonalizacion
    /// </summary>
    public void SiguienteVolante()
    {
        // Asignamos a activo un valor dependiendo del punto del array donde estemos
        activo[3] = (activo[3] + 1) % furtivos.Length;

        // Recorremos al array para encontrar cada parte
        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[3])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("vol")) // En este caso buscamos activar los volantes
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas los demas volantes
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("vol")) // En este caso buscamos desactivar los volantes
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
        // Convertimos a texto para su posterior guardado
        ConvertirATexto();
    }


    /// <summary>
    /// Metodo invodado desde BtnLlantas en el CanvasPersonalizacion
    /// </summary>
    public void SiguienteLlantas()
    {
        // Asignamos a activo un valor dependiendo del punto del array donde estemos
        activo[4] = (activo[4] + 1) % furtivos.Length;

        // Recorremos al array para encontrar cada parte
        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[4])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("whe")) // En este caso buscamos activar las llantas
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas las demas llantas
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("whe")) // En este caso buscamos desactivar las llantas
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
        // Convertimos a texto para su posterior guardado
        ConvertirATexto();
    }


    /// <summary>
    /// Metodo invodado desde BtnBateria en el CanvasPersonalizacion
    /// </summary>
    public void SiguienteBateria()
    {
        // Asignamos a activo un valor dependiendo del punto del array donde estemos
        activo[5] = (activo[5] + 1) % 3;
        numBat = activo[5];
        Debug.Log(numBat);

        //Regresamos el numero de la bateria al valor por defecto
        if (numBat > 2)
        {
            numBat = 0;
        }
        
        // Recorremos al array para encontrar cada parte
        for (int i = 1; i < 3; i++)
        {
            // Recorrer todos los hijos del objeto actual
            foreach (Transform child in baterias.transform)
            {
                // Verificar si el nombre del hijo empieza con un patrón específico
                if (child.gameObject.name.StartsWith("ba" + numBat)) // En este caso buscamos activar las baterias
                {
                    // Activar el objeto hijo que cumple la condición
                    child.gameObject.SetActive(true);
                }
                else
                {
                    // Desactivamos el objeto hijo que no cumple la condición
                    child.gameObject.SetActive(false);
                }
            }
        }
        numBat++;
        // Convertimos a texto para su posterior guardado
        ConvertirATexto();
    }

    /// <summary>
    /// Metodo invocado al momento de guardar la personalizacion del furtivo en el taller, esta viaja a la BD
    /// </summary>
    public void PasarInfoBD()
    {
        for (int i = 0; i < activo.Length; i++)
        {
            managerBD.datos[i + 15] = activo[i];
        }
        // Enviamos la informacion a la base de datos
        managerBD.EnviarDatosP();
    }

    /// <summary>
    /// Metodo que se invoca en el script de SaveManager para asignar los datos del furtivo loggeado
    /// </summary>
    /// <param name="array"></param>
    public void TraerInformacionBD(int[] array)
    {
        for (int i = 0; i < activo.Length; i++)
        {
            activo[i] = array[i + 15];
        }
        // Asignamos los datos guardados
        AsignarDatosGuardados();
    }

    /// <summary>
    /// Metodo utilizado para la asignacion de los valores guardados en el script SaveManager
    /// </summary>
    public void AsignarDatosGuardados()
    {
        Debug.Log("f");
        // Recorremos todos los elementos activos
        for (int i = 0; i < activo.Length; i++)
        {
            // Restamos uno a la cantidad guardada para evitar el aumento que se realiza en cada metodo
            activo[i] = activo[i] - 1;
        }

        // Ejecutamos todos los metodos para cargas los elementos de la personalizacion
        SiguienteCarroceria();
        SiguienteAleron();
        SiguienteSilla();
        SiguienteVolante();
        SiguienteLlantas();
        SiguienteBateria();
    }


    /// <summary>
    /// Para convertir las posiciones en una sola cadena de texto y poder guardarlas en el local
    /// </summary>
    /// <returns> Devuelve una variable tipo String con el texto convertido </returns>
    public string ConvertirATexto()
    {
        string texto = "";
        for (int i = 0; i < activo.Length; i++)
        {
            texto += (texto.Length > 0) ? "|" : "";
            texto += activo[i].ToString();
        }
        // Enviamos los datos que queremos guardar
        saveManager.PersonalizacionFurtivos(texto);
        return texto;
    }


    /// <summary>
    /// Metodo invocado desde el script SaveManager. Para convertir las posiciones de texto a enteros y cargarlas desde los archivos locales
    /// </summary>
    /// <param name="texto"> Parametro que recibe la cadena con el texto con el fin de convertirla en datos enteros </param>
    public void ConvertirDesdeTexto(string texto)
    {
        string[] nombre = texto.Split("|");
        if (texto.Length > 0)
        {
            for (int i = 0; i < nombre.Length; i++)
            {
                activo[i] = int.Parse(nombre[i]);
            }
        }
        // Asignamos los datos guardados
        //AsignarDatosGuardados();
    }
}
