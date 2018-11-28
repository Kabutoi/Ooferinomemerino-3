using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai : MonoBehaviour {
    public Transform Player;

    public float Range = 10f;

    public float Speed = 4;

    public float Stop = 2;

    

    public Transform MyTransform;

    public int SmallMeleeBoisDamage = 1;

    public Rigidbody Enemy;
   
    // Update is called once per frame
    void FixedUpdate () {

        //calculates the distance between the player and the enemy then stores it into a variable
        var distance = Vector3.Distance(transform.position, Player.position);

        //this checks if its in range and if it is it will first look at the player then it will move in that direction
        if (distance<=Range)
        {
            transform.LookAt(Player);

            transform.position += transform.forward * Speed * Time.fixedDeltaTime;


       

        }





        //sidenote this will be used for damage but for now it is empty also this small enemy is a melee enemy
        if (distance <= Stop)
        {
            Debug.Log("oof");
            //stops the movement because it cancels out the movement
            transform.position -= transform.forward * Speed * Time.fixedDeltaTime;
            //first this goes into the script healyh and then looks at the health vaule then  decreases it by 1 every frame
            Player.GetComponent<Healyh>().Health -= SmallMeleeBoisDamage;
            
            


        }



        Enemy.AddForce(0, -1000, 0);
    }
}
