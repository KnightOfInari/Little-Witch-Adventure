using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {


    public GameObject shootingPoint;
    public GameObject shotPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
    public void Shoot()
    {
        bool direction = gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight;

        GameObject shot = Instantiate(shotPrefab, shootingPoint.transform);
        shot.GetComponent<StarShot>().Shot(direction);
    }

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
	}
}
