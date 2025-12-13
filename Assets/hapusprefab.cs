using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class hapusprefab : MonoBehaviour
{
    private float kecepatanprefab = 1; //Tentukan kecepatan prefabnya
    private float Zonamati = -12 ; //zona prefab bakal hilang atau hancur

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = transform.position + Vector3.left * kecepatanprefab * Time.deltaTime;
         //jika posisi x dari prefab kurang dari zona mati, maka prefab bakal hancur
         if(transform.position.x < Zonamati){
             Destroy(gameObject);
         }
        
    }
}
