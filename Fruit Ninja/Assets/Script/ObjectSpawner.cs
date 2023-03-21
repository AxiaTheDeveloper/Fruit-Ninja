using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner Instance{get; private set;}
    private Collider2D spawnArea;

    [SerializeField]private FruitsSpawnScriptableObject objectSpawnSO;

    [SerializeField]private GameObject bombPrefab;
    [SerializeField]private float bombSpawnChance;
    private float bombChance;
    [SerializeField]private float bombGachaUpRate;

    //delay spawn
    [SerializeField]private float spawnDelayMin, spawnDelayMax;

    //angle spawn
    [SerializeField]private float spawnAngleMin, spawnAngleMax;

    //force abis spawn
    [SerializeField]private float spawnForceMin, spawnForceMax;

    [SerializeField]private float objectLifeTime;

    [SerializeField]private float spawnWaitBeforeStartGame;
    private void Awake() {
        spawnArea = GetComponent<Collider2D>();
        Instance = this;
    }

    //courotineeee time
    private void OnEnable() {
        bombChance = bombSpawnChance;
        StartCoroutine(ObjectSpawn());
    }   

    private void OnDisable() {
        StopAllCoroutines();
    }

    private IEnumerator ObjectSpawn(){
        yield return new WaitForSeconds(spawnWaitBeforeStartGame);

        while(enabled){

            GameObject objectPrefab = objectSpawnSO.fruitSpawnPrefabArray[Random.Range(0,objectSpawnSO.fruitSpawnPrefabArray.Length)];

            if(bombChance >= Random.value){
                objectPrefab = bombPrefab;
                bombChance = bombSpawnChance;
            }
            else{
                int x = Random.Range(0,2);
                if(x == 0){
                    bombChance += bombGachaUpRate;
                }
                else if(x == 2 && bombChance > bombGachaUpRate){
                    bombChance -= bombGachaUpRate;
                }
                
            }

            //tmpt spawn
            Vector2 positionFruit = new Vector3();
            positionFruit.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            positionFruit.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

            Quaternion rotationFruit = Quaternion.Euler(0, 0, Random.Range(spawnAngleMin,spawnAngleMax));

            GameObject fruit = Instantiate(objectPrefab, positionFruit, rotationFruit);

            Destroy(fruit, objectLifeTime);

            //gausa dipisah karena langsung saja spawner yang mengatur forcenya daripada tiap fruit mengatur forcenya sendiri sendiri jadi berat karena fruit yang dikeluarkan banyak di saat yang sama

            fruit.GetComponent<Rigidbody2D>().AddForce(fruit.transform.up * (Random.Range(spawnForceMin,spawnForceMax)), ForceMode2D.Impulse);

            //impulse biar ke force 1 kali aja
            
            yield return new WaitForSeconds(Random.Range(spawnDelayMin,spawnDelayMax));
        }
    }

}
