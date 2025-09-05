using UnityEngine;

public class SpawnerObjetos : MonoBehaviour
{
    public GameObject objetoPrefab;     
    public float tiempoEntreSpawn = 3f; 
    public float tiempoVida = 5f;       
    public float separacion = 2f;       
    public float rangoHorizontal = 10f; 
    public Transform piso;              

    private float timer;
    private float ultimaX = Mathf.NegativeInfinity; 

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnObjeto();
            timer = tiempoEntreSpawn;
        }
    }

    void SpawnObjeto()
    {
        float posX;

      
        do
        {
            posX = transform.position.x + Random.Range(-rangoHorizontal, rangoHorizontal);
        }
        while (Mathf.Abs(posX - ultimaX) < separacion);

       
        ultimaX = posX;

        
        Vector3 spawnPos = new Vector3(posX, piso.position.y - 0.5f, 0);


       
        GameObject obj = Instantiate(objetoPrefab, spawnPos, Quaternion.identity);

        
        Destroy(obj, tiempoVida);
    }
}

