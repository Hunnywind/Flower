using UnityEngine;
using System.Collections;

public class CBee : MonoBehaviour {

    private Vector3 _target;

    public void SetTarget(Vector3 pos)
    {
        _target = pos - transform.position;
        _target.y += 2f;
        _target = _target.normalized;
    }

	void Update () {

        if (this.enabled)
        {
            transform.Translate(_target * 7f * Time.deltaTime);
        }
	}
}
