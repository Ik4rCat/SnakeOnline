using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FoodSpawner : NetworkBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] float xSize = 8f, zSize = 8f;

    public override void OnStartServer()
    {
        SpawnFood();
        Food.ServerFoodEaten += SpawnFood;
    }
    public override void OnStopServer()
    {
        Food.ServerFoodEaten -= SpawnFood;
    }

    [Server]
    private  void SpawnFood()
    {
        Vector3 pos = new Vector3(
            Random.Range(-xSize, xSize),
            foodPrefab.transform.position.y,
            Random.Range(-zSize, zSize));
        GameObject food =  Instantiate(foodPrefab, pos, foodPrefab.transform.rotation);
        NetworkServer.Spawn(food);
    }
}
