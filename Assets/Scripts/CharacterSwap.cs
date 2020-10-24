using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{

    private Character[] characters;
    
    int selectedCharacterIndex;

    private void Awake(){
        characters = FindObjectsOfType<Character>();
        characters[0].isActive = true;
        selectedCharacterIndex = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            SelectCharacter(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            SelectCharacter(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            SelectCharacter(2);
        }
    }

    private void SelectCharacter(int characterIndex){
        if (characterIndex != selectedCharacterIndex){
            characters[selectedCharacterIndex].isActive = false;
            characters[characterIndex].isActive = true;
            selectedCharacterIndex = characterIndex;
        }
    }

}
