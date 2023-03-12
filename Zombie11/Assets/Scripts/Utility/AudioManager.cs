using UnityEngine.Audio;
using UnityEngine;

//���� �����ϴ� ��ũ��Ʈ : �̱���
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    //�÷��� ����� �̸�
    public string bgmName = "";

    public AudioMixer audioMixer;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);

        AudioMixerGroup[] audioMixerGroup = audioMixer.FindMatchingGroups("Master");

        foreach (Sound s in sounds)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if (s.source.loop)
            {
                s.source.outputAudioMixerGroup = audioMixerGroup[1];//BGM
            } else
            {
                s.source.outputAudioMixerGroup = audioMixerGroup[2];//SFX
            }
        }
    }

    public void Play(string name)
    {
        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == name)
            { 
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log("Sound : " + name + "File not found!!!");
            return;
        }

        sound.source.Play();
    }

    public void StopBgm()
    {
        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == bgmName)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            //Debug.Log("Stop Sound : " + name + "File not found!!!");
            return;
        }

        bgmName = "";
        sound.source.Stop();
    }

    public void PlayBgm(string name)
    {
        //������ �÷��� �Ǵ� ������� ���ο� ������� ������
        if(bgmName == name)
        {
            return;
        }

        //���� ����� �ߴ�
        StopBgm();

        //���ο� ����� �÷���
        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log("Play Sound : " + name + "File not found!!!");
            return;
        }

        bgmName = sound.name;

        sound.source.Play();
    }

}
