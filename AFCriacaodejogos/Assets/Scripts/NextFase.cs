using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFase : MonoBehaviour
{
    public string proximafase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enabled)
        {
            GameManager.Instance.LoadScene(proximafase);
        }
    }
}
