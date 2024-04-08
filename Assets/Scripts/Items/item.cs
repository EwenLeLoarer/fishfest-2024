using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class item : MonoBehaviour
{
    protected float minY = -8, maxY = 15, middleY = 3.5f, deltaY;
    // Start is called before the first frame update
    void Start()
    {
        deltaY = maxY - middleY;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.position -= new Vector3(0,0,0.4f);
        Destroy(this.gameObject, 15f);
    }
}
