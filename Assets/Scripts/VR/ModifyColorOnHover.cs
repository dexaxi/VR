using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyColorOnHover : MonoBehaviour
{
    // Start is called before the first frame update  void SetRed()
   private void Start() {
       SetBlue();
   }
    public void    SetRed(){ GetComponent<MeshRenderer>().material.color = Color.red;}
   
    public void    SetBlue(){ GetComponent<MeshRenderer>().material.color = Color.blue;}


}
