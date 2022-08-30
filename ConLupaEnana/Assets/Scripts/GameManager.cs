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
    public GameObject gemObj;

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
            gemObj = new GameObject("GemObject", typeof(Gem));
            Gem gem = gemObj.GetComponentInChildren<Gem>();

            gem.newGem(genuineProb, syntheticProb, finalMult);

            Debug.Log("Joya: "+gem.gem+"\nType: "+gem.type+"\nPrice and Final Price: "+gem.price+"\t "+gem.finalPrice+"Color: "+gem.color+"\nHardness and shape: "+gem.hardness+"\t "+gem.shape+"\nSize and Weight: "+gem.size+"\t "+gem.weight);
        }
        
    }
}
