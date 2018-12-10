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

        #region Node area definitions.
        int Areavalue = 0;
        if (x < xValues[91] && x > xValues[90] && y < yValues[91] && y > yValues[90])
        {
            // place at A1
            return "A1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A2
            return "A2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A3
            return "A3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A4
            return "A4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A5
            return "A5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A6
            return "A6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A7
            return "A7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A8
            return "A8";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A9
            return "A9";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A10
            return "A10";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at A11
            return "A11";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at B1
            return "B1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at B2
            return "B2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at B3
            return "B3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at B4
            return "B4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at B5
            return "B5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at B6
            return "B6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at B7
            return "B7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C1
            return "C1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C2
            return "C2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C3
            return "C3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C4
            return "C4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C5
            return "C5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C6
            return "C6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C7
            return "C7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C8
            return "C8";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C9
            return "C9";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C10
            return "C10";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at C11
            return "C11";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D1
            return "D11";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D2
            return "D2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D3
            return "D3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D4
            return "D4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D5
            return "D5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D6
            return "D6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D7
            return "D7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D8
            return "D8";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D9
            return "D9";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D10
            return "D10";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at D11
            return "D11";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at E1
            return "E1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at E2
            return "E2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at E3
            return "E3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at E4
            return "E4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at E5
            return "E5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at E6
            return "E6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at E7
            return "E7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at F1
            return "F1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at F2
            return "F2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at F3
            return "F3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at F4
            return "F4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at F5
            return "F5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at F6
            return "F6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at F7
            return "F7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G1
            return "G1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G2
            return "G2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G3
            return "G3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G4
            return "G4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G5
            return "G5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G6
            return "G6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G7
            return "G7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at G8
            return "G8";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H1
            return "H1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H2
            return "H2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H3
            return "H3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H4
            return "H4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H5
            return "H5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H6
            return "H6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H7
            return "H7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H8
            return "H8";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H9
            return "H9";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H10
            return "H10";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at H11
            return "H11";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I1
            return "I1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I2
            return "I2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I3
            return "I3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I4
            return "I4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I5
            return "I5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I6
            return "I6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I7
            return "I7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at I8
            return "I8";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J1
            return "J1";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J2
            return "J2";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J3
            return "J3";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J4
            return "J4";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J5
            return "J5";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J6
            return "J6";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J7
            return "J7";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J8
            return "J8";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J9
            return "J9";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J10
            return "J10";
        }
        else if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            Areavalue++;
            // place at J11
            return "J11";
        }
        else return "None";
    }
    #endregion
}