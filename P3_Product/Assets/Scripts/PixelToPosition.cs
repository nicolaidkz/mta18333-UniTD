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
        string grid = "[542, 407], [496, 407], [451, 407], [405, 407], [360, 407], [314, 407], [269, 407], [179, 407], [133, 408], [87, 409], [42, 409], [542, 363], [496, 363], [450, 363], [405, 362], [359, 363], [314, 363], [269, 363], [42, 365], [541, 318], [495, 318], [449, 318], [404, 318], [359, 318], [314, 318], [269, 318], [224, 318], [179, 319], [134, 319], [43, 321], [541, 274], [495, 274], [449, 274], [404, 274], [359, 274], [314, 274], [133, 275], [43, 276], [541, 229], [495, 229], [449, 229], [402, 235], [359, 230], [224, 231], [42, 235], [540, 184], [269, 187], [224, 187], [179, 187], [133, 187], [88, 187], [42, 187], [540, 140], [448, 141], [403, 142], [358, 142], [313, 142], [268, 142], [223, 143], [178, 143], [133, 145], [88, 143], [42, 143], [539, 96], [449, 97], [403, 97], [358, 98], [313, 98], [268, 99], [223, 99], [178, 99], [133, 99], [88, 99], [42, 99], [539, 52], [268, 54], [223, 54], [178, 54], [132, 54], [87, 55], [42, 55], [539, 0], [494, 0], [448, 0], [403, 0], [358, 0], [268, 0], [223, 0], [177, 0], [132, 0], [87, 0], [42, 0]";
        string tempGridMsg = grid.Replace("[", string.Empty);
        string temp2gridMsg = tempGridMsg.Replace("]", ":");
        string gridMsg = temp2gridMsg.Replace(":,", ":");
        arrayPos = gridMsg.Split(":"[0]);
        for (int i = 0; i < 92 ; i++)
        {
            tempCoords = arrayPos[i].Split(","[0]);
            tempX = int.Parse(tempCoords[0]);
            tempY = int.Parse(tempCoords[1]);
            xValues[i] = tempX - 30;
            yValues[i] = tempY + 10;
            Debug.Log("Node"+(i+1)+"s X value is " + xValues[i] + " | Y value is " + yValues[i]);
        }

        #region Node area definitions.
 
        if (x >= xValues[91] && x <= xValues[90] && y <= yValues[80] && y >= yValues[91])
        {
            // place at A1
            return "A1";
        }
        else if (x >= xValues[90] && x <= xValues[89] && y <= yValues[79] && y >= yValues[90])
        {
            // place at A2
            return "A2";
        }
        else if (x >= xValues[89] && x <= xValues[88] && y <= yValues[78] && y >= yValues[89])
        {
            // place at A3
            return "A3";
        }
        else if (x >= xValues[88] && x <= xValues[87] && y <= yValues[77] && y >= yValues[88])
        {
            // place at A4
            return "A4";
        }
        else if (x >= xValues[87] && x <= xValues[86] && y <= yValues[76] && y >= yValues[87])
        {
            // place at A5
            return "A5";
        }
        else if (x >= xValues[86] && x <= xValues[85] && y <= yValues[75] && y >= yValues[86])
        {
            // place at A6
            return "A6";
        }
        else if (x >= xValues[85] && x <= xValues[84] && y <= yValues[74] && y >= yValues[85])
        {
            // place at A7
            return "A7";
        }
        else if (x >= xValues[84] && x <= xValues[83] && y <= yValues[73] && y >= yValues[84])
        {
            // place at A8
            return "A8";
        }
        else if (x >= xValues[83] && x <= xValues[82] && y <= yValues[72] && y >= yValues[83])
        {
            // place at A9
            return "A9";
        }
        else if (x >= xValues[82] && x <= xValues[81] && y <= yValues[71] && y >= yValues[82])
        {
            // place at A10
            return "A10";
        }
        else if (x >= xValues[81] && y <= yValues[70] && y >= yValues[81])
        {
            // place at A11
            return "A11";
        }
        else if (x >= xValues[80] && x <= xValues[79] && y <= yValues[69] && y >= yValues[80])
        {
            // place at B1
            return "B1";
        }
       else if (x >= xValues[79] && x <= xValues[78] && y <= yValues[68] && y >= yValues[79])
        {
            
            // place at B2
            return "B2";
        }
        else if (x >= xValues[78] && x <= xValues[77] && y <= yValues[67] && y >= yValues[78])
        {
            
            // place at B3
            return "B3";
        }
        else if (x >= xValues[77] && x <= xValues[76] && y <= yValues[66] && y >= yValues[77])
        {
            
            // place at B4
            return "B4";
        }
        else if (x >= xValues[76] && x <= xValues[75] && y <= yValues[65] && y >= yValues[76])
        {
            
            // place at B5
            return "B5";
        }
        else if (x >= xValues[75] && x <= xValues[74] && y <= yValues[64] && y >= yValues[75])
        {
            
            // place at B6
            return "B6";
        }
        else if (x >= xValues[74] && y <= yValues[63] && y >= yValues[74])
        {
            
            // place at B7
            return "B7";
        }
        else if (x >= xValues[73] && x <= xValues[72] && y <= yValues[62] && y >= yValues[73])
        {
            
            // place at C1
            return "C1";
        }
        else if (x >= xValues[72] && x <= xValues[71] && y <= yValues[61] && y >= yValues[72])
        {
            
            // place at C2
            return "C2";
        }
        else if (x >= xValues[71] && x <= xValues[70] && y <= yValues[60] && y >= yValues[71])
        {
            
            // place at C3
            return "C3";
        }
        else if (x >= xValues[70] && x <= xValues[69] && y <= yValues[59] && y >= yValues[70])
        {
            
            // place at C4
            return "C4";
        }
        else if (x >= xValues[69] && x <= xValues[68] && y <= yValues[58] && y >= yValues[69])
        {
            
            // place at C5
            return "C5";
        }
        else if (x >= xValues[68] && x <= xValues[67] && y <= yValues[57] && y >= yValues[68])
        {
            
            // place at C6
            return "C6";
        }
        else if (x >= xValues[67] && x <= xValues[66] && y <= yValues[56] && y >= yValues[67])
        {
            
            // place at C7
            return "C7";
        }
        else if (x >= xValues[66] && x <= xValues[65] && y <= yValues[55] && y >= yValues[66])
        {
            
            // place at C8
            return "C8";
        }
        else if (x >= xValues[65] && x <= xValues[64] && y <= yValues[54] && y >= yValues[65])
        {
            
            // place at C9
            return "C9";
        }
        else if (x >= xValues[64] && x <= xValues[63] && y <= yValues[53] && y >= yValues[64])
        {
            
            // place at C10
            return "C10";
        }
        else if (x >= xValues[63] && y <= yValues[52] && y >= yValues[63])
        {
            
            // place at C11
            return "C11";
        }
        else if (x >= xValues[62] && x <= xValues[61] && y <= yValues[51] && y >= yValues[62])
        {
            
            // place at D1
            return "D1";
        }
        else if (x >= xValues[61] && x <= xValues[60] && y <= yValues[50] && y >= yValues[61])
        {
            
            // place at D2
            return "D2";
        }
        else if (x >= xValues[60] && x <= xValues[59] && y <= yValues[49] && y >= yValues[60])
        {
            
            // place at D3
            return "D3";
        }
        else if (x >= xValues[59] && x <= xValues[58] && y <= yValues[48] && y >= yValues[59])
        {
            
            // place at D4
            return "D4";
        }
        else if (x >= xValues[58] && x <= xValues[57] && y <= yValues[47] && y >= yValues[58])
        {
            
            // place at D5
            return "D5";
        }
        else if (x >= xValues[57] && x <= xValues[56] && y <= yValues[46] && y >= yValues[57])
        {
            
            // place at D6
            return "D6";
        }
        else if (x >= xValues[56] && x <= xValues[55] && y <= yValues[45] && y >= yValues[56])
        {
            
            // place at D7
            return "D7";
        }
        else if (x >= xValues[55] && x <= xValues[54] && y <= yValues[44] && y >= yValues[55])
        {
            
            // place at D8
            return "D8";
        }
        else if (x >= xValues[54] && x <= xValues[53] && y <= yValues[43] && y >= yValues[54])
        {
            
            // place at D9
            return "D9";
        }
        else if (x >= xValues[53] && x <= xValues[52] && y <= yValues[42] && y >= yValues[53])
        {
            
            // place at D10
            return "D10";
        }
        else if (x >= xValues[52] && y <= yValues[41] && y >= yValues[52])
        {
            
            // place at D11
            return "D11";
        }
        else if (x >= xValues[51] && x <= xValues[50] && y <= yValues[40] && y >= yValues[51])
        {
            
            // place at E1
            return "E1";
        }
        else if (x >= xValues[50] && x <= xValues[49] && y <= yValues[39] && y >= yValues[50])
        {
            
            // place at E2
            return "E2";
        }
        else if (x >= xValues[49] && x <= xValues[48] && y <= yValues[38] && y >= yValues[49])
        {
            
            // place at E3
            return "E3";
        }
        else if (x >= xValues[48] && x <= xValues[47] && y <= yValues[37] && y >= yValues[48])
        {
            
            // place at E4
            return "E4";
        }
        else if (x >= xValues[47] && x <= xValues[46] && y <= yValues[48]+45 && y >= yValues[48])
        {
            
            // place at E5
            return "E5";
        }
        else if (x >= xValues[46] && x <= xValues[46]+50 && y <= yValues[48]+45 && y >= yValues[48])
        {
            
            // place at E6
            return "E6";
        }
        else if (x >= xValues[45] && y <= yValues[34] && y >= yValues[45])
        {
            
            // place at E7
            return "E7";
        }
        else if (x >= xValues[44] && x <= xValues[43] && y <= yValues[33] && y >= yValues[44])
        {
            
            // place at F1
            return "F1";
        }
        else if (x >= xValues[43] && x <= xValues[43]+50 && y <= yValues[44]+50 && y >= yValues[44])
        {
            
            // place at F2
            return "F2";
        }
        else if (x >= xValues[42] && x <= xValues[41] && y <= yValues[31] && y >= yValues[42])
        {
            
            // place at F3
            return "F3";
        }
        else if (x >= xValues[41] && x <= xValues[40] && y <= yValues[30] && y >= yValues[41])
        {
            
            // place at F4
            return "F4";
        }
        else if (x >= xValues[40] && x <= xValues[39] && y <= yValues[29] && y >= yValues[40])
        {
            
            // place at F5
            return "F5";
        }
        else if (x >= xValues[39] && x <= xValues[38] && y <= yValues[28] && y >= yValues[39])
        {
            
            // place at F6
            return "F6";
        }
        else if (x >= xValues[38] && y <= yValues[27] && y >= yValues[38])
        {
            
            // place at F7
            return "F7";
        }
        else if (x >= xValues[37] && x <= xValues[36] && y <= yValues[26] && y >= yValues[37])
        {
            
            // place at G1
            return "G1";
        }
        else if (x >= xValues[36] && x <= xValues[35] && y <= yValues[25] && y >= yValues[36])
        {
            
            // place at G2
            return "G2";
        }
        else if (x >= xValues[35] && x <= xValues[34] && y <= yValues[24] && y >= yValues[35])
        {
            
            // place at G3
            return "G3";
        }
        else if (x >= xValues[34] && x <= xValues[33] && y <= yValues[23] && y >= yValues[34])
        {
            
            // place at G4
            return "G4";
        }
        else if (x >= xValues[33] && x <= xValues[32] && y <= yValues[22] && y >= yValues[33])
        {
            
            // place at G5
            return "G5";
        }
        else if (x >= xValues[32] && x <= xValues[31] && y <= yValues[21] && y >= yValues[32])
        {
            
            // place at G6
            return "G6";
        }
        else if (x >= xValues[31] && x <= xValues[30] && y <= yValues[20] && y >= yValues[31])
        {
            
            // place at G7
            return "G7";
        }
        else if (x >= xValues[30] && y <= yValues[19] && y >= yValues[30])
        {
            
            // place at G8
            return "G8";
        }
        else if (x >= xValues[29] && x <= xValues[28] && y <= yValues[18] && y >= yValues[29])
        {
            
            // place at H1
            return "H1";
        }
        else if (x >= xValues[28] && x <= xValues[27] && y <= yValues[17] && y >= yValues[28])
        {
            
            // place at H2
            return "H2";
        }
        else if (x >= xValues[27] && x <= xValues[26] && y <= yValues[16] && y >= yValues[27])
        {
            
            // place at H3
            return "H3";
        }
        else if (x >= xValues[26] && x <= xValues[25] && y <= yValues[15] && y >= yValues[26])
        {
            
            // place at H4
            return "H4";
        }
        else if (x >= xValues[25] && x <= xValues[24] && y <= yValues[14] && y >= yValues[25])
        {
            
            // place at H5
            return "H5";
        }
        else if (x >= xValues[24] && x <= xValues[23] && y <= yValues[13] && y >= yValues[24])
        {
            
            // place at H6
            return "H6";
        }
        else if (x >= xValues[23] && x <= xValues[22] && y <= yValues[12] && y >= yValues[23])
        {
            
            // place at H7
            return "H7";
        }
        else if (x >= xValues[22] && x <= xValues[21] && y <= yValues[11] && y >= yValues[22])
        {
            
            // place at H8
            return "H8";
        }
        else if (x >= xValues[21] && x <= xValues[20] && y <= yValues[10] && y >= yValues[21])
        {
            
            // place at H9
            return "H9";
        }
        else if (x >= xValues[20] && x <= xValues[19] && y <= yValues[9] && y >= yValues[20])
        {
            
            // place at H10
            return "H10";
        }
        else if (x >= xValues[19] && y <= yValues[8] && y >= yValues[19])
        {
            
            // place at H11
            return "H11";
        }
        else if (x >= xValues[18] && x <= xValues[17] && y <= yValues[7] && y >= yValues[18])
        {
            
            // place at I1
            return "I1";
        }
        else if (x >= xValues[17] && x <= xValues[16] && y <= yValues[6] && y >= yValues[17])
        {
            
            // place at I2
            return "I2";
        }
        else if (x >= xValues[16] && x <= xValues[15] && y <= yValues[5] && y >= yValues[16])
        {
            
            // place at I3
            return "I3";
        }
        else if (x >= xValues[15] && x <= xValues[14] && y <= yValues[4] && y >= yValues[15])
        {
            
            // place at I4
            return "I4";
        }
        else if (x >= xValues[14] && x <= xValues[13] && y <= yValues[3] && y >= yValues[14])
        {
            
            // place at I5
            return "I5";
        }
        else if (x >= xValues[13] && x <= xValues[12] && y <= yValues[2] && y >= yValues[13])
        {
            
            // place at I6
            return "I6";
        }
        else if (x >= xValues[12] && x <= xValues[11] && y <= yValues[1] && y >= yValues[12])
        {
            
            // place at I7
            return "I7";
        }
        else if (x >= xValues[11] && y <= yValues[0] && y >= yValues[11])
        {
            
            // place at I8
            return "I8";
        }
        else if (x >= xValues[10] && x <= xValues[9] && y <= yValues[0] && y >= yValues[10])
        {
            
            // place at J1
            return "J1";
        }
        else if (x >= xValues[9] && x <= xValues[8] && y >= yValues[9])
        {
            
            // place at J2
            return "J2";
        }
        else if (x >= xValues[8] && x <= xValues[7] && y >= yValues[8])
        {
            
            // place at J3
            return "J3";
        }
        else if (x >= xValues[7] && x <= xValues[6] && y >= yValues[7])
        {
            
            // place at J4
            return "J4";
        }
        else if (x >= xValues[6] && x <= xValues[5] && y >= yValues[6])
        {
            
            // place at J5
            return "J5";
        }
        else if (x >= xValues[5] && x <= xValues[4] && y >= yValues[5])
        {
            
            // place at J6
            return "J6";
        }
        else if (x >= xValues[4] && x <= xValues[3] && y >= yValues[4])
        {
            
            // place at J7
            return "J7";
        }
        else if (x >= xValues[3] && x <= xValues[2] && y >= yValues[3])
        {
            
            // place at J8
            return "J8";
        }
        else if (x >= xValues[2] && x <= xValues[1] && y >= yValues[2])
        {
            
            // place at J9
            return "J9";
        }
        else if (x >= xValues[1] && x <= xValues[0] && y >= yValues[1])
        {
            
            // place at J10
            return "J10";
        }
        else if (x >= xValues[0] && y > yValues[0])
        {
            // place at J11
            return "J11";
        }
        else return "None";
    }
    #endregion
}