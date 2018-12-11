using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShot : MonoBehaviour
{

    public float Speed = 1f;
    public int Damage = 1;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shot(bool rightSide)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("no rigidbody found on " + gameObject.name);
            return;
        }
        if (rightSide)
        {
            rb.velocity = new Vector2(Speed, 0);
            Debug.Log("Going Right at that speed : " + rb.velocity);
        }
        else
        {
            rb.velocity = new Vector2(-Speed, 0);
            Debug.Log("Going Left at that speed : " + rb.velocity);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Ennemy")
        {
            if (collision.gameObject.GetComponent<EnemyScript>())
            {
                collision.gameObject.GetComponent<EnemyScript>().getHurt(Damage);
                Destroy(gameObject);
            }
        }
    }
}
