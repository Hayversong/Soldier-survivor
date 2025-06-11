using UnityEngine;

public class AreaWeaponPrefab : MonoBehaviour
{
    public AreaWeapon weapon;
    private Vector3 targetSize;
    private float timer;
    void Start()
    {
        weapon = GameObject.Find("Area Weapon").GetComponent<AreaWeapon>();
        //Destroy(gameObject, weapon.duration);
        targetSize = Vector3.one * weapon.range;
        transform.localScale = Vector3.zero;
        timer = weapon.duration;
    }

    void Update()
    {
        //cresce e encolhe
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, Time.deltaTime * 5);
        //encolhe e entao destroi
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            targetSize = Vector3.zero;
            if(transform.localScale.x == 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage(weapon.damage);
        }
    }
}
