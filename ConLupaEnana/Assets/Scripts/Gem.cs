using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public char gem; //Initial letter!
    public char type; //G=genuine, S=synthetic, F=fake
    public int price; //price that the gem should have
    public int finalPrice; //price that you'll get paid at the end of the day
    public Color color; //RGB
    public int intensity; //Transparency
    public int hardness; //Diamond=10, Sapphire=9, Ruby=9, Emerald=8, Jade=7, Amethyst=7, Pearl=3
                            //Ranges from 0 to 10, Glass=7, Porcelain=5, Nail=2
    public string shape; //"Round", "Square", "Star", "Heart", "Oval"
    public int weight; 
    public int size; //Size and weight are relative. Size goes 1-3, weight goes 10-30.

    public void newGem(int genuineProb, int syntheticProb, float finalMult){ //Probability of genuine and synthetic gems, and multiplier to calculate the final price
        //1st -> Gem 
        char[] gems = new char[] {'D', 'S', 'R', 'E', 'J', 'A', 'P'};
        int rand = Random.Range(0, gems.Length);
        gem = gems[rand];

        //2nd -> Type
        rand = Random.Range(0, 101);
        if (rand<genuineProb) type = 'G';
        else if (rand<(syntheticProb+genuineProb)) type = 'S';
        else type = 'F';

        //3rd -> Color
        int priceModifier = generateColor();

        //4th -> Intensity
        priceModifier += generateIntensity();

        //5th -> Hardness
        generateHardness();

        //6th -> Shape
        priceModifier += generateShape();

        //7th -> Size
        size = Random.Range (1, 4);

        //8th -> Weight
        float priceMult;
        if (type == 'F') weight = size*10-7;
        else weight = size*10+Random.Range(-5, 6);
        if(weight > 30) weight = 30;
        if (weight<=10) priceMult = 0.5f;
        else if (weight <=20) priceMult=1f;
        else priceMult = 1.5f;

        //9th -> Price
        generatePrice(priceMult, priceModifier);

        //10th -> Final Price
        finalPrice = (int) Mathf.Round(price * finalMult);
    }

    private int generateColor(){
        int rand, priceModifier = 0;
        switch (gem) {
            case 'D':
                if (type == 'G') color = new Color(0.97f, 0.86f, 0.44f, 1f); //Yellowish
                else if (type == 'S') color = new Color (0.88f, 1f, 1f, 1f); //Blueish
                else new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f); //Random color
                break;
            case 'S':
                if (type == 'G'){
                    color = new Color(0f, 0f, Random.Range(0.5f, 1f), 1f); //Blue
                    if (color.b >= 0.85f) priceModifier = 50;
                    else if(color.b < 0.65f) priceModifier = -25;
                }
                else if (type == 'S') color = new Color(0f, 0f, Random.Range(0.75f, 1f), 1f); //More intense blue
                else new Color(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 1f, 1f); //Random blueish shade
                break;
            case 'R':
                if (type == 'G'){
                    color = new Color(Random.Range(0.5f, 1f), 0f, 0f, 1f); //Red more or less dark
                    if (color.r >= 0.85f) priceModifier = 50;
                    else if (color.r<0.65f) priceModifier = -25;
                }
                else if (type == 'S') color = new Color(Random.Range(0.75f, 1f), 0f, 0f, 1f); //Red but always more intense
                else new Color(1f, Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 1f); //Random red shade
                break;
            case 'E':
                if (type == 'G'){
                    color = new Color(0f, Random.Range(0.5f, 1f), 0f, 1f); //Green more or less dark
                    if (color.g >= 0.85f) priceModifier = 50;
                    else if (color.g < 0.65f) priceModifier = -25;
                }
                else if (type == 'S') color = new Color(0f, Random.Range(0.75f, 1f), 0f, 1f); //Green but always
                else new Color (Random.Range(0f,0.5f), 1f, Random.Range(0f,0.5f), 1f); //Random green shade
                break;
            case 'J':
                rand = Random.Range(0, 5);
                switch (rand){
                    case 0:
                        color = new Color(0.16f, 0.71f, 0.39f, 1f); //Green
                        priceModifier = 50;
                        break;
                    case 1:
                        color = new Color(0.92f, 0.6f, 0.31f, 1f); //Orange
                        break;
                    case 2:
                        color = new Color(0.95f, 0.77f, 0.06f, 1f); //Yellow
                        break;
                    case 3:
                        color = new Color(1f, 0.98f, 0.91f, 1f);//White
                        break;
                    case 4:
                        color =  new Color(0.91f, 0.85f, 0.94f, 1f);//Lavender
                        break;
                    default:
                        color = new Color(0f, 0f, 0f, 1f);
                        break;
                }
                break;
            case 'A':
                if (type == 'G'){
                    color = new Color (Random.Range(0.29f, 0.69f), 0f, 1f, 1f); //Purple tones
                    if (color.r < 0.39f) priceModifier = 50;
                    else if (color.r >= 0.59f) priceModifier = -25;
                }
                else if (type == 'S') color = new Color (Random.Range(0.39f, 0.5f), 0f, 1f, 1f); //More intense purple tones
                else color = new Color (Random.Range (0.29f, 0.69f), Random.Range(0f,1f), 1f, 1f); //Random purple shade
                break;
            case 'P':
                rand = Random.Range (1, 101);
                if (rand<=5 && type == 'G'){
                    color = new Color (0.11f, 0.15f, 0.2f, 1f); //Black ultra rare pearl
                    priceModifier = 50;
                }
                else{
                    if (type == 'G') color = new Color (1f, 0.98f, 0.91f, 1f); //White-yellowish tone
                    else if (type=='S') color = new Color (1f, 1f, 1f, 1f); //Perfect white
                    else color = new Color (Random.Range(0.9f, 1f), Random.Range(0.9f, 1f), Random.Range(0.9f, 1f), 1f); //Random white shade
                }
                break;
            default:
                color = new Color(0f, 0f, 0f, 1f);
                priceModifier = -1000;
                break;
        }
        return priceModifier;
    }

    private int generateIntensity(){
        int priceModifier = 0;
        switch (gem) {
            case 'D':
                color.a = Random.Range(0f, 0.6f);
                if (color.a <0.1f) priceModifier = 50;
                else if (color.a >=0.25f) priceModifier = -50;
                break;
            case 'S':
                color.a = Random.Range(0.3f, 0.9f);
                if (color.a<0.6f) priceModifier = -25;
                else if (color.a>0.8f) priceModifier = 50;
                break;
            case 'R':
                color.a = Random.Range(0.3f, 0.9f);
                if (color.a<0.6f) priceModifier = -25;
                else if (color.a>0.8f) priceModifier = 50;
                break;
            case 'E':            
                color.a = Random.Range(0.3f, 0.9f);
                if (color.a<0.6f) priceModifier = -25;
                else if (color.a>0.8f) priceModifier = 50;
                break;
            case 'J':
                color.a = 1f;
                break;
            case 'A':
                color.a = Random.Range(0.3f, 0.9f);
                if (color.a<0.6f) priceModifier = -25;
                else if (color.a>0.8f) priceModifier = 50;
                break;
            case 'P':
                color.a = 1f;
                break;
            default:
                break;
        }
        return priceModifier; 
    }

    private void generateHardness(){
        switch (gem) {
            case 'D':
                hardness = 10;
                break;
            case 'S':
                hardness = 9;
                break;
            case 'R':
                hardness = 9;
                break;
            case 'E':            
                hardness = 8;
                break;
            case 'J':
                hardness = 7;
                break;
            case 'A':
                hardness = 7;
                break;
            case 'P':
                hardness = 3;
                break;
            default:
                hardness = 0;
                break;
        }
    }

    private int generateShape(){//"Round", "Square", "Star", "Heart", "Oval"
        float rand = Random.Range(0f, 1f); 
        int priceModifier = 0;
        switch (gem) {
            case 'D':
                if (rand<0.35f) shape = "Round";
                else if (rand<0.7f) shape = "Square";
                else if (rand<0.75f){
                    shape = "Star";
                    priceModifier = -100;
                }
                else if (rand<0.8f){
                    shape = "Heart";
                    priceModifier = -100;
                }
                else {
                    shape = "Oval";
                    priceModifier = -50;
                }
                break;
            case 'S':
                if (rand<0.35f) shape = "Oval";
                else if (rand<0.7f) shape = "Square";
                else if (rand<0.75f){
                    shape = "Star";
                    priceModifier = -100;
                }
                else if (rand<0.8f){
                    shape = "Heart";
                    priceModifier = -100;
                }
                else {
                    shape = "Round";
                    priceModifier = -50;
                }
                break;
            case 'R':
                if (rand<0.35f){
                    shape = "Round";
                    priceModifier = 50;
                }
                else if (rand<0.7f){
                    shape = "Square";
                    priceModifier = 50;
                }
                else if (rand<0.75f){
                    shape = "Star";
                    priceModifier = -100;
                }
                else if (rand<0.8f){
                    shape = "Heart";
                    priceModifier = -100;
                }
                else shape = "Oval";
                break;
            case 'E':            
                if (rand<0.35f) shape = "Round";
                else if (rand<0.7f){
                    shape = "Square";
                    priceModifier = 50;
                }
                else if (rand<0.75f){
                    shape = "Star";
                    priceModifier = -100;
                }
                else if (rand<0.8f){
                    shape = "Heart";
                    priceModifier = -100;
                }
                else shape = "Oval";
                break;
            case 'J':
                if (rand<0.35f) shape = "Round";
                else if (rand<0.7f) shape = "Square";
                else if (rand<0.75f){
                    shape = "Star";
                    priceModifier = 50;
                }
                else if (rand<0.8f){
                    shape = "Heart";
                    priceModifier = 50;
                }
                else shape = "Oval";
                break;
            case 'A':
                if (rand<0.35f) shape = "Round";
                else if (rand<0.7f) shape = "Square";
                else if (rand<0.75f) shape = "Star";
                else if (rand<0.8f) shape = "Heart";
                else shape = "Oval";
                break;
            case 'P':
                if (rand<0.75f) shape = "Round";
                else {
                    shape = "Deformed";
                    priceModifier = -10;
                }
                break;
            default:
                shape = "Square";
                break;
        }
        return priceModifier;
    }

    private void generatePrice(float priceMult, int priceModifier){
        int basePrice;
        switch (gem) {
            case 'D':
                basePrice = 500;
                break;
            case 'S':
                basePrice = 400;
                break;
            case 'R':
                basePrice = 300;
                break;
            case 'E':            
                basePrice = 200;
                break;
            case 'J':
                basePrice = 100;
                break;
            case 'A':
                basePrice = 50;
                break;
            case 'P':
                basePrice = 20;
                break;
            default:
                basePrice = 0;
                break;
        }
        price = (int) Mathf.Round((basePrice + priceModifier) * priceMult);
        if (type == 'S') price = (int) Mathf.Round(price*0.5f);
        else if (type == 'F') price = (int) Mathf.Round(price*0.1f);
    }
}