using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ClientScript : MonoBehaviour
{

    // client init and buffer init
    TcpClient client;
    byte[] buf = new byte[4096];
    string receivedMsg;
    // debug text-field to identify proper connection
    public Text debugText;

    // ip and port to connect to!
    public string ipAddress = "127.0.0.1";
    public int port = 54000;

    // function to request a scan for position of game elements
    public void GetPosition()
    {

        if (!client.Connected)
        {
            receivedMsg = "";
            Debug.Log("client not connected!"); return;
        }
        // setup asynchronous read
        var stream = client.GetStream();
        stream.BeginRead(buf, 0, buf.Length, Message_Received, null);

        // ask the server for a position (start CV and push back a location)
        byte[] message = Encoding.ASCII.GetBytes("TEST");
        stream.Write(message, 0, message.Length);

    }

    // callback method that runs when a message is received from the stream
    void Message_Received(IAsyncResult res)
    {
        if (res.IsCompleted && client.Connected)
        {
            var stream = client.GetStream();
            // bytesIn contains the values of the buf
            int bytesIn = stream.EndRead(res);
            // convert the received message to a string that can be displayed in debugText
            receivedMsg = Encoding.ASCII.GetString(buf, 0, bytesIn);
        }
    }

    // Use this for initialization
    void Start()
    {
        // get a client socket using ip and port
        client = new TcpClient();
        client.Connect(ipAddress, port);



    }

    // Update is called once per frame
    void Update()
    {

        // if there is a message (it is not blank)
        // we set the debbugText = that message, and blank it out
        // we blank so that it wont continually update the text..
        if (!String.IsNullOrEmpty(receivedMsg))
        {
            debugText.text = receivedMsg;
            receivedMsg = "";
        }
    }

    private void OnDestroy()
    {
        if (client.Connected)
        {
            // if a client is still connected on destroy, close it! 
            client.Close();
        }
    }
}