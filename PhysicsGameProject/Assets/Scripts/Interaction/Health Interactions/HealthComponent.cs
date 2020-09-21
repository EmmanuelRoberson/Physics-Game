
public class HealthComponent
{
    public HealthComponent(float healthValue)
    {
        HealthValue = healthValue;
    }
    
    public float HealthValue;

    public void AlterHealth(float alterAmount)
    {
        HealthValue += alterAmount;
    }
}
