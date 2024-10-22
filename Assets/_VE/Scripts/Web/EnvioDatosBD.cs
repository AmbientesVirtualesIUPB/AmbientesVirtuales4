using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class EnvioDatosBD : MonoBehaviour
{
    //URL's
    [SerializeField]
    private string  url_personalizacion = "http://localhost/apiwebm/CRUD/Create/insertar_datos_personalizacion.php"; // URL que guardla la informacion de  personalizacion al momento de ser guardada
    [SerializeField]
    private string  url_usuario = "http://localhost/apiwebm/CRUD/Create/insertar_datos_usuario.php"; // URL para guardar la informacion de los usuarios

    // Datos de usuario, extraidos del script ConsumirApi
    public int      id_usuario; // id del usuario
    public int      tipo_usuario; // Si es docente o estudiante

    public int[]    datos = new int[21]; // Array de datos enteros (genero, maleta, cuerpo, cabeza, cejas, cabello, reloj, sombrero, zapatos, tamaño, color1, color2, color3, color4, color5, carroceria, aleron, silla, volante, llanta, bateria)
    public bool     debugEnConsola; // Gestionador de mensajes

    public static EnvioDatosBD instancia;

    void Awake()
    {
        // Si la instancia ya existe y no es esta, destruir la nueva
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Asignar la instancia a esta y asegurarse de que no se destruya
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Metodo invocado desde el script de personalizacion, este recibe los datos de la personalizacion
    /// </summary>
    public void EnviarDatosP()
    {
        StartCoroutine(EnviarDatosPersonalizacion());
    }

    /// <summary>
    /// Metodo invocado desde el script de consumirAPi, este recibe los datos del usuari y lo crea en la BD
    /// </summary>
    public void EnviarDatosU()
    {
        StartCoroutine(EnviarDatosUsuario());
    }

    /// <summary>
    /// Currutina que crea el formulario y lo envia en solicitud POST para guardar la infomracion de la personalizacion en la BD
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnviarDatosPersonalizacion()
    {
        // Creación del formulario
        WWWForm form = new WWWForm();
        form.AddField("id_usuario", id_usuario);

        // Asegúrate de que el array de datos tenga el tamaño correcto
        if (datos.Length != 21)
        {
            if (debugEnConsola) print("El array de datos debe tener exactamente 21 elementos");
            yield break; // Detiene la ejecución si el tamaño del array no es el correcto
        }

        // Añadir los datos al formulario
        for (int i = 0; i < datos.Length; i++)
        {
            form.AddField($"dato{i}", datos[i]);
        }

        // Enviar la solicitud POST
        using (UnityWebRequest www = UnityWebRequest.Post(url_personalizacion, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Almacenamos la respuesta del servidor
                string responseText = www.downloadHandler.text;
                if (debugEnConsola) print("Respuesta del servidor: " + responseText);

                // Verificar si la respuesta contiene un mensaje de error
                if (responseText.Contains("Error"))
                {
                    if (debugEnConsola) print("Respuesta Unity: " + "Error en la solicitud: " + responseText);
                    // Acciones a realizar
                }
                else if (responseText.Contains("Usuario no encontrado"))
                {
                    if (debugEnConsola) print("Respuesta Unity: " + "Usuario no encontrado en la base");
                    // Acciones a realizar
                }
                else
                {
                    if (debugEnConsola) print("Respuesta Unity: " + "Datos enviados con éxito");
                }
            }
            else
            {
                if (debugEnConsola) print("Respuesta Unity: " + "Error al enviar los datos: " + www.error);
            }
        }
    }

    /// <summary>
    /// Currutina que crea el formulario y lo envia en solicitud POST para guardar la infomracion del usuario en la BD
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnviarDatosUsuario()
    {
        // Creación del formulario
        WWWForm form = new WWWForm();
        form.AddField("id_usuario", id_usuario);
        form.AddField($"personalizacion", "personalizacion");
        form.AddField($"tiempo_uso", 0);
        form.AddField($"num_conexiones", 0);
        form.AddField($"genero", 0);
        form.AddField($"tipo_usuario", tipo_usuario);

        // Enviar la solicitud POST
        using (UnityWebRequest www = UnityWebRequest.Post(url_usuario, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Almacenamos la respuesta del servidor
                string responseText = www.downloadHandler.text;
                if (debugEnConsola) print("Respuesta del servidor: " + responseText);

                // Verificar si la respuesta contiene un mensaje de error
                if (responseText.Contains("Error"))
                {
                    if (debugEnConsola) print("Respuesta Unity: " + "Error en la solicitud: " + responseText);
                    // Acciones a realizar
                }
                else if (responseText.Contains("El usuario ya existe en el sistema"))
                {
                    if (debugEnConsola) print("Respuesta Unity: " + "El usuario ya esta creado");
                    // Acciones a realizar
                }
                else
                {
                    if (debugEnConsola) print("Respuesta Unity: " + "Datos enviados con éxito");
                }
            }
            else
            {
                if (debugEnConsola) print("Respuesta Unity: " + "Error al enviar los datos: " + www.error);
            }
        }
    }

    /// <summary>
    /// Metodo invocado desde el script de personalizacion para traer la informacion almacenada en la base de datos
    /// </summary>
    /// <returns> Regresa la cedula del usuario logueado </returns>
    public int AsignarIdUsuario()
    {
        return id_usuario;
    }

    /// <summary>
    /// metodo y currutina para pruebas
    /// </summary>
    public void CambioScena()
    {
        StartCoroutine(CambiarEscena("Taller 1"));
    }

    public IEnumerator CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
        yield return new WaitForSeconds(1f);
    }
}
