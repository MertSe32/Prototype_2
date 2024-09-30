using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    //Üst taraftaki spawn değişkenleri
    private float spawnRangeXUp = 17;
    private float spawnPosZUp = 20;

    //Sol taraftaki spawn değişkenleri
    private float spawnRangeXLeft = -24.0f;
    private float spawnRangeZLeftMin = 1.0f;
    private float spawnRangeZLeftMax = 14.0f;

    //Sağ taraftaki spawn değişkenleri
    private float spawnRangeXRight = 24.0f;
    private float spawnRangeZRightMin = 1.0f;
    private float spawnRangeZRightMax = 14.0f;


    //Spawnlanma zamanlamaları
    private float startDelay = 2.0f;
    private float spawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Spawnlanma fonksiyonlarına başla komutunun verildiği yer.
        InvokeRepeating("SpawnRandomAnimalUp", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Üst taraftan hayvan spawnlama 
    void SpawnRandomAnimalUp()
    {
        //Rastgele hayvan seçmek için değişken
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Üst taraf için spawnlanma koordinatları
        Vector3 spawnPosUp = new Vector3(Random.Range(-spawnRangeXUp, spawnRangeXUp), 0, spawnPosZUp);

        //Sağ taraf için spawnlanma fonksiyonu
        Instantiate(animalPrefabs[animalIndex], spawnPosUp, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        //Rastgele hayvan seçmek için değişken
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Sol taraf için spawnlanma koordinatları
        Vector3 spawnPosLeft = new Vector3(spawnRangeXLeft, 0, Random.Range(spawnRangeZLeftMin, spawnRangeZLeftMax));

        //Hayvanların oyun ekranının dışında koşmaması için döndürme değişkeni
        Quaternion rotationLeft = Quaternion.Euler(0, 90, 0);

        //Sol taraf için spawnlanma fonksiyonu
        Instantiate(animalPrefabs[animalIndex], spawnPosLeft, rotationLeft);
    }

    void SpawnRandomAnimalRight()
    {
        //Rastgele hayvan seçmek için değişken
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Sağ taraf için spawnlanma koordinatları
        Vector3 spawnPosRight = new Vector3(spawnRangeXRight, 0, Random.Range(spawnRangeZRightMin, spawnRangeZRightMax));

        //Hayvanların oyun ekranının dışında koşmaması için döndürme değişkeni
        Quaternion rotationRight = Quaternion.Euler(0, -90, 0);

        //Sağ taraf için spawnlanma fonksiyonu
        Instantiate(animalPrefabs[animalIndex], spawnPosRight, rotationRight);
    }
}
//```