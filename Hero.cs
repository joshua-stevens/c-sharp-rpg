using System;

public class Hero
{
    public string name;
    public int health;
    public int attack;
    
    public int potions;
    public int level;

    public Hero()
    {
        this.name = "Hero";
        this.health = 30;
        this.attack = 5;
        
        this.potions = 3;
        this.level = 1;
    }
    public Hero(string name, int health, int attack, int potions, int level)
    {
        this.name = name;
        this.health = health;
        this.attack = attack;
        
        this.potions = potions;
        this.level = level;
    }
    public override string ToString()
    {
        string s1 = "";
        s1 += "Name: " + this.name
            + " Level: " + this.level
            + " Health: " + this.health
            + " Attack: " + this.attack
            +" Number of Potions: " + this.potions;
        return s1;
    }
   
    
    

    
}
   
