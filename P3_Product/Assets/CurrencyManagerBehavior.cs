using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManagerBehavior : MonoBehaviour {
    public Text currencyText;
    private int p1Currency;
    public int Currency
    {
        get
        {
            return p1Currency;
        }
        set
        {
            p1Currency = value;
            currencyText.GetComponent<Text>().text = "P1 " + p1Currency + " $";
        }
    }

    // Use this for initialization
    void Start () {
        Currency = 1000; 
    }
	
	// Update is called once per frame
	void Update () {

    }
}
