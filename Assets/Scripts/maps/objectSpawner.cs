using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> itemTemplate = new();
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(2f,10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
        }
        else{
            Instantiate(itemTemplate[Random.Range(0,itemTemplate.Count)],this.transform);
            timer = Random.Range(2f,10f);
            Debug.Log(timer);
        } 
    }

    
}
