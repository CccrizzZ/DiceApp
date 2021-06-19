using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour 
{
    // dice prefab
    GameObject DicePrefab;

    // list of all dice
    public List<GameObject> AllDice = new List<GameObject>();

    // list of all possible rotation angles
    List<float> RotationAngles = new List<float>();


    public AudioSource DiceSound;


    void Start()
    {
        RotationAngles.Add(0);
        RotationAngles.Add(90);
        RotationAngles.Add(180);
        RotationAngles.Add(270);

        var dices = GameObject.FindGameObjectsWithTag("Dice");
        foreach (var dice in dices)
        {
            AllDice.Add(dice);
        }

        RollDice();
        
    }


    public void RollDice()
    {  
        DiceSound.Play();
        
        foreach (var dice in AllDice)
        {
            var RandomAngleX = Random.Range(0, RotationAngles.Count);
            var RandomAngleZ = Random.Range(0, RotationAngles.Count);

            // reset dice y position
            dice.transform.position = new Vector3(dice.transform.position.x, 3.0f, dice.transform.position.z);

            // randomize dice rotation
            dice.transform.Rotate(
                new Vector3(
                    RotationAngles[RandomAngleX],
                    0,
                    RotationAngles[RandomAngleZ]
                )
            );
            
        }
    }
}
