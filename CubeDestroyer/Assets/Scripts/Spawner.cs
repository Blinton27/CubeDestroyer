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

    private List<GameObject> disabledCubePool = new List<GameObject>();
    [SerializeField] private int poolCount = 5; 
    
    private float time;
    void Start()
    {
        time = 0f;
        SpawnCubesForPool(poolCount);
    }

  
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timerToSpawnPrefab)
        {
            time = 0f;

            // Si j'ai pas de cube à spawn j'attends le prochain cycle
            if (disabledCubePool.Count == 0) return;

            // Sinon on récupère un cube de la pool (le premier de la liste)
            GameObject cubeToEnable = disabledCubePool[0];
            
            // On le place aléatoirement 
            cubeToEnable.transform.position = ComputeRandomPosition();
            
            // On le retire de la pool
            disabledCubePool.RemoveAt(0);
            
            // Et on l'active
            cubeToEnable.SetActive(true);
        }

    }

   
    void SpawnCubesForPool(int numberOfCubes)
    {
        // pour faire spawn 5 items 
        for (int i = 0; i < numberOfCubes; i++)
        {
            GameObject monObjet = SpawnCube();
            
            // Méthode 2 (voir PoolSignal.cs pour la méthode 1)
            monObjet.GetComponent<PoolSignal>().spawner = this;

            //on désactive l'objet
            monObjet.SetActive(false);
        }
    }

    private GameObject SpawnCube()
    {
        Vector3 worldPosition = ComputeRandomPosition();

        //Autre façon de faire
        //Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, positionZ));

        //on crée l'objet
        GameObject monObjet = Instantiate(cubePrefab, worldPosition, Quaternion.identity);
        return monObjet;
    }

    private Vector3 ComputeRandomPosition()
    {
        //l'endroit où on vas l'instancier donc on set up ses positions
        float positionY = Random.Range(0, Screen.height);
        float positionX = Random.Range(0, Screen.width);
        float positionZ = distanceFromCamToSpawn;

        // & ici on fais en sorte que ça spawn dans le champ vision de la caméra
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(positionX, positionY, positionZ));
        return worldPosition;
    }

    // Cette fonction est appelée par PoolSignal lorsque le cube est désactivé
    public void AddToPool(GameObject objectToAdd)
    {
        disabledCubePool.Add(objectToAdd);
    }
   
#endregion    
}
