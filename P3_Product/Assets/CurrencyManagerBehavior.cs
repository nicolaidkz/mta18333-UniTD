using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManagerBehavior : MonoBehaviour {
    public Text currencyText;
    private int currency;
    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
            currency = value;
            currencyText.GetComponent<Text>().text = currency + " $";
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
