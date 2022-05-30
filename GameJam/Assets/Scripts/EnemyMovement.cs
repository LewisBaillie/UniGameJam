using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 0.5f;
    public float attackZoneRadius = 10f;
    public GameObject player;
    public float swingRadius = 1f;
    public int damage = 20;
    PlayerScript player_info;

    float time_since_last_swing = 0f;
    public float swing_frequency = 1f;

    Vector3 patrol_position;
    Vector3 random_movement_vector;

    float time_since_last_patrol = 0f;
    public float change_patrol_frequency = 10f;
    float dist_from_patrol;
    float dist_move_from_patrol = 10f;

    Vector3 enemyVelocity;

    enum State
    {
        Attacking,
        Passive
    };

    State enemyState = State.Passive;

    // Start is called before the first frame update
    void Start()
    {
        if (player.GetComponent<PlayerScript>())
        {
            player_info = player.GetComponent<PlayerScript>();
        }
        patrol_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time_since_last_swing += Time.deltaTime;
        time_since_last_patrol += Time.deltaTime;

        if (player_info.alive)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 offsetVector = playerPos - transform.position;
            float distance = offsetVector.magnitude;

            if (enemyState == State.Attacking)
            {
                enemyVelocity = (offsetVector / distance) * enemySpeed * Time.deltaTime;
                enemyVelocity.y = 0;

                if (time_since_last_swing >= swing_frequency)
                {
                    if (distance < swingRadius)
                    {
                        player_info.TakeDamage(damage);
                        time_since_last_swing = 0f;
                        Debug.Log("swing");
                    }
                }
            }
            else if (enemyState == State.Passive)
            {
                Vector3 go_to = patrol_position - transform.position;
                dist_from_patrol = go_to.magnitude;

                if (time_since_last_patrol >= change_patrol_frequency)
                {
                    Vector3 random_position = new Vector3(patrol_position.x + Random.Range(-dist_move_from_patrol, dist_move_from_patrol), 0.5f, patrol_position.z + Random.Range(-dist_move_from_patrol, dist_move_from_patrol));
                    patrol_position = random_position;
                    time_since_last_patrol = 0f;
                }
                if (dist_from_patrol > 1f)
                {
                    enemyVelocity = (go_to / dist_from_patrol) * enemySpeed * Time.deltaTime;
                    enemyVelocity.y = 0;
                }
                else
                {
                    enemyVelocity.x = 0f;
                    enemyVelocity.y = 0f;
                    enemyVelocity.z = 0f;
                }

            }

            if (distance < attackZoneRadius)
            {
                enemyState = State.Attacking;
            }
            else
            {
                enemyState = State.Passive;
            }
        }

        transform.position += enemyVelocity;
    }
}
