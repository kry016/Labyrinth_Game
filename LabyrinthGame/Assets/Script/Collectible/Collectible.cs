using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Collectible : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private UnityEvent Collision;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Collision.Invoke();

        }
    }

    public void CollectibleStar()
    {
        GameManager.AddStarPoint();
        Destroy(gameObject);
    }

    public void PresentWin(GameObject boardGame)
    {
        GameManager.VictoryGame(boardGame);
        Destroy(gameObject);        
    }
}
