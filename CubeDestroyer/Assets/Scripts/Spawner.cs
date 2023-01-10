using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Step 1 
     // Coder un script Spawner simple faisant apparaître un cube toutes les 3 secondes
    // aléatoirement devant à la caméra
    // ○ Les cube doivent apparaître à une distance fixe de la caméra mais à des
    // positions x,y aléatoires 
    // ○ Tous les cubes doivent apparaître dans le champ de vision de l’utilisateur !
    // ○ vitesse et distance d’apparition réglable dans l’éditeur bien entendu
    #endregion
    #region My Attempt With RAOUCH <3
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float timerToSpawnPrefab = 1f;
    [SerializeField] private float distanceFromCamToSpawn = 30f; 

    private List<GameObject> _myGameObjectList = new List<GameObject>();
    
    void Start()
    {
        SpawnCube();
    }

    
    
    
    
    bool isPressed =false;
   
   
   
   
    void Update()
    {
       if (Input.GetKey("space") && !isPressed)
       {
            isPressed= true;
            FindingMyInstantiatedObjectsToActivateThem();
       }
    }

   
    void SpawnCube()
    {
        // pour faire spawn 5 items 
        for (int i = 0; i < 5; i++)
        {
            //l'endroit où on vas l'instancier donc on set up ses positions
            float positionY = Random.Range(0,Screen.height);
            float positionX = Random.Range(0, Screen.width);
            float positionZ = Random.Range(0, distanceFromCamToSpawn);
            
            // & ici on fais en sorte que ça spawn dans le champ vision de la caméra
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(positionX, positionY, positionZ));

            //on crée l'objet
            GameObject monObjet = Instantiate(cubePrefab, worldPosition, Quaternion.identity);
            //on désactive l'objet
            monObjet.SetActive(false);

            //on ajoute nos objets à la liste
            _myGameObjectList.Add(monObjet);
        }
    }

    private void FindingMyInstantiatedObjectsToActivateThem()
    {
        foreach (GameObject item in _myGameObjectList)
        {
            item.SetActive(true);
            float speed = Random.Range(10,50);
            //on vas déplacer les objets vers la cam avec le AddForce
            item.GetComponent<Rigidbody>().AddForce(-Camera.main.transform.forward * speed);

            //On peux faire la même chose avec la velocity
            //item.GetComponent<Rigidbody>().velocity = -Camera.main.transform.forward * speed;
        }
    }

   
#endregion    
}
