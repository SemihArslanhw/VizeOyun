
public class HealthSystem
{
    private int health ;
    private bool shield;
    public HealthSystem(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void OpenShield()
    {
        this.shield = true;
    }

    public void CloseShield()
    {
        this.shield = false;
    }

    public void Damage(int damageAmount)
    {
        if(this.shield != true)
        {
            this.health -= damageAmount;
        }
        
        
    }

    public void Heal(int healAmount)
    {
        this.health += healAmount;
        if(this.health > 100)
        {
            this.health = 100;
        }
    }
}
