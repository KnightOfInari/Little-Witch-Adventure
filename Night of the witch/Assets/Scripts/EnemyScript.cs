using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int maxHealth = 1;
    private int currentHealth;
    public int Damage = 1;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getHurt(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
            isDead();
    }

    public void isDead()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().getHurt(Damage);
        }
    }

}
