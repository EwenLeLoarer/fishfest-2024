using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
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
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
#region Singleton
    private static Player _instance;
    public bool _isMoving = false;
    private Vector3 destination;
    public static Player Instance { get => _instance; }

    [SerializeField] private GameObject retry;

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
    void FixedUpdate()
    {
        input.Move.left.started += playerLeft;
        input.Move.right.started += playerRight;
        input.Move.jump.started += playerJump;
        if(_isMoving){
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.3f);
            Debug.Log(transform.position + " + " + destination);    
            if(Vector3.Distance(transform.position, destination) < 0.05){
                _isMoving = false;
                transform.position = destination;  
            }
                
                
        }

    }

    private void playerRight(InputAction.CallbackContext context)
    {
        Debug.Log("right");
        if(transform.position.x + deltaX <= maxX && _isMoving == false)
        {
            destination = transform.position + new Vector3(deltaX,0,0);
            _isMoving = true;
            GameManager.Instance.PlayAudio(1);
        }
            //Vector3.Lerp(transform.position, transform.position + new Vector3(deltaX,0,0), 0.5f);

            //transform.position += new Vector3(deltaX, 0, 0);
    }

    private void playerLeft(InputAction.CallbackContext context)
    {
        Debug.Log("left");
        if(transform.position.x - deltaX >= minX && _isMoving == false)
        {
            destination = transform.position - new Vector3(deltaX,0,0);
            _isMoving = true;
            GameManager.Instance.PlayAudio(1);
        }
            //transform.position = Vector3.SmoothDamp(transform.position, transform.position - new Vector3(deltaX,0,0), ref velocity, smoothTime );

            //transform.position -= new Vector3(deltaX, 0, 0);
            
    }

    private void playerJump(InputAction.CallbackContext context){
        Debug.Log("jump");
        //
    }

    public void UpdateHealth(int newHealth){
        if(newHealth <= 0){
            healthPointsText.text = "you're dead bro!";
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
            Destroy(this.gameObject);
            input.Move.Disable();
            retry.SetActive(true);
            GameManager.Instance.PlayAudio(3);
            GameManager.Instance.StopMusic();
            return;
        }
        GameManager.Instance.PlayAudio(4);
        HealthPoint = newHealth;
        healthPointsText.text = healthText + HealthPoint.ToString();
    }
}
