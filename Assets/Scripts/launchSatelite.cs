using UnityEngine;
using System.Collections;

public class launchSatelite : MonoBehaviour {
    public Rigidbody Satelite;
    public float speed = 5;
    private Rigidbody launchedProjectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            speed = 5;
            launchedProjectile = Instantiate(Satelite, transform.position, transform.rotation) as Rigidbody;

            launchedProjectile.transform.SetParent(this.transform);
            
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (speed < 40)
            {
                speed += 0.1f;
                //Debug.Log("Speed: " + speed);
            }
			launchedProjectile.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            launchedProjectile.transform.SetParent(transform.parent.transform.parent.transform.parent);
            launchedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            launchedProjectile.GetComponent<orbitingObject>().enabled = true;
            launchedProjectile.GetComponent<TrailRenderer>().enabled = true;
            launchedProjectile.GetComponentInChildren<TrailRenderer>().enabled = true;
            launchedProjectile.GetComponent<rocket>().enabled = true;
            launchedProjectile.tag = "satelite";
        }
        

    }
}
