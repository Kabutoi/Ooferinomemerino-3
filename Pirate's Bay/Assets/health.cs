using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour {

    public int Health = 100;

    public Text HEALTHBAR;

              

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        //sets healthbar to the health var but before it does that it has to turn it into a string because text cannot display ints or floats
    HEALTHBAR.text = Health.ToString();
        if (Health <= 0)
        {

            

            Destroy(gameObject);
        }


	}
}
