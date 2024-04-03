using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCurrent : item
{
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("collide");
            if((float)other.gameObject.transform.position.z + deltaY <= maxY)
            {

                other.gameObject.transform.position += new Vector3(0,0,deltaY);
                Destroy(this.gameObject);
            }
                
        }
    }
}
