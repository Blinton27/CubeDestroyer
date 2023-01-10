using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    
    void Start()
    {
        gameObject.SetActive(true);
    }

    
    void Update()
    {
        
    }

    //gameObject est l'objet sur lequel on est
    //GameObject est la classe...
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
