using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaktusScript : MonoBehaviour
{
    public float KecepatanKaktus = 3; //Tentukan kecepatan kaktusnya
    private float Zonamati = -12 ; //zona kaktus bakal hilang atau hancur
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         transform.position = transform.position + Vector3.left * KecepatanKaktus * Time.deltaTime;
         //jika posisi x dari kaktus kurang dari zona mati, maka kaktus bakal hancur
         if(transform.position.x < Zonamati){
             Destroy(gameObject);
         }
        
    }
}
