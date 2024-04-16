using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    public int life = 3;


    void Update()
    {
        if (life <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("enemy")){
            life -= 1;
            Destroy(other.gameObject);
        }
    }
}
