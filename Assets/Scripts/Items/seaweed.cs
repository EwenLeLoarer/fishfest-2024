using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class seaweed : item
{

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("collide");
            if((float)other.gameObject.transform.position.z - deltaY >= minY)
            {

                other.gameObject.transform.position -= new Vector3(0,0,deltaY);
                GameManager.Instance.PlayAudio(6);
                Destroy(this.gameObject);
            }
            else{
                other.gameObject.GetComponent<Player>().UpdateHealth(other.gameObject.GetComponent<Player>().HealthPoint-1);
                Destroy(this.gameObject);
            }
                
        }
    }
}
