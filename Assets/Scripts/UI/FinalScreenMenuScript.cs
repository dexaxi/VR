using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalScreenMenuScript : MonoBehaviour
{
  public void Retry(){
    
      SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);
      SceneManager.LoadScene(2);
      

  }

  public void Quit()
  {
      SoundManager.PlaySound(SoundManager.Sound.MENUPOP,0.3f);
      SceneManager.LoadScene(1);

  }

}
