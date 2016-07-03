using UnityEngine;
using System.Collections;

public class Upgrade 
{
    public StrategyUpgrade strategyUpgrade{ get; set;}

    public Upgrade(StrategyUpgrade _strategyUpgrade)
    {
        strategyUpgrade = _strategyUpgrade;
    }
	 
    public void StartUpgrade()
    {
       // strategyUpgrade = strategyUpgrade.GetNewUpgrade(this);
    }
}
    
public interface StrategyUpgrade
{
    void  GetNewUpgrade(Upgrade upgrade);
}
    
public class Flower : StrategyUpgrade
{
    public void GetNewUpgrade(Upgrade upgrade)
    {
        upgrade.strategyUpgrade = new Rabbit();
    }
}
    
public class Rabbit : StrategyUpgrade
{
    public void GetNewUpgrade(Upgrade upgrade)
    {
        upgrade.strategyUpgrade = new Cat();
    }
}
    
public class Cat : StrategyUpgrade
{
    public void GetNewUpgrade(Upgrade upgrade)
    {
        upgrade.strategyUpgrade = new Cat();
    }
}