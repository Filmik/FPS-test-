using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    float durability;
    [SerializeField]
    GameObject[] gunsThatDoDamege;
    GameObject gameManager;
    WinGame winGame;
    private void Awake()
    {
        gameManager = GameObject.FindWithTag(Constants.Tags.gameManager);
        if (gameManager != null)
            winGame = gameManager.GetComponent<WinGame>();
        else
            Debug.LogError("gameManager==null");
    }
    
    public void TakeDamage(float amount)
    {
        durability -= amount;
        if (durability <= 0f)
        {
            winGame.CheckWinConditions();
            Die();
        }
    }
    public void GunHitTarget(float amount, string gunTag)//check if gun can damage target
    {
        for(int i=0; i<gunsThatDoDamege.Length;i++)
        {
            if (gunsThatDoDamege[i].CompareTag(gunTag))
            {
                TakeDamage(amount);
                i = gunsThatDoDamege.Length;
            }
        }
    }
    void Die() => Destroy(gameObject);
}
