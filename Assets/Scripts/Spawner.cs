using UnityEditor.SearchService;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    WordArrays wordArrays;
    private float time = 1;
    public int force = 4;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject spawnObject;

    private void Start()
    {
        wordArrays = GetComponent<WordArrays>();
        wordArrays.SetDifficultyLevel(1);
    }

        private void Update()
    {     
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = spawnInterval;
            Spawn();
        }             
    }

    private void Spawn()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.SpawnFountain);
        GameObject wordObject = ObjectPool.instance.GetPooledObject();
        wordObject.transform.position = transform.position;
        wordObject.GetComponent<WordObj_Spawner>().retrievedWord = wordArrays.DispenseWord();
        wordObject.GetComponent<Rigidbody>().AddForce(transform.up * force * Time.deltaTime, ForceMode.Impulse);
        wordObject.transform.eulerAngles = new Vector3(Random.RandomRange(-15, 15), 0, Random.RandomRange(-15, 15));
        wordObject.SetActive(true);
    }
}
