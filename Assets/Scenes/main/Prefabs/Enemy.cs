using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem explosion;
    Rigidbody enemyRB;
    
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();      
    }

    void FixedUpdate()
    {
        Vector3 cameraLocation = Camera.main.transform.position;
        enemyRB.AddForce((cameraLocation - transform.position) / 3, ForceMode.Impulse);
    }

    public void CustomDestroy() {        
        ParticleSystem exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.Play();
        Destroy(gameObject);
    }

}
