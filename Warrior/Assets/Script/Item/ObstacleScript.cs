using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet"
        || collision.gameObject.tag == "skill_atk_1"
        || collision.gameObject.tag == "skill_atk_2"
        || collision.gameObject.tag == "skill_atk_3")
        {
            Destroy(collision.gameObject);
        }
    }
}
