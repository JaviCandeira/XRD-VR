using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.UI;
using TMPro;
public class Fruit : MonoBehaviour
{
    
    private Rigidbody _fruitRigidbody;
    private GameController _gameController;
    private FruitSpawner _fruitSpawner;
    private Rigidbody _rigidbody;
    public Material sliceMaterial;
    public LayerMask sliceMask;
    private bool isSliced = false;
    private Score score;
    public AudioSource collectSound;

    // Start is called before the first frame update
    void Start()
    {
        _fruitRigidbody = transform.GetComponent<Rigidbody>();
        _gameController = GameController.instance;
        _fruitSpawner = FruitSpawner.instance;
        _rigidbody = GetComponent<Rigidbody>();
        collectSound = FindObjectOfType<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Collider[] objectsToSlice = Physics.OverlapBox(transform.position, new Vector3(1f, 0.1f, 0.1f), transform.rotation, sliceMask);
            foreach (var fruitToBeSliced in objectsToSlice)
            {
                SlicedHull slicedFruit = SliceFruit(fruitToBeSliced.gameObject, sliceMaterial);
                isSliced = true;
                GameObject topFruit = slicedFruit.CreateUpperHull(fruitToBeSliced.GetComponent<Collider>().gameObject, sliceMaterial);
                GameObject bottomFruit = slicedFruit.CreateLowerHull(fruitToBeSliced.GetComponent<Collider>().gameObject, sliceMaterial);
                collectSound.Play();
                score.incrementScore();
                SliceEffect(topFruit);
                SliceEffect(bottomFruit);
                Destroy(fruitToBeSliced.gameObject);
                Destroy(topFruit, 1f);
                Destroy(bottomFruit, 1f);
            }
        }
    }
    public SlicedHull SliceFruit(GameObject fruitToSlice, Material material = null)
    {
        return fruitToSlice.Slice(gameObject.transform.position, gameObject.transform.up, material);
    }

    public void SliceEffect(GameObject fruitPart)
    {
        fruitPart.AddComponent<MeshCollider>().convex = true;
        fruitPart.AddComponent<Rigidbody>();
    }
}
