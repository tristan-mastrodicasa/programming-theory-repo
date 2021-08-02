using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ENCAPSULATION
    public Material enemyMat { get; protected set; }
    public ParticleSystem explosion;
    protected Rigidbody enemyRB;

    // ABSTRACTION
    protected virtual void Move() {
        Vector3 cameraLocation = Camera.main.transform.position;
        enemyRB.AddForce((cameraLocation - transform.position) / 3, ForceMode.Impulse);
    }
    
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        if (enemyMat) GetComponent<Renderer>().material = enemyMat;
    }

    void FixedUpdate()
    {
        Move();
    }

    public void CustomDestroy() {        
        ParticleSystem exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.Play();
        Destroy(gameObject);
    }

}
