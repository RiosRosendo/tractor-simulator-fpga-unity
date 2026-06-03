using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform carTransform; // Referencia al transform del coche que la cámara seguirá
    [Range(1, 10)]
    public float followSpeed = 2; // Velocidad de seguimiento de la cámara
    [Range(1, 10)]
    public float lookSpeed = 5; // Velocidad de rotación de la cámara para mirar al coche
    Vector3 initialCameraPosition; // Posición inicial de la cámara
    Vector3 initialCarPosition; // Posición inicial del coche
    Vector3 absoluteInitCameraPosition; // Posición inicial absoluta de la cámara con respecto al coche

    void Start(){
        initialCameraPosition = gameObject.transform.position; // Establece la posición inicial de la cámara
        initialCarPosition = carTransform.position; // Establece la posición inicial del coche
        absoluteInitCameraPosition = initialCameraPosition - initialCarPosition; // Calcula la posición inicial absoluta de la cámara
    }

    void FixedUpdate()
    {
        // Rotar para mirar al coche
        Vector3 _lookDirection = (new Vector3(carTransform.position.x, carTransform.position.y, carTransform.position.z)) - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

        // Mover hacia el coche
        Vector3 _targetPos = absoluteInitCameraPosition + carTransform.transform.position;
        transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }
}
