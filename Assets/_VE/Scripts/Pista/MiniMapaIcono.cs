using System.Collections;
using UnityEngine;

public class MiniMapaIcono : MonoBehaviour
{
    public Transform        vehiculo; // Referencia al veh�culo
    public Transform        MinimapaIcono; // Referencia al �cono en el minimapa
    public Vector2          minimapaLimites; // L�mites del minimapa en t�rminos de espacio, aqui colocar en X y en Y la misma escala que tenga la pista original en ambos vertices
    public SpriteRenderer   spriteRenderer; // Referencia al sprite del objeto icono
    private bool            cambioColor; // Booleano para determinar hasta cuando podemos cambiar de color

    private void Start()
    {
        // Iniciamos currutina de cambio de color
        StartCoroutine(CambiarColorIcono());
    }

    void Update()
    {
        // Convertimos la posici�n del veh�culo a coordenadas del minimapa
        Vector3 vehiclePos = vehiculo.position;

        // Actualizamos la posici�n del �cono, la posicion Y la multiplicamos por 3 para tener el icono un poco mas alto que la posicion original del vehiculo y evitar bugs visuales
        MinimapaIcono.position = new Vector3(vehiclePos.x, vehiclePos.y * 3, vehiclePos.z);
    }

    public IEnumerator CambiarColorIcono()
    {
        // Mientras que sea falso, cambiaremos el color del icono rapidamente entre diferentes colores
        while (!cambioColor)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.yellow;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.blue;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.green;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
