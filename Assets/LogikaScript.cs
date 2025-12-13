using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogikaScript : MonoBehaviour
{
   public int PlayerScore; //score dari player
   public Text scoretext; // ambil gameobject text di unity dan diberi nama scoretext
   public float KecScore = 1; //kecepatan bertambahnya scoore
   private float waktuBerlalu = 0f; // Untuk menghitung waktu yang sudah berlalu
   public GameObject gameoverscreen; //ambil gameobject game over screen di unity
   public bool karakternabrak = false; //boolean untuk mengetahui apakah karakter nabrak apa enggak

   void Start(){
      //setting game over screen nya false agar tidak tampil saat game mulai
      gameoverscreen.SetActive(false);
   }

      public void Update(){
    // Tambah waktu yang sudah berlalu berdasarkan detik di realtime
       waktuBerlalu += Time.deltaTime;

        // Jika sudah 1 detik dan karakter tidak nabrak, maka tambahkan skor
        if (waktuBerlalu >= 1f && !karakternabrak)
        {
            PlayerScore += Mathf.FloorToInt(KecScore);
            scoretext.text = PlayerScore.ToString(); //mengubah yang tadinya int menjadi string dan disimpan di scoretext
            waktuBerlalu = 0f; // Reset waktu
        }
       
   }

   public void gameover(){
      //method game over dan yang terjadi layar akan ada tampilan game over serta mengubah boolean karakternabrak menjadi true
     gameoverscreen.SetActive(true);
     karakternabrak = true;
   }

}
