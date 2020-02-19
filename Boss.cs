using System;

public class Boss
{
    public string name;
    public int health;
    public int attack;
    

	public Boss()
	{
        this.name = "Big Boss";
        this.health = 80;
        this.attack = 10;
        
	}
    public Boss(string name, int health, int attack)
    {
        this.name = name;
        this.health = health;
        this.attack = attack;
        
    }
    public override string ToString()
    {
        string s1 = "";
        s1 += "Name: " + this.name
            + " Attack: " + this.attack
            + " Health: " + this.health;
           
        return s1;
    }
    public void attackHero(Hero h1)
    {
        h1.health -= this.attack;
        
    }
    public void attacked(Hero h1)
    {
        this.health -= h1.attack;
        
    }
    

}
