using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //public InputController InputController {get; private set;}
    public int genuineProb { get; private set; }
    public int syntheticProb { get; private set; }
    public float finalMult { get; private set; }
    public GameObject gemObj, dwarfObj;

    void Awake()
    {
        Instance = this;
        //InputController = GetComponentInChildren<InputController>();
        genuineProb = 90;
        syntheticProb = 8;
        finalMult = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Destroy(gemObj);
            Destroy(dwarfObj);
            gemObj = new GameObject("GemObject", typeof(Gem));
            Gem gem = gemObj.GetComponentInChildren<Gem>();
            dwarfObj = new GameObject("DwarfObject", typeof(Dwarf));
            Dwarf dwarf = dwarfObj.GetComponentInChildren<Dwarf>();

            gem.newGem(genuineProb, syntheticProb, finalMult);
            dwarf.newDwarf(gem.price);

            Debug.Log("Gem: "+gem.gem+"\nType: "+gem.type+"\nPrice and Final Price: "+gem.price+"\t "+gem.finalPrice+"Color: "+gem.color+"\nHardness and shape: "+gem.hardness+"\t "+gem.shape+"\nSize and Weight: "+gem.size+"\t "+gem.weight);
            Debug.Log("Dwarf: "+dwarf.behaviour+"\nOffer: "+dwarf.offer+"\nSkin and hair color: "+dwarf.skinColor+"\t "+dwarf.hairColor+"Clothes: "+dwarf.clothes+"\nHair and Beard type: "+dwarf.hairType+"\t "+dwarf.beardType);
        }
        
    }
}
