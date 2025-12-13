using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public float speed = 3f; // Kecepatan scroll background
    public Transform cameraTransform; // Ambil Kamera utama
    private float width; // buat tempat simpen data lebar background

    void Start()
    {
         width = GetComponent<SpriteRenderer>().bounds.size.x; //ambil data lebar background dan disimpan di width
    }

    // Update is called once per frame
    void Update()
    {
        // Geser background ke kiri berdasarkan kecepatannya
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Jika background keluar dari layar, pindahkan ke kanan
        if (transform.position.x < cameraTransform.position.x - width)
        {
            transform.position += Vector3.right * width * 2;
        }
    }
}
