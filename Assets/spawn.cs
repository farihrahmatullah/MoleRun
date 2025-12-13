using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] Kaktus; //buat array yang isinya banyak prefab rintangan
    public float kaktusrate = 2; //rata rata kaktus keluar
    private float timer = 0; //setting waktu jadi 0

    // Start is called before the first frame update
    void Start()
    {
        spawnkaktus();
    }

    // Update is called once per frame
    public void Update()
    {
            if (timer < kaktusrate){
            timer = timer + Time.deltaTime;
        } else {
            spawnkaktus();
            timer = 0;
        }
        

    }

    public void spawnkaktus(){
        
        //jika array kaktus kosong, mencegah terjadi error
        if (Kaktus == null || Kaktus.Length == 0)
    {
        return; // Hindari error dengan keluar dari fungsi
    }

        int randomIndex = Random.Range(0, Kaktus.Length); // Intinya Pilih kaktus secara acak wkwk
        Instantiate(Kaktus[randomIndex], transform.position, Quaternion.identity);

    }
    
}
