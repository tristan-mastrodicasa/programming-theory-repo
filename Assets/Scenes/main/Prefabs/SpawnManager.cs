using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject quickEnemy;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 1.0f);
        InvokeRepeating("SpawnQuickEnemy", 2.0f, 5.0f);
    }

    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    void OnDrawGizmos() {
        Color red = new Color(255, 0, 0, 1);
        Gizmos.color= red;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    void SpawnEnemy() {
        Instantiate(enemy, RandomPointInBounds(GetComponent<BoxCollider>().bounds), enemy.transform.rotation);
    }

    void SpawnQuickEnemy() {
        Instantiate(quickEnemy, RandomPointInBounds(GetComponent<BoxCollider>().bounds), quickEnemy.transform.rotation);
    }
}
