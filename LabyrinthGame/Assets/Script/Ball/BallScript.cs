using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private GameObject BoardGame;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        GameManager.star = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
        m_Rigidbody.sleepThreshold = 0.0f;
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
            GameManager.LoserGame(BoardGame);
            
        }
    }
}
