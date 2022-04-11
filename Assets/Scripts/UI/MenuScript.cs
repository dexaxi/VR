using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    public Button[] menubuttons = new Button[4];
    public Button[] difficultyButtons  = new Button[3];
    DifficultyScript settings;
    private void Start() {
        settings = FindObjectOfType<DifficultyScript>();
        foreach(Button b in difficultyButtons){
            b.gameObject.SetActive(false);}
    }
   
   public void PlayButton(){
    SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);
       SceneManager.LoadScene(2);

   }

   public void QuitButton(){
SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);
       Application.Quit();
   }

   public void TutorialButton(){
SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);
       SceneManager.LoadScene(4);

   }

   public void DifficultyButton(){
SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);
       foreach(Button b in menubuttons){  b.gameObject.SetActive(false);}
       foreach(Button b in difficultyButtons){  b.gameObject.SetActive(true);}

       

   }

   public void HideDif(){
       foreach(Button b in menubuttons){  b.gameObject.SetActive(true);}
       foreach(Button b in difficultyButtons){  b.gameObject.SetActive(false);}


   }

      public void SetHard(){SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);settings.difficulty = 2;
        HideDif();
}
    public void SetEasy(){SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);settings.difficulty = 0;HideDif();}
    public void SetNormal(){SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);settings.difficulty = 1;
    HideDif();}
}
