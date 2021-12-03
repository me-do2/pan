using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavController : MonoBehaviour
{
    public Transform egg = null;
    private NavMeshAgent agent;
    private string _type;

    private void Awake()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();


        this.agent.enabled = true;

        if (NavMesh.SamplePosition(this.transform.position, out var hit, float.MaxValue, NavMesh.AllAreas))
        {
            this.agent.Warp(hit.position);
        }
    }

    private void Update()
    {
        if (this.agent.isActiveAndEnabled && (this.egg != null))
        {
            this.agent.SetDestination(this.egg.position);
        }
    }
    private void LateUpdate()
    {
        var forward = this.transform.forward;
        if (forward.z < 0.5f)
        {
            this.transform.rotation = Quaternion.LookRotation(Vector3.forward, forward);
        }
    }
}