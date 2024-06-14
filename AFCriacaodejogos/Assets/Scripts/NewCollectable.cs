using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Tipocoletavel 
{
    Key,
    Score,
    Powerup
}
public class NewCollectable : MonoBehaviour
{

    public Tipocoletavel tipo;
    public int value=1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (tipo){
                        case Tipocoletavel.Key:
                          GameManager.Instance.GetKey();
                            break;
                        case Tipocoletavel.Score:
                            GameManager.Instance.SetScore(value);
                            break;
                        case Tipocoletavel.Powerup:
                            GameManager.Instance.EnemyFlee();
                            break;
                
                        }
            Destroy(gameObject);

        }
        
    }
}
