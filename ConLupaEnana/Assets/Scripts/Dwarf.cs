using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : MonoBehaviour
{
    public char behaviour; //H=honest, S=swindler, I=ignorant
    public int offer; //Price of the gem
    public int minimumPrice; //The minimum a dwarf will accept
    //offer and minimumPrice provide a really simple bargaining system. Once the game is functional, this should be reworked

    //All this integers will help generate a dwarf using several options
    public int skinColor;
    public int hairColor;
    public int hairType;
    public int beardType;
    public int clothes;

    public void newDwarf(int initialPrice){
        //1st -> Behaviour and offer. In the future, the offer should take into consideration de type of gem
        int rand = Random.Range(0,3);
        switch (rand){
            case 0:
                behaviour = 'H';
                offer = (int) Mathf.Round(Random.Range(0.9f*initialPrice, 1.2f*initialPrice));
                break;
            case 1:
                behaviour = 'S';
                offer = (int) Mathf.Round(Random.Range(initialPrice, 2*initialPrice));
                break;
            default:
                behaviour = 'I';
                offer = (int) Mathf.Round(Random.Range(0.5f*initialPrice, initialPrice));
                break;
        }

        minimumPrice = (int) Mathf.Round(offer/2);

        skinColor = Random.Range(1, 8); //Based on Fitzpatrick scale
        hairColor = Random.Range(0, 7); //Black, white, blond, red, brown, blue
        hairType = Random.Range(0, 8); //Long, medium, short, bald, curly, spikes, mohawk
        beardType = Random.Range(0, 3); //Curly, straight hair, short, moustache
        clothes = Random.Range(0, 3); //Shirt, jacket, armour, overalls
    }
}
