using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelToPosition : MonoBehaviour {

    public GameObject posMaster;

	// Use this for initialization
	void Start () {
        posMaster = GameObject.Find("PositionMaster");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string PixelMatch(int x, int y)
    {
        Debug.Log("entered Pixelmatch");
        var cScript = posMaster.GetComponent<ClientScript>();
        int[] xValues = new int[120];
        int[] yValues = new int[120];

        Debug.Log("SANITY IS: " + cScript.arrayPos[0]);
        int tempX;
        int tempY;
        string[] tempCoords;
        for (int i = 0; i < 92 ; i++)
        {
           


            tempCoords = cScript.arrayPos[i].Split(","[0]);
            tempX = int.Parse(tempCoords[0]);
            tempY = int.Parse(tempCoords[1]);
            xValues[i] = tempX;
            yValues[i] = tempY;
            Debug.Log("Node"+(i+1)+"s X value is " + xValues[i] + " | Y value is " + yValues[i]);
        }
        
        if (x < 415 && x > 307 && y < 113 && y > 2)
        {
            // place at A1

            return "A1";
        }
        else if (x < 529 && x > 417 && y < 113 && y > 2)
        {
            // place at A2
            return "A2";
        }

        else return "None";
    }

}
