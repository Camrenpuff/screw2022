using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private string animKey = "Open";
    private float offsetTime = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayAnimation();
    }

    void PlayAnimation()
    {
        offsetTime = Random.Range(1f, 5f);
        m_Animator.Play(animKey, 0, offsetTime);

    }
}
