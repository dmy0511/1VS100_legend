using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense_Down : MonoBehaviour
{
    private com comScript;
    private user userScript;


    private bool isInsideBox = false;
    private bool BoxCenter = false;

    private float moveSpeed = 20f;
    public int aim_lv;
 
    private void Start()
    {
  
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
       
    }


void OnTriggerEnter2D(Collider2D other) 
    {
        isInsideBox=true;
  if(other.gameObject.name=="perfect_col"){
            aim_lv=1;
        }
        
        if(other.gameObject.name=="good_col"){
   aim_lv=2;
   
        }
        
        if(other.gameObject.name=="ok_col"){
   aim_lv=3;
    
        }
        
        if(other.gameObject.name=="fail_col"){
   aim_lv=4;
     
        }
    
       
          
    
}

void OnTriggerExit2D(Collider2D other) 
    {
      
        isInsideBox=false;
     if(other.gameObject.name=="perfect_col"){
            
        }else if(other.gameObject.name=="good_col_back"){

        }else if(other.gameObject.name=="ok_col_back"){

        }else if(other.gameObject.name=="fail_col_back"){

        }
}




    private void Update()
    {   if (GameObject.Find("Canvas").GetComponent<GameManager>().slow_lv)
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().move_speed = 4f;
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().move_speed+=0.00001f;
        }
       moveSpeed = GameObject.Find("Canvas").GetComponent<GameManager>().move_speed;
    
  Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;

           if (Input.GetKeyDown(KeyCode.DownArrow)==true&&isInsideBox==true) {
           Destroy(gameObject);
          comScript.Defense(0);
          if(aim_lv==1){
            
            GameObject.Find("Com").GetComponent<com>().pf_txt();
          
           }else if(aim_lv==2){
            
            GameObject.Find("Com").GetComponent<com>().good_txt();
             
           }else if(aim_lv==3){
            
            GameObject.Find("Com").GetComponent<com>().ok_txt();
         
           }else if(aim_lv==4){
            
            GameObject.Find("Com").GetComponent<com>().fail_txt();
           }
          
        }else if(isInsideBox==true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow))){
               userScript.DefenseFail(20f);
            Destroy(gameObject);
        }
           
    }
}
