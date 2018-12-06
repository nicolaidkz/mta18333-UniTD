using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelToPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string PixelMatch(int x, int y)
    {
        if (x < 1 && x > 2 && y < 1 && y > 2)
        {
            // place at A1

            return "A1";
        }
        else if (x < 1 && x > 2 && y < 1 && y > 2)
        {
            // place at A2
            return "A2";
        }

        else return "None";
    }

}
