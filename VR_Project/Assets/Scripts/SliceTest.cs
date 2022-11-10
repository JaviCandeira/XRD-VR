using System.Collections;
using System.Collections.Generic;
using EzySlice;
using UnityEngine;

public class SliceTest : MonoBehaviour
{
    public Material materialAfterSlice;
    public LayerMask sliceMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Collider[] objectsToSlice = Physics.OverlapBox(
                transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            foreach (var toSlice in objectsToSlice)
            {
                //Slice the main object
                SlicedHull slicedObject = SliceObject(toSlice.GetComponent<Collider>().gameObject, materialAfterSlice);
                
                //Create the upper part of the Slice
                GameObject upperHullGameObject =
                    slicedObject.CreateUpperHull(toSlice.GetComponent<Collider>().gameObject, materialAfterSlice);
                
                //Create the upper part of the Slice
                GameObject lowerHullGameObject =
                    slicedObject.CreateLowerHull(toSlice.GetComponent<Collider>().gameObject, materialAfterSlice);
                
                MakeItPhysical(lowerHullGameObject);
                MakeItPhysical(upperHullGameObject);
                
                //Destroys the main object
                
            }
        }
    }


    private SlicedHull SliceObject(GameObject gameObject, Material crossSectionMaterial = null)
    {
        return gameObject.Slice(transform.position, transform.up, crossSectionMaterial);
    }

    private void MakeItPhysical(GameObject gameObject, Material crossSectionMaterial = null)
    {
        gameObject.AddComponent<MeshCollider>().convex = true;
        gameObject.AddComponent<Rigidbody>();
    }
}
