using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimientoEnemigo : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 1;
    public float movementSpeed= 4;
    public float rotationSpeed = 10f; // Velocidad de rotación
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement() {

        Vector3 direction = (waypoints[targetIndex].position - transform.position).normalized;

        //Rotar hacia la dirección del movimiento
        if(direction != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        //Moverse hacia el waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        
        if(distance <= 0.1f) {
            if(targetIndex >= waypoints.Count-1) {
                return;
            }
            targetIndex++;
        }
    }
}
