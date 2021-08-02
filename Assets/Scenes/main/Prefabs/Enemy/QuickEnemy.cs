using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class QuickEnemy : Enemy
{
    // POLYMORPHISM
    protected override void Move() {
        Vector3 cameraLocation = Camera.main.transform.position;
        enemyRB.AddForce((cameraLocation - transform.position) / 2, ForceMode.Impulse);
    }

    void Awake() {
        foreach(Material matt in GetComponent<Renderer>().materials)
        {
            if(matt.name == "QuickEnemy") enemyMat = matt;
        }
    }
}
