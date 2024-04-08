using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public AudioSource source;
    public AudioClip[] audioClips;
    public GameObject musicJam;
    private static GameManager instance;
    public static GameManager Instance {get; private set;}
    [SerializeField] private TextMeshProUGUI scoreUi;

    private void Start(){
        if (instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
        changeTimeScale(1);
    }

    public void FixedUpdate(){
        score = (int)Time.time * 15;
        scoreUi.text = "Score : " + score.ToString();
    }

    public void retry(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void changeTimeScale(int timescale){
        Time.timeScale = timescale;
    }


    public void PlayAudio(int id){
        source.PlayOneShot(audioClips[id]);
    }

    public void PlayMusic(){
        musicJam.SetActive(true);
    }
    public void StopMusic(){
        musicJam.SetActive(false);
    }
}
