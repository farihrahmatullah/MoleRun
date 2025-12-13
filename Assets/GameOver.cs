using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ambil unity ui sama scenemanagement

public class GameOver : MonoBehaviour
{
    // fungsi atau method ulang yang bakal ditaroh di button ulang. fungsinya untuk memulai kembali scene
    public void Ulang(){
    SceneManager.LoadScene("SampleScene");
   }

    // fungsi atau method keluar yang bakal ditaroh di button keluar. fungsinya untuk keluar dari game
    //dan bakal berpindah ke scene main menu
   public void Keluar(){
    SceneManager.LoadScene("MaenMenu");
   }
}
