using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFootsteps : MonoBehaviour
{
    public GameObject soundWavePrefab;
    
    public GameObject leftFoot, rightFoot;

    // Used to change enemy sprite and soundwave color after a player sonar collision has occured
    public PlayerController.PlayerColor myColor = PlayerController.PlayerColor.Random;
    private Color color = Color.white;
    private SpriteRenderer spriteRenderer;

    public float stepGrowthSpeed, stepFadeSize, stepFadeTimer;
    public float footStepIntervalTimer;
    private float footStepIntervalTimerDefault;

    public float showSpriteFadeTimer = 1f;
    
    private EnemyFollowing enemyFollowScript;

    private enum Foot { LeftFoot, RightFoot };
    private Foot currentFoot;

    public enum State { Idle, Chasing, Patrolling, Roaring };
    [HideInInspector]
    public State state = State.Idle;

    public AudioSource footStepSound;
    public AudioSource idleRoar;
    private float roarStartVolume;

    public Vector2 idleTimerRange;
    private float idleTimer;

    public float roarGrowthSpeed, roarFadeSize, roarFadeTimer;
    public float roarIntervalTimer;
    private float roarIntervalTimerDefault;
    public int roarSoundWaves;
    private int roarSoundWavesDefault;

    private bool showSprite = false, spotted = false;

    public float stepScreenShakeAmount = 0f, stepScreenShakeDuration = 0f;
    public float roarScreenShakeAmount = 0f, roarScreenShakeDuration = 0f;
    private ScreenShake cameraShake;

    public float roarPitchMin = 1f, roarPitchMax = 1f;

    void Start()
    {
        enemyFollowScript = GetComponent<EnemyFollowing>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        footStepIntervalTimerDefault = footStepIntervalTimer;
        roarIntervalTimerDefault = roarIntervalTimer;

        currentFoot = (Foot)Random.Range(0, 1);

        switch (myColor)
        {
            case PlayerController.PlayerColor.Random:
                switch (Random.Range(0, 4))
                {
                    case 0:
                        color = PlayerController.redColor;
                        myColor = PlayerController.PlayerColor.Red;
                        break;

                    case 1:
                        color = PlayerController.greenColor;
                        myColor = PlayerController.PlayerColor.Green;
                        break;

                    case 2:
                        color = PlayerController.blueColor;
                        myColor = PlayerController.PlayerColor.Blue;
                        break;

                    case 3:
                        color = PlayerController.yellowColor;
                        myColor = PlayerController.PlayerColor.Yellow;
                        break;
                }
                break;

            case PlayerController.PlayerColor.Red:
                color = PlayerController.redColor;
                break;

            case PlayerController.PlayerColor.Green:
                color = PlayerController.greenColor;
                break;

            case PlayerController.PlayerColor.Blue:
                color = PlayerController.blueColor;
                break;

            case PlayerController.PlayerColor.Yellow:
                color = PlayerController.yellowColor;
                break;
        }

        roarStartVolume = idleRoar.volume;

        idleTimer = Random.Range(idleTimerRange.x, idleTimerRange.y);

        roarSoundWavesDefault = roarSoundWaves;

        cameraShake = Camera.main.GetComponent<ScreenShake>();
    }

    void Update()
    {
        if (footStepIntervalTimer > 0)
        {
            footStepIntervalTimer -= Time.deltaTime;
        }

        if (showSprite)
        {
            if (spriteRenderer.color.a > 0)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - 1f / showSpriteFadeTimer * Time.deltaTime);
            }
            else
            {
                showSprite = false;
            }
        }

        switch (state)
        {
            case State.Idle:
                if (idleTimer > 0)
                {
                    idleTimer -= Time.deltaTime;
                }
                else
                {
                    RoaringState();
                }
                break;

            case State.Chasing:
                if (idleRoar.isPlaying)
                {
                    if (idleRoar.volume > 0)
                        idleRoar.volume -= roarStartVolume / 0.2f * Time.deltaTime;
                    else
                        idleRoar.Stop();
                }

                if (footStepIntervalTimer <= 0)
                {
                    GenerateFootstep();
                    footStepIntervalTimer = footStepIntervalTimerDefault;
                }
                break;

            case State.Patrolling:
                if (footStepIntervalTimer <= 0)
                {
                    GenerateFootstep();
                    footStepIntervalTimer = footStepIntervalTimerDefault;
                }
                break;

            case State.Roaring:
                if (roarIntervalTimer > 0)
                {
                    roarIntervalTimer -= Time.deltaTime;
                }
                else
                {
                    Roar();

                    if (roarSoundWaves > 1)
                    {
                        roarSoundWaves--;
                        roarIntervalTimer = roarIntervalTimerDefault;
                    }
                    else
                    {
                        IdleState();
                    }
                }
                break;
        }

        // Debug
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            spriteRenderer.color = color;
        }
        //*/
    }
    
    void GenerateFootstep()
    {
        GameObject footStep;

        if (currentFoot == Foot.LeftFoot)
        {
            footStep = Instantiate(soundWavePrefab, leftFoot.transform.position, Quaternion.identity);
            currentFoot = Foot.RightFoot;
        }
        else
        {
            footStep = Instantiate(soundWavePrefab, rightFoot.transform.position, Quaternion.identity);
            currentFoot = Foot.LeftFoot;
        }

        if (stepScreenShakeAmount > 0)
        {
            cameraShake.Shake(stepScreenShakeAmount, stepScreenShakeDuration);
        }

        footStepSound.pitch = Random.Range(.9f, 1.1f);
        footStepSound.Play();

        if (footStep != null)
        {
            SonarEffect effect = footStep.GetComponent<SonarEffect>();
            effect.growthSpeed = stepGrowthSpeed;
            effect.fadeSize = stepFadeSize;
            effect.fadeTimer = stepFadeTimer;

            SpriteRenderer soundWaveSpriteRenderer = footStep.GetComponent<SpriteRenderer>();
            Color soundWaveColor = spriteRenderer.color;
            soundWaveColor.a = 1;
            soundWaveSpriteRenderer.color = soundWaveColor;
        }
    }

    void Roar()
    {
        GameObject roar;
        roar = Instantiate(soundWavePrefab, transform.position, Quaternion.identity);

        SonarEffect effect = roar.GetComponent<SonarEffect>();
        effect.growthSpeed = roarGrowthSpeed;
        effect.fadeSize = roarFadeSize;
        effect.fadeTimer = roarFadeTimer;

        SpriteRenderer soundWaveSpriteRenderer = roar.GetComponent<SpriteRenderer>();
        Color soundWaveColor = spriteRenderer.color;
        soundWaveColor.a = 1;
        soundWaveSpriteRenderer.color = soundWaveColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Implement collision with player sonar so the sprite color and sound wave color change to the enemy's actual color
        if (other.gameObject.CompareTag("PlayerSonar") || other.gameObject.CompareTag("BigSonar"))
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), other, true);
            spriteRenderer.color = new Color(color.r, color.g, color.b, 1f);
            showSprite = true;
                
            spotted = true;
        }
    }

    public void IdleState()
    {
        idleTimer = Random.Range(idleTimerRange.x, idleTimerRange.y);

        state = State.Idle;
    }

    public void ChasingState()
    {
        state = State.Chasing;
    }

    public void PatrollingState()
    {
        state = State.Patrolling;
    }

    public void RoaringState()
    {
        idleRoar.volume = roarStartVolume;
        idleRoar.pitch = Random.Range(roarPitchMin, roarPitchMax);
        idleRoar.Play();

        // Reset amount of roar soundwaves to generate
        roarSoundWaves = roarSoundWavesDefault;
        roarIntervalTimer = roarIntervalTimerDefault;

        if (roarScreenShakeAmount > 0)
        {
            cameraShake.Shake(roarScreenShakeAmount, roarScreenShakeDuration);
        }

        state = State.Roaring;

        Roar();
    }
}
