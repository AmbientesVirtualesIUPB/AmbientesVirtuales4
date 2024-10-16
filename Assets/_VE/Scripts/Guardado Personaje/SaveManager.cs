using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class SaveManager : MonoBehaviour
{
    //Objeto con la informacion de las personalizaciones
    public Personalizacion              personalizacion;
    public PersonalizarFurtivo          personalizacionFurtivos;

    //Referenciamos el archivo donde guardaremos la informacion
    [SerializeField]
    private SaveSplit split;

    [SerializeField]
    private string url_consulta_p = "http://localhost/apiwebm/CRUD/Read/leer_datos_personalizacion.php";   // URL para consultar la informacion de la personalizacion
    private ProcesadorDeDatos procesador;
    public EnvioDatosBD managerBD;

    private void Start()
    {
        procesador = gameObject.AddComponent<ProcesadorDeDatos>();

        // Busca el objeto por nombre para buscar la referencia al objeto que administra la base de datos, ya que este pasar� entre escenas
        GameObject obj = GameObject.Find("EnvioBD");

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
    /// Metodo para el guardado de archivos JSON
    /// </summary>
    public void Save()
    {
        //Conovertimos el objeto a formato Json
        string splitJson = JsonUtility.ToJson(split);
        //Generamos una ubicacion en disco, persistente para que funcione en cualquier plataforma
        string path = Path.Combine(Application.persistentDataPath, "splitData.data");

        // Imprimir ruta del archivo guardado
        // Debug.Log(path);

        //Guardamos el archibo json
        File.WriteAllText(path, splitJson);
    }

    /// <summary>
    /// Metodo para la carga de archivos JSON
    /// </summary>
    public void Load()
    {
        //Traemos la ruta del archivo
        string path = Path.Combine(Application.persistentDataPath, "splitData.data");

        //Validamos si ya existe un archivo de guardado actual
        if (File.Exists(path))
        {
            //leemos el archivo Json
            string splitJson = File.ReadAllText(path);
            //Convertimos el archivo Json a objeto unity
            SaveSplit splitLoad = JsonUtility.FromJson<SaveSplit>(splitJson);

            split.posiciones = splitLoad.posiciones;
            split.colores = splitLoad.colores;
            split.furtivos = splitLoad.furtivos;
        }
        // Sino existe creamos uno por defecto
        else
        {
            Save();
        }
    }

    /// <summary>
    /// Metodo invocado desde el scrip de personalización, para grabar los datos de las posiciones
    /// </summary>
    /// <param name="texto"> Parametro de texto con las posiciones </param>
    public void PersonalizacionPersonaje(string texto)
    {
        split.posiciones = texto;
        //Guardamos
        Save();
    }

    /// <summary>
    /// Metodo invocado desde el scrip de personalización, para grabar los datos de las posiciones de los colores
    /// </summary>
    /// <param name="texto"> Parametro de texto con las posiciones </param>
    public void PersonalizacionColores(string texto)
    {
        split.colores = texto;
        //Guardamos
        Save();
    }

    /// <summary>
    /// Metodo invocado desde el scrip de personalizaciónFurtivo, para grabar los datos de las posiciones del furtivo
    /// </summary>
    /// <param name="texto"> Parametro de texto con las posiciones </param>
    public void PersonalizacionFurtivos(string texto)
    {
        split.furtivos = texto;
        //Guardamos
        Save();
    }

    /// <summary>
    /// Metodo invocado desde el script de personalización y personalizacionFurtivo, en el Awake
    /// </summary>
    public void CargarDatos()
    {
        //Cargamos
        Load();
        
        // Solo ejecuta el resto del código si objeto no es nulo
        if (personalizacion != null)
        {
            //Asignamos los datos al personaje
            personalizacion.ConvertirDesdeTexto(split.posiciones); 
            personalizacion.ConvertirDesdeTextoColores(split.colores); 
        }
        // Solo ejecuta el resto del código si objeto no es nulo
        if (personalizacionFurtivos != null)
        {
            //Asignamos los datos al personaje
            personalizacionFurtivos.ConvertirDesdeTexto(split.furtivos); // Ejecutamos el metodo para traer la informacion de la personalizacion guardada pero en el local
            if (managerBD != null)
            {
                TraerInformacionPersonalizacion(managerBD.AsignarIdUsuario()); // Ejecutamos el metodo para traer la informacion de la personalizacion guardada en la BD
            }  
        }    
    }



    /// <summary>
    ///  Metodo que puede ser invocado para traer la personalizacion que se tenga guardada en la base de datos, pasandole el numero de cedula
    /// </summary>
    /// <param name="id"></param>
    public void TraerInformacionPersonalizacion(int id)
    {
        // Llamamos la currutina
        StartCoroutine(ObtenerPersonalizacion(id, procesador));
    }

    /// <summary>
    /// Currutina encargada de consultar la base de datos y traer la informacion del usuario especificado
    /// </summary>
    /// <param name="idUsuario"> Cedula del usuario </param>
    /// <param name="procesador"> Referencia al scrip procesador de informacion </param>
    /// <returns></returns>
    public IEnumerator ObtenerPersonalizacion(int idUsuario, ProcesadorDeDatos procesador)
    {
        // Creación del formulario
        WWWForm form = new WWWForm();
        // Enviamos la cedula que este logueada
        form.AddField("id_usuario", idUsuario);

        //Enviamos la solicitud Post
        using (UnityWebRequest www = UnityWebRequest.Post(url_consulta_p, form))
        {
            yield return www.SendWebRequest();

            //Si la solicitud es correcta y exitosa
            if (www.result == UnityWebRequest.Result.Success)
            {
                // Acciones a realizar
                Debug.Log("Respuesta recibida: " + www.downloadHandler.text);
                // Parsear la respuesta
                int[] resultado = procesador.RespuestaProcesada(www.downloadHandler.text);

                // Asignamos al furtivo que este loggeado la personalizacion guardada en la base de datos

                personalizacionFurtivos.TraerInformacionBD(resultado);
                
                // Asignamos los valores al managerBD para tener siempre la BD a la mano
                for (int i = 0; i < resultado.Length; i++)
                {
                    managerBD.datos[i] = resultado[i];
                }
            }
            else
            {
                // Acciones a realizar
                Debug.LogError("Error al realizar la solicitud: " + www.error);
            }
        }
    }
}
