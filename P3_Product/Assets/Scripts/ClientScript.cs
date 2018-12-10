using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ClientScript : MonoBehaviour
{

    bool lookingForTower = false;
    bool lookingForGrid = true;
    public string[] arrayPos;

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
    public string GetPosition()
    {
        if (!client.Connected)
        {
            receivedMsg = "";
            Debug.Log("client not connected!"); return "Client not connected, no position!";
        }
        // setup asynchronous read
        var stream = client.GetStream();
        stream.BeginRead(buf, 0, buf.Length, Message_Received, null);

        // ask the server for a position (start CV and push back a location)
        if (lookingForGrid)
        {
            byte[] message = Encoding.ASCII.GetBytes("GRID");
            stream.Write(message, 0, message.Length);
            // after we get the grid once, we switch the bools to make sure we detect towers from then on...
            switchMsg();
        }
        if (lookingForTower)
        {
            byte[] message = Encoding.ASCII.GetBytes("TOWER");
            stream.Write(message, 0, message.Length);
        }

        //return receivedMsg;


        return "[[308, 4], [311, 6], [211, 9], [278, 13]]";
    }

    // callback method that runs when a message is received from the stream
    void Message_Received(IAsyncResult res)
    {
        if (res.IsCompleted && client.Connected)
        {
            var stream = client.GetStream();
            // bytesIn contains the values of the buf
            int bytesIn = stream.EndRead(res);
            // convert the received message to a string that can be converted to coords
            //receivedMsg = Encoding.ASCII.GetString(buf, 0, bytesIn);
            receivedMsg = "[1522, 978], [1412, 978], [1301, 978], [1191, 978], [1080, 978], [970, 978], [860, 978], [639, 978], [529, 978], [417, 978], [307, 978], [1522, 870], [1411, 870], [1301, 870], [1191, 870], [1080, 870], [970, 870], [859, 870], [307, 871], [1522, 762], [1411, 762], [1301, 762], [1191, 762], [1080, 762], [970, 762], [859, 762], [749, 762], [639, 762], [529, 763], [307, 763], [1522, 654], [1411, 654], [1301, 654], [1190, 653], [1080, 654], [970, 654], [528, 654], [307, 653], [1521, 546], [1412, 545], [1300, 546], [1190, 545], [1081, 545], [749, 545], [306, 546], [1522, 437], [859, 437], [749, 437], [639, 437], [528, 437], [418, 437], [307, 437], [1522, 329], [1301, 329], [1190, 329], [1080, 329], [969, 329], [859, 329], [749, 329], [639, 329], [528, 329], [418, 329], [307, 329], [1522, 221], [1302, 221], [1191, 221], [1081, 221], [970, 221], [859, 221], [749, 221], [637, 221], [528, 221], [418, 221], [307, 221], [1522, 113], [858, 113], [749, 113], [638, 113], [528, 113], [417, 113], [307, 113], [1521, 5], [1411, 5], [1300, 5], [1190, 5], [1081, 4], [860, 4], [750, 4], [639, 4], [529, 4], [417, 5], [308, 4]";
            if (lookingForGrid)
            {
                string tempGridMsg = receivedMsg.Replace("[",string.Empty);
                string temp2gridMsg = tempGridMsg.Replace("]",":");
                string gridMsg = temp2gridMsg.Replace(":,", ":");
                arrayPos = gridMsg.Split(":" [0]);
                Debug.Log("position of A1: " + arrayPos[91] + " position of A2: " + arrayPos[90]);
            }
            
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
    // a small funtion to switch up our booleans controlling what we ask from the server
    public void switchMsg()
    {
        lookingForGrid = !lookingForGrid;
        lookingForTower = !lookingForTower;
    }
}