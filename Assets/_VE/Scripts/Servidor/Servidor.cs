using System;
using System.Collections.Generic;
using UnityEngine;
using Best.WebSockets;
[RequireComponent(typeof(GestionMensajesServidor))]

public class Servidor : MonoBehaviour
{
    public delegate void Evento();

    public string url = "ws://127.0.0.1:8080";
    public bool debugEnPantalla = false;
    [ConditionalHide("debugEnPantalla", true)]
    public UnityEngine.UI.Text txtDebug;
    WebSocket ws;
    [HideInInspector]
    public GestionMensajesServidor gestorMensajes;
    public Evento EventoConectado;
    public static Servidor singleton;

    private void Awake()
    {
        singleton = this;
        gestorMensajes = GetComponent<GestionMensajesServidor>();
        EventoConectado += Vacio;
    }

    void Vacio()
    {
        return;
    }

    private void Start()
    {
        url = "ws://" +
                ConfiguracionGeneral.configuracionDefault.GetIP() +
                ":" +
                ConfiguracionGeneral.configuracionDefault.GetPuerto();
        Conectar();
    }
    public void CambairURL(string n_url)
    {
        url = n_url;
    }

    public void Conectar()
    {
        var webSocket = new WebSocket(new Uri(url));
        ws = webSocket;
        webSocket.OnOpen += OnWebSocketOpen;
        webSocket.OnMessage += OnMessageReceived;
        webSocket.OnClosed += OnWebSocketClosed;
        webSocket.Open();
        UnityEngine.SceneManagement.SceneManager.LoadScene("LP_CIS", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    private void OnWebSocketOpen(WebSocket webSocket)
    {
        Debug.Log("Websocket abierto!");
        if (txtDebug != null)
        {
            txtDebug.text += "\n" + ("Websocket abierto!");
        }

        if (EventoConectado != null)
            EventoConectado();
        //Presentacion p = ControlUsuario.singleton.GetPresentacion();
        //string pJson = JsonUtility.ToJson(p);

        //webSocket.Send("PR00" + pJson);
        webSocket.Send("AC00 ");
    }

    private void OnMessageReceived(WebSocket webSocket, string message)
    {
        Debug.Log("Mensaje recibido: " + message);
        if (txtDebug != null) txtDebug.text += "\n" + ("Mensaje recibido: " + message);
        if (txtDebug != null)
            if (txtDebug.text.Length > 500)
            {
                txtDebug.text = txtDebug.text.Substring(txtDebug.text.Length - 455);
            }
        if (gestorMensajes != null)
        {
            //gestorMensajes.RecibirMensaje(message.Substring(2));
        }
    }

    private void OnWebSocketClosed(WebSocket webSocket, WebSocketStatusCodes code, string message)
    {
        Debug.Log("WebSocket is now Closed!");

        if (code == WebSocketStatusCodes.NormalClosure)
        {
            // Cerrado normalmente
        }
        else
        {
            // Error
        }
    }
    public void EnviarMensaje(string msj)
    {
        ws.Send(msj);
    }
}
