using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] AudioSource FinishSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish Line"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            FinishSound.Play();
            Invoke(nameof(EndScene), 1.3f); 
        }
    }

    private void EndScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
