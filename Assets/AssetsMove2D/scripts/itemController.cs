using UnityEngine;
using System.Collections;

public class itemController : MonoBehaviour
{

    [SerializeField] Vector3 _startScale;
    [SerializeField] Vector3 _startPosition;
    [SerializeField] Vector3 _calculateTarget;


    public Vector3 Target;
    [Range(0, 10)]
    public int ScaleFactor;
    [Range(0,10)]
    public int SpeedMove;
    [Range(-10, 10)]
    public int SpeedRotate=0;
    void Awake()
    {
        _startPosition = this.transform.position;
        _startScale = this.transform.localScale;
        _calculateTarget = this.transform.position + Target;
    }

    void Start()
    {
        StartCoroutine(MainCourutine());
    }

    void Update()
    {

    }

    void ChangeDirectionTransformPosition(ref Vector3 _target)
    {
        _target = _target == _startPosition ? _calculateTarget : _startPosition;
    }
 


    IEnumerator MainCourutine()
    {
        bool direction;
        Vector3 _startPos = _startPosition;
        Vector3 _targetPos = _calculateTarget;
        Vector3 _target = _calculateTarget;

        while (true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _target, Time.deltaTime* SpeedMove);
            this.transform.Rotate(0, 0, SpeedRotate);

       



            if (this.transform.position == _target) ChangeDirectionTransformPosition(ref _target);
            yield return null;
        }





    }
}
