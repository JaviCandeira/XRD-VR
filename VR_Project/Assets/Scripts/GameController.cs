using System;
using System.Collections.Generic;
using EzySlice;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool isTouched = false;
    private FruitSpawner _spawner;

    public Material sliceMaterial;
    public LayerMask sliceMask;


    public List<string> countdownElementsList;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }




    private void Start()
    {
        _spawner = FruitSpawner.instance;

        //TODO: UI, sound, countdown text
    }
    private void Update()
    {

    }

}
