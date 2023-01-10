using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    
    // static = partagé par toutes les instances cette classe
    // Tous les CubeMovers ont besoin de la même référence à la caméra
    static private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // En utilisant la physique
        // GetComponent<Rigidbody>().AddForce(-Camera.main.transform.forward * speed);
        
        // On va chercher la Camera uniquement si il n'y a pas de camera disponible
        if (!mainCamera)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // En utilisant une translation
        transform.Translate(-mainCamera.transform.forward * speed * Time.deltaTime);

        // On se place dans le référentiel de la caméra et on regarde si le z du cube dans ce référentiel est négatif
        // = le cube a dépassé la caméra
        if (mainCamera.transform.InverseTransformPoint(transform.position).z < -5f)
            gameObject.SetActive(false);
    }
}
