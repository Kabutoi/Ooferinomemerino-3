using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healyh : MonoBehaviour {

    public int Health = 300;

    public void Die()
    {
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {

        if (Health <= 0)
        {
            Die();
        }

        
        

	}
}
