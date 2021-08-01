using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;
    float rotationY = 0;

    void Update() {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        rotationY += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);

        // Shoot object
        if (Input.GetMouseButtonDown(0)) {            
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log("Did Hit " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.CompareTag("Enemy")) {
                    hit.transform.gameObject.GetComponent<Enemy>().CustomDestroy();
                }
            }
        }
    }
}
