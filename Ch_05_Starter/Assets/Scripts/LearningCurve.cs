using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    private int CurrentAge = 30;
    public int AddedAge = 1;

    public float Pi = 3.14f;
    public string FirstName = "Harrison";
    public bool IsAuthor = true;

    public int CurrentGold = 32;
    int DiceRoll = 7;
    int PlayerLives = 3;

    public bool PureOfHeart = true;
    public bool HasSecretIncantation = false;

    public string RareItem = "Relic Stone";
    string CharacterAction = "Attack";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(30 + 1);
        Debug.Log(CurrentAge + 1);

        ComputeAge();

        Debug.Log($"A string can have variables like {FirstName} inserted directly!");

        //Debug.Log(FirstName * Pi);
        //GenerateCharacter();

        int CharacterLevel = 32;
        int NextSkillLevel = GenerateCharacter("Spike", CharacterLevel);

        Debug.Log(NextSkillLevel);
        Debug.Log(GenerateCharacter("Faye", CharacterLevel));

        Thievery();
        OpenTreasureChamber();
        PrintCharacterAction();
        RollDice();
	    FindPartyMember();

        Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
        {
            { "Potion", 5 },
            { "Antidote", 7 },
            { "AsPirin", 1 }
        };
        Debug.LogFormat("Items: {0}", ItemInventory.Count);

        FindPartyMember();
        HealthStatus();
    }

    public void HealthStatus()
    {
        while(PlayerLives > 0)
        {
            Debug.Log("Still alive!");
            PlayerLives--;
        }

        Debug.Log("Player KO'd...");
    }

    public void FindPartyMember() //start from here for assignment
        //imput parameter 1 should be your own name, input parameter 2 should be the list where you want to be added
        // call this method from Start(), and print the whole list of players, you included
    {
        List<string> QuestPartyMembers = new List<string>()
        {
            "Grim the Barbarian",
            "Merlin the Wise",
            "Sterling the Knight"
        };
        Debug.LogFormat("Party Members: {0}", QuestPartyMembers.Count);

        QuestPartyMembers.Insert(2, "Clara Marie Pedersen");

        for(int i = 0; i < QuestPartyMembers.Count; i++)
        {
            Debug.LogFormat("Index: {0} - {1}", i, QuestPartyMembers[i]);

            if(QuestPartyMembers[i] == "Merlin the Wise")
            {
                Debug.Log("Glad you're here Merlin!");
            }
        }
    }

    public void RollDice()
    {
        switch(DiceRoll)
        {
            case 7:
            case 15:
                Debug.Log("Mediocre damage, not bad.");
                break;
            case 20:
                Debug.Log("Critical hit, the creature goes down!");
                break;
            default:
                Debug.Log("You completely missed and fell on your face.");
                break;
        }
    }

    public void PrintCharacterAction()
    {
        switch(CharacterAction)
        {
            case "Heal":
                Debug.Log("Potion sent.");
                break;
            case "Attack":
                Debug.Log("To arms!");
                break;
            default:
                Debug.Log("Shields up.");
                break;
        }
    }

    public void OpenTreasureChamber()
    {
        if(PureOfHeart && RareItem == "Relic Stone")
        {
            if(!HasSecretIncantation)
            {
                Debug.Log("You have the spirit, but not the knowledge.");
            } else
            {
                Debug.Log("The treasure is yours, worthy hero!");
            }
        } else
        {
            Debug.Log("Come back when you have what it takes.");
        }
    }

    public void Thievery()
    {
        if(CurrentGold > 50)
        {
            Debug.Log("You're rolling in it!");
        } else if (CurrentGold < 15)
        {
            Debug.Log("Not much there to steal...");
        } else
        {
            Debug.Log("Looks like your purse is in the sweet spot");
        }
    }

    public int GenerateCharacter(string name, int level)
    {
        // Debug.LogFormat("Character: {0} - Level: {1}", name, level);
        return level += 5;
    }

    /// <summary>
    /// Computes a modified age integer
    /// </summary>
    void ComputeAge()
    {
        Debug.Log(CurrentAge + AddedAge);
    }
}
