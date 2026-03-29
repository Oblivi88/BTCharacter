using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.InputSystem;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToDirtTask : ActionTask {

        private NavMeshAgent navAgent;
        private LayerMask groundLayer;
        protected override string OnInit() {
            navAgent = agent.GetComponent<NavMeshAgent>();
            groundLayer = LayerMask.GetMask("Ground");

            if (navAgent == null)
            {
                return $"{agent.name} - MoveToDirt: Unable to get NavMesh Agent Reference!";
            }
            else
            {
                return null;
            }
        }

		protected override void OnUpdate() {
            // CLICK TO MOVE
            if (Input.GetMouseButtonDown(0))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, float.MaxValue, groundLayer))
                {
                    navAgent.SetDestination(hitInfo.point);
                }
            }
        }
	}
}