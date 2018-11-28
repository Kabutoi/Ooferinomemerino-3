using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float FireRate = 15f;
    public float ImpactForce = 30f;

    

    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;

    private float NextTimeToFire = 0f;


	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire) {

            NextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
            

        }

	}

    void Shoot() {

        MuzzleFlash.Play(); // script to play muzzle flash when you shoot

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) { //This part is the actual Raycast part it turns the fpsCam into a position and then takes the fpsCam again and makes it so it's the forward part and then shoots a Ray to another hit box

            Debug.Log(hit.transform.name); // just debug to see if gun was working

            EnemyDamage EnemyDamage = hit.transform.GetComponent<EnemyDamage>();
            if (EnemyDamage != null) // this is saying if the enemy is taking Enemydamage to make them take damage
            {
                EnemyDamage.TakeDamage(damage);
            }

            if (hit.rigidbody != null)  //This is adding knockback to what gets hit by guns
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce); //-hit means they are getting hit backwards which is them multiplied by the impact force
            }

            Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal)); // This is adding the bullet rickechy off ground and other surfaces (the look rotation is to make the animation play facing outwards instead of inwards towards the object)
        }
    }
}
