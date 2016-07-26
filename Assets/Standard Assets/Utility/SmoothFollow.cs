using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{
		// The target we are following
		[SerializeField]
		private Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;
        [SerializeField]
        private float speed = 50.0f;
        
		void Start() { }
        
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;
            
			var wantedHeight = target.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

            // Set the height of the camera
            // transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            transform.LookAt(target);

            Vector3 dist = new Vector3(Input.GetAxis("CameraVertical"), Input.GetAxis("CameraHorizontal"), 0.0f);

            transform.RotateAround(target.position, transform.right, dist.x);
            transform.RotateAround(target.position, transform.up, dist.y);
        }
	}
}