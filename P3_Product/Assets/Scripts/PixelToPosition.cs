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

    public string PixelMatch(int x, int y)
    {
        Debug.Log("entered Pixelmatch");

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
