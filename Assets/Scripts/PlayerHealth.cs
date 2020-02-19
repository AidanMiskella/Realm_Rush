using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int playerHealth = 10;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;

    // Start is called before the first frame update
    void Start() {

        healthText.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {

        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);

        playerHealth--;
        healthText.text = playerHealth.ToString();
    }
}
