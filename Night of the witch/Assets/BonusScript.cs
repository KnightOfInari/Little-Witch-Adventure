using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerScript>())
            {
                collision.gameObject.GetComponent<PlayerScript>().getBonus(gameObject);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
