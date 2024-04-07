using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roch : item
{
    // Start is called before the first frame update
   private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("collide");
            other.gameObject.GetComponent<Player>().UpdateHealth(other.gameObject.GetComponent<Player>().HealthPoint-1);
            if((float)other.gameObject.transform.position.z - deltaY >= minY)
            {

                other.gameObject.transform.position -= new Vector3(0,0,deltaY);
                Destroy(this.gameObject);
            }
            else{
                other.gameObject.GetComponent<Player>().UpdateHealth(other.gameObject.GetComponent<Player>().HealthPoint-1);
                Destroy(this.gameObject);
            }
                
        }
    }
}
