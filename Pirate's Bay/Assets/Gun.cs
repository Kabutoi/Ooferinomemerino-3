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

            EnemyDamage EnemyDamage = hit.transform.GetComponent<EnemyDamage>(); // this is say enemy damage script is equal to enemy damage 
            if (EnemyDamage != null)
            {
                EnemyDamage.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

            Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
