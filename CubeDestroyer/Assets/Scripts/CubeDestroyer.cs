using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{

    //gameObject est l'objet sur lequel on est
    //GameObject est la classe...
    void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
