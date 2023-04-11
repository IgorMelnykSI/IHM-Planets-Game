using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{

    public Text TxtQuestion;
    public Text TxtKey;

    public int KeyNumber = 0;

    public int maxHealth =100;
    public int currentHealth;

    public BarreDeVie healthBar;

    public bool isInvicible = false;

    // Start is called before the first frame update
    void Start()
    { 
      currentHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
      if(currentHealth == 0 ){
        transform.position = new Vector3(-48, 0, 0);
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
      }

      if(Input.GetKey(KeyCode.M)){
        transform.position = new Vector3(64, 0, 57);
      }

    }

    private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Key"){
            KeyNumber = KeyNumber + 1;
            TxtQuestion.text = KeyNumber+"";
            Debug.Log(KeyNumber+"");
            TxtKey.GetComponent<Text>().enabled = true;
            Invoke("DisableObject", 2f);

        }
	}

    public void DisableObject()
    {
      TxtKey.GetComponent<Text>().enabled = false;
    }

    public void TakeDamage(int damage){
      if(!isInvicible){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        isInvicible = true;
        StartCoroutine(InvincibilityFlash());
      }

    }

    public IEnumerator InvincibilityFlash(){
        yield return new WaitForSeconds(3f);
        isInvicible = false;

    }


}

