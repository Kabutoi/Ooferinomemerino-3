using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

        
        

	}
}
