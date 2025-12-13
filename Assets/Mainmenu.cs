using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void Gaskeun(){
    // fungsi atau method Gaskeun yang bakal ditaroh di button Gaskeun. fungsinya untuk memulai scene permainannya
    SceneManager.LoadScene("SampleScene");
   }

   public void Keluar(){
    // fungsi atau method Keluar yang bakal ditaroh di button Keluar. fungsinya ketika button di tekan maka game akan keluar.
    //Cara membuat tombol keluar aplikasi.
    Application.Quit();
   }
}
