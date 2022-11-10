using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public static FruitSpawner instance;

    public List<GameObject> fruitPrefabs;
    public List<GameObject> usedFruits = new List<GameObject>();
    public List<GameObject> unusedFruit = new List<GameObject>();

    public Transform spawnPoints;
    List<Vector3> spawnPointList = new List<Vector3>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FirstSpawn();
        StartGameSpawner(1f);
    }

    void FirstSpawn()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            spawnPointList.Add(spawnPoint.localPosition);
        }

        foreach (GameObject fruit in fruitPrefabs)
        {
            for (var i = 0; i < 10; i++)
            {
                GameObject fruitObject = Instantiate(fruit, Vector3.zero, Quaternion.identity, transform);
                fruitObject.SetActive(false);
                unusedFruit.Add(fruitObject);
            }
        }
    }

    public void SpawnFruit()
    {
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            if (unusedFruit.Count > 0 || usedFruits.Count < 15)
            {
                Vector3 randPos = spawnPointList[Random.Range(0, spawnPointList.Count)];
                GameObject ranFruit = unusedFruit[Random.Range(0, unusedFruit.Count)];

                ranFruit.transform.localPosition = randPos;
                AddSpecialForce(ranFruit);
                usedFruits.Add(ranFruit);
                unusedFruit.Remove(ranFruit);
            }
        }
    }

    void AddSpecialForce(GameObject gameObject)
    {
        gameObject.SetActive(true);
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.AddForce(gameObject.transform.up * (Random.Range(270, 330) * (1f / Time.timeScale)));
        rigidBody.AddForce(gameObject.transform.forward * (Random.Range(-20, -40) * (1f / Time.timeScale)));
        rigidBody.AddForce(gameObject.transform.right * (Random.Range(-30, 30) * (1f / Time.timeScale)));
    }
    private void StartGameSpawner(float start)
    {
        InvokeRepeating(nameof(SpawnFruit), start, 1.5f);
    }

    private void ResetPool()
    {
        CancelInvoke(nameof(SpawnFruit));

        foreach (var fruitObj in usedFruits.ToArray())
        {
            var fruit = fruitObj.GetComponent<Fruit>();
            RecycleFruit(fruit);
        }
    }

    public void RecycleFruit(Fruit fruit)
    {
        usedFruits.Remove(fruit.gameObject);
        unusedFruit.Add(fruit.gameObject);
    }
}
