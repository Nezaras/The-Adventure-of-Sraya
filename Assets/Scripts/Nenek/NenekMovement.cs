using UnityEngine;
using PathCreation;

public class NenekMovement : MonoBehaviour
{
    [SerializeField] GameObject tempatKarungNenek;
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] PathCreator pathCreator;
    [SerializeField] EndOfPathInstruction endOfPathInstruction;
    [SerializeField] Animator anim;

    public float speed;
    
    private float distanceTravelled;

    void Start()
    {
        speed = 0;
    }

    void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }

    public void WalkingNenek()
    {
        anim.SetBool("Walk", true);
        speed = 1.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NenekStopper"))
        {
            anim.SetBool("Walk", false);
            speed = 0;

            dialogueTrigger.isFirst = false;

            tempatKarungNenek.SetActive(true);
        }
    }
}
