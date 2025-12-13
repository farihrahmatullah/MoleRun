using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Karakter : MonoBehaviour
{
    public Rigidbody2D Rigibodysaya; //ambil rigibody dari karakternya
    public float Loncat; //menyimpan seberapa cepat dan tinngi lompatannya
    private int MaxLoncat = 0; //seberapa banyak bisa lompat
    public float Nyelem; //menyimpan seberapa cepat dan tinggi terjunnya
    public GameObject Tanah1; //ambil game object tanah di unity
    public GameObject Tanah2; //ambil game object tanah di unity
    private BoxCollider2D fisiktanah1; //ambil boxcollider dari tanah di unity disimpan di variable fisik tanah
    private BoxCollider2D fisiktanah2; //ambil boxcollider dari tanah di unity disimpan di variable fisik tanah
    public LogikaScript logika; //ambil script logikaScript dan disimpan di variable logika

    public bool karakterhidup; //boolean apakah karakter hidup atau tidak
    public Text angkasisa; //ambil gameobject text angkasisa di unity 
    private int batasditanah = 10; //seberapa lama waktu yang dibolehkan didalam tanah
    private float waktutersisa; //waktu tersisa didalam tanah saat ini

    private Animator anim; // mengambil animasi dan disimpan di variable animasi
    

    // Start is called before the first frame update
    void Start()
    {
        logika = GameObject.FindGameObjectWithTag("Logika").GetComponent<LogikaScript>(); //ambil script logikaScript dan disimpan di variable logika
        fisiktanah1 = Tanah1.GetComponent<BoxCollider2D>(); //ambil boxcollider dari tanah di unity disimpan di variable fisik tanah
        fisiktanah2 = Tanah2.GetComponent<BoxCollider2D>(); //ambil boxcollider dari tanah di unity disimpan di variable fisik tanah
        anim = GetComponent<Animator>(); // mengambil animasi dan disimpan di variable animasi
        waktutersisa = batasditanah; //mengatur waktuditanah sama nilainya dengan batasditanah yaitu 10

    }

    // Update is called once per frame
    void Update()
    {
        //jika pemain menekan W dan maxloncatnya kurang dari 2 dan karakter hidup, maka ....
        if (Input.GetKeyDown(KeyCode.W) && MaxLoncat < 2 && karakterhidup){
            //karakter bisa loncat, dengan mengatur vector2.up dan dikali kekuatan loncat
            Rigibodysaya.velocity = Vector2.up * Loncat;
            //maxloncat nya ditambah 1
            MaxLoncat++;
            //fungsi atau method TanahHidup akan berjalan setelah 0.7 detik
            Invoke("TanahHidup", 0.7f);
            //menjalankan animasi isloncat
            anim.SetBool("IsLoncat", true);
    

        }
        //jika pemain menekan S dan karakter hidup, maka ....
         if (Input.GetKeyDown(KeyCode.S ) && karakterhidup){
            //karakter bisa Terjun, dengan mengatur vector2.down dan dikali kekuatan Terjun
            Rigibodysaya.velocity = Vector2.down * Nyelem;
            //boxcollider dari tanah di unity menjadi false atau tidak ada
            fisiktanah1.enabled = false;
            fisiktanah2.enabled = false;
            //menjalankan animasi Isnyelem
            anim.SetBool("IsNyelem", true);
        }

        //jika posisi y dari karakter kurang dari -1.40 dan karakterhidup maka ....
        if(transform.position.y < -1.40 && karakterhidup){
            //waktu ditadah dikurang 1 tiap detik
            waktutersisa -= Time.deltaTime;
            angkasisa.text = waktutersisa.ToString("F0");//membuat angka float menjadi string dan menjadi bilangan bulat
        }
        //jika posisi y dari karakter lebih dari -1.40 dan karakterhidup maka ....
        if(transform.position.y > -1.40 && karakterhidup){
            //waktu ditanah ditambah 1 tiap detik
            waktutersisa += Time.deltaTime;
            angkasisa.text = waktutersisa.ToString("F0");
            //jika waktu sisa ditanah lebih dari batas ditanah yaitu 10 maka ....
            if(waktutersisa > batasditanah){
                //waktu ditanah diberhentikan dan disamakan dengan batas ditanah
                waktutersisa = batasditanah;
            }
        }

        //jika waktu ditanah kurang dari sama dengan 0 maka karakterr mati dan menjalankan method gameover di script logika
        if(waktutersisa <= 0){
            karakterhidup = false;
            logika.gameover();
        }

    }
        //membuat fungsi ketika karakter bertabrakan dengan sesuatu    
        public void OnCollisionEnter2D(Collision2D collision)
    {
        //jika bertabrakan dengan gameobject dengan tag "ground" maka...
        if (collision.gameObject.CompareTag("Ground"))
        {
            //maxloncat jadi 0
            MaxLoncat = 0;
            //animasi loncat dan nyelem jadi false ( menjalankan animasi default )
            anim.SetBool("IsLoncat", false);
            anim.SetBool("IsNyelem", false);
        }
        //jika bertabrakan dengan gameobject dengan tag "Rintangan" maka...
        if (collision.gameObject.CompareTag("Rintangan")){
            //method game over berjalan
            logika.gameover();
            //karakter mati
            karakterhidup = false;
        }
    }


    void TanahHidup(){
        if(transform.position.y > -1.30){
             //boxcollider dari tanah di unity menjadi false atau tidak ada
            fisiktanah1.enabled = true;
            fisiktanah2.enabled = true;
        }

        else{
            //fungsi atau method TanahHidup akan berjalan setelah 0.7 detik
            Invoke("TanahHidup", 0.7f);
        
        }
    
    }
}
