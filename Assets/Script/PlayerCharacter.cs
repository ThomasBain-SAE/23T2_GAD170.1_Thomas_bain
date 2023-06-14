using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Variables will go first
    [SerializeField] private int Attack = 10;
    [SerializeField]private int Health = 100;
    [SerializeField]private int Level = 1;

    // Methods will go next

    // Start is called before the first frame update
    private void Start()
    {
        Attack = 10;
        Health = 100;
        Level = 1;    
        
    }

    // Update is called once per frame
    private void Update()
    {
        //if the player presses the Spacebar...
       
        {   
            if(Input.GetKeyDown(KeyCode.Space)){
                
            Debug.Log("TOm has hit the Spacebar");
            Level++;
            }
        }
       
    }
}
