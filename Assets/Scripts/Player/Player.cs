using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    private Vector2 playerPos;

    private float minX = -15, maxX = 15, middleX = 0, middleY = 3.5f, deltaX;
    public int HealthPoint;
    public TextMeshProUGUI healthPointsText;
    private string healthText = "Health Points : ";
    private InputPlayer input;
#region Singleton
    private static Player _instance;
    public static Player Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
    }
    #endregion
    void Start()
    {
        input = new InputPlayer();
        transform.position = new Vector3(middleX,transform.position.y, middleY);
        input.Move.Enable();
        deltaX = maxX - middleX;
        healthPointsText.text = healthText + HealthPoint.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        input.Move.left.started += playerLeft;
        input.Move.right.started += playerRight;
        input.Move.jump.started += playerJump;
    }

    private void playerRight(InputAction.CallbackContext context)
    {
        Debug.Log("right");
        if(transform.position.x + deltaX <= maxX)
            transform.position += new Vector3(deltaX, 0, 0);
    }

    private void playerLeft(InputAction.CallbackContext context)
    {
        Debug.Log("left");
        if(transform.position.x - deltaX >= minX)
            transform.position -= new Vector3(deltaX, 0, 0);
    }

    private void playerJump(InputAction.CallbackContext context){
        Debug.Log("jump");
        //
    }

    public void UpdateHealth(int newHealth){
        if(newHealth <= 0){
            healthPointsText.text = "you're dead bro!";
            Destroy(this.gameObject);
            input.Move.Disable();
            return;
        }
            
        HealthPoint = newHealth;
        healthPointsText.text = healthText + HealthPoint.ToString();
    }
}
