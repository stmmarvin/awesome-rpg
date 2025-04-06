using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    [SerializeField] private float chaseDistance = 51;

    private Mover mover;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceToPlayer() < chaseDistance)
        {
            mover.MoveTo(player.transform.position);
        }
    }
    private float DistanceToPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);

    }
}
