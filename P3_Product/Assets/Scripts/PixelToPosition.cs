using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelToPosition : MonoBehaviour {

    public GameObject posMaster;
    public string[] arrayPos;
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

        //Debug.Log("SANITY IS: " + cScript.arrayPos[0]);
        int tempX;
        int tempY;
        string[] tempCoords;
        string grid = "[1522, 978], [1412, 978], [1301, 978], [1191, 978], [1080, 978], [970, 978], [860, 978], [639, 978], [529, 978], [417, 978], [307, 978], [1522, 870], [1411, 870], [1301, 870], [1191, 870], [1080, 870], [970, 870], [859, 870], [307, 871], [1522, 762], [1411, 762], [1301, 762], [1191, 762], [1080, 762], [970, 762], [859, 762], [749, 762], [639, 762], [529, 763], [307, 763], [1522, 654], [1411, 654], [1301, 654], [1190, 653], [1080, 654], [970, 654], [528, 654], [307, 653], [1521, 546], [1412, 545], [1300, 546], [1190, 545], [1081, 545], [749, 545], [306, 546], [1522, 437], [859, 437], [749, 437], [639, 437], [528, 437], [418, 437], [307, 437], [1522, 329], [1301, 329], [1190, 329], [1080, 329], [969, 329], [859, 329], [749, 329], [639, 329], [528, 329], [418, 329], [307, 329], [1522, 221], [1302, 221], [1191, 221], [1081, 221], [970, 221], [859, 221], [749, 221], [637, 221], [528, 221], [418, 221], [307, 221], [1522, 113], [858, 113], [749, 113], [638, 113], [528, 113], [417, 113], [307, 113], [1521, 5], [1411, 5], [1300, 5], [1190, 5], [1081, 4], [860, 4], [750, 4], [639, 4], [529, 4], [417, 4], [308, 4]";
        string tempGridMsg = grid.Replace("[", string.Empty);
        string temp2gridMsg = tempGridMsg.Replace("]", ":");
        string gridMsg = temp2gridMsg.Replace(":,", ":");
        arrayPos = gridMsg.Split(":"[0]);
        for (int i = 0; i < 92 ; i++)
        {
           
            tempCoords = arrayPos[i].Split(","[0]);
            tempX = int.Parse(tempCoords[0]);
            tempY = int.Parse(tempCoords[1]);
            xValues[i] = tempX;
            yValues[i] = tempY;
            //Debug.Log("Node"+(i+1)+"s X value is " + xValues[i] + " | Y value is " + yValues[i]);
        }
        
        #region Node area definitions.
        int Areavalue = 0;
        if (x >= xValues[91] && x <= xValues[90] && y >= yValues[91] && y <= yValues[90])
        {
            // place at A1
            return "A1";
        }
        else if (x >= xValues[90] && x <= xValues[89] && y >= yValues[90] && y <= yValues[89])
        {
            // place at A2
            return "A2";
        }
        else if (x >= xValues[89] && x <= xValues[88] && y >= yValues[89] && y <= yValues[88])
        {
            // place at A3
            return "A3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A4
            return "A4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A5
            return "A5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A6
            return "A6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A7
            return "A7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A8
            return "A8";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A9
            return "A9";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A10
            return "A10";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at A11
            return "A11";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at B1
            return "B1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at B2
            return "B2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at B3
            return "B3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at B4
            return "B4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at B5
            return "B5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at B6
            return "B6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at B7
            return "B7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C1
            return "C1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C2
            return "C2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C3
            return "C3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C4
            return "C4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C5
            return "C5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C6
            return "C6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C7
            return "C7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C8
            return "C8";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C9
            return "C9";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C10
            return "C10";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at C11
            return "C11";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D1
            return "D11";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D2
            return "D2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D3
            return "D3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D4
            return "D4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D5
            return "D5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D6
            return "D6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D7
            return "D7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D8
            return "D8";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D9
            return "D9";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D10
            return "D10";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at D11
            return "D11";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at E1
            return "E1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at E2
            return "E2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at E3
            return "E3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at E4
            return "E4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at E5
            return "E5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at E6
            return "E6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at E7
            return "E7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at F1
            return "F1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at F2
            return "F2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at F3
            return "F3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at F4
            return "F4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at F5
            return "F5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at F6
            return "F6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at F7
            return "F7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G1
            return "G1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G2
            return "G2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G3
            return "G3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G4
            return "G4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G5
            return "G5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G6
            return "G6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G7
            return "G7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at G8
            return "G8";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H1
            return "H1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H2
            return "H2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H3
            return "H3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H4
            return "H4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H5
            return "H5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H6
            return "H6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H7
            return "H7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H8
            return "H8";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H9
            return "H9";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H10
            return "H10";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at H11
            return "H11";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I1
            return "I1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I2
            return "I2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I3
            return "I3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I4
            return "I4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I5
            return "I5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I6
            return "I6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I7
            return "I7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at I8
            return "I8";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J1
            return "J1";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J2
            return "J2";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J3
            return "J3";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J4
            return "J4";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J5
            return "J5";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J6
            return "J6";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J7
            return "J7";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J8
            return "J8";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J9
            return "J9";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J10
            return "J10";
        }
        Areavalue++; if (x < xValues[90 - Areavalue] && x > xValues[89 - Areavalue] && y < yValues[90 - Areavalue] && y > yValues[89 - Areavalue])
        {
            // place at J11
            return "J11";
        }
        else return "None";
    }
    #endregion
}