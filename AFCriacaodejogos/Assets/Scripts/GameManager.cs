using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SO_GameData gameData;
    public static UIManager ui;
    public GameObject player;
    public NextFase ff;
    

    public int score;
    public int life;

    public EnemyStateMachine[] enemyStates;

    void Awake () {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadScene(string Fase){
        SceneManager.LoadScene(Fase);
    }
    // Start is called before the first frame update
    void Start()
    {
        ui = FindAnyObjectByType<UIManager>();
        score = gameData.score;
        life = gameData.life;
        ui.ChangeScore(score);
        ui.ChangeLife(life);
        ff.enabled = false;
    }

    public void SetScore(int value){

        gameData.score += value;
        score = gameData.score;
        ui.ChangeScore(score);
    }

    public void SetLife(int value){
        gameData.life += value;
        life = gameData.life;
        ui.ChangeLife(life);
        if(life<=0){
            player.GetComponent<Player>().enabled = false;
           Teste ta = player.GetComponent<Teste>();
            ta.Death();
            Lose();

        }
    }

    public void Lose(){
        ui.GameOver();
    }

    public void Victory(){
        ui.Win();
    }
    
    public void EnemyFlee()
    {
       foreach (EnemyStateMachine esm in enemyStates)
        {
            esm.ChangeState(EnemyState.Flee);
        } 
    }

    public void GetKey()
    {
        ui.ChavePega();
        ff.enabled = true;
    }
}
