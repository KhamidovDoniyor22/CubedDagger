using UnityEngine;

public class RandomPatternGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _patternCubes;

    [SerializeField] private Transform _cubeContainer;

    [SerializeField] private int _numOfCubes;

    private void Awake()
    {
        for(int i = 0; i < _numOfCubes; i++)
        {
            int randomIndex = Random.Range(0, _patternCubes.Length);
            GameObject newCube = Instantiate(_patternCubes[randomIndex]);
            newCube.transform.parent = _cubeContainer;
        }
    } 
}
