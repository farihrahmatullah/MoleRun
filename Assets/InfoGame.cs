using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoGame : MonoBehaviour
{
    public GameObject UiCaraBermain; //ambil gameobject uicarabermain
    void Start(){
        //ketika mulai uicarabermain disetting menjadi false
        UiCaraBermain.SetActive(false);
    }
    public void Nyala(){
         // ketika fungsi Nyala di pencet maka uicarabermain akan nyala, dan jika nyala maka akan mati. 
         // seperti tombol on off
        UiCaraBermain.SetActive(!UiCaraBermain.activeSelf);
    }
}
