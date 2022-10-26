using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    float respawnTime = 1.3f;
    [SerializeField]float deathHeight=-10f;
    bool dead = false;

    [SerializeField] AudioSource deathSound;
    private void Update()
    {
        if (transform.position.y <= deathHeight)
        {
            Die();
            Invoke(nameof(ReloadLevel), respawnTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }  
    }

    void Die()
    {
        if (dead)
        {
            return;
        }
        // make player invisible by disable the mesh renderer
        GetComponent<MeshRenderer>().enabled = false;

        // disable player physics by disable rigidbody
        GetComponent<Rigidbody>().isKinematic = true;

        // disable movement
        GetComponent<playerMovement>().enabled = false;

        // respawn after 1.3 seconds
        Invoke(nameof(ReloadLevel), 1.3f);

        dead = true;
        deathSound.Play();
    }

    void ReloadLevel() {
        // load current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dead = false;
    }
}
