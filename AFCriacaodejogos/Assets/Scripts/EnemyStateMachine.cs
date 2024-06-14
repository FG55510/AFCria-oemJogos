using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    Seek,
    Wander,
    Flee
}
public class EnemyStateMachine : MonoBehaviour
{

    public GameObject player;
    public float distance;

    public float timetostay = 3f;
    private float time = 3f;


    public Seek seek;
    public Flee flee;
    public Stop stop;

    public EnemyState state;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        time = timetostay;
        state = EnemyState.Wander;
        ChangeState(state);
        seek = GetComponent<Seek>();
        flee = GetComponent<Flee>();
        stop = GetComponent<Stop>();

        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        switch (state)
        {
            case EnemyState.Wander:
                if (distance < 5)
                {
                    ChangeState(EnemyState.Seek);
                }
                break;


            case EnemyState.Seek:
                if (distance > 5)
                {
                    ChangeState(EnemyState.Wander);
                }

                break ;


            case EnemyState.Flee:
                time -= Time.deltaTime;
                if (time <= 0) {
                    ChangeState(EnemyState.Wander);
                }
                break;

        }
    }

    public void ResetAll()
    {
        seek.enabled = false;
        flee.enabled = false;
        stop.enabled = false;

    }

    public void ChangeState(EnemyState estado)
    {
        ResetAll();

        switch (estado)
        {
            case EnemyState.Wander:
                sr.color = Color.white;
                stop.enabled = true;
                break;

            case EnemyState.Seek:
                seek.enabled = true;
                sr.color = Color.red;
                break;
            case EnemyState.Flee:
                sr.color = Color.green;
                flee.enabled = true;
                break;
        }

        state = estado;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetLife(-1);
        }
    }
}
