using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Morion Servidor/Gestion Mensajes Servidor")]
public class GestionMensajesServidor : MonoBehaviour
{
    public static GestionMensajesServidor singeton;


	private void Awake()
	{
		singeton = this;
	}

	public void RecibirMensaje(string mensaje)
	{
		print("MENSAJE:" + mensaje);
		string codigo = mensaje.Substring(0, 4);
		string msj = mensaje.Substring(4);
		switch (codigo)
		{
			case "PR00":
				PR00(msj);
				break;
			case "AT00":
				AT00(msj);
				break;
			case "AC00":
				AC00(msj);
				break;
			default:
				break;
		}
	}
	public void EnviarMensaje(string msj)
	{
		Servidor.singleton.EnviarMensaje(msj);
	}
	public void PR00(string msj)
	{

	}
	public void AT00(string msj)
	{

	}
	public void AC00(string msj)
	{

	}
}
