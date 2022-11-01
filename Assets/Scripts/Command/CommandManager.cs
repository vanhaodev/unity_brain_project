using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CommandManager : MonoBehaviour
{
    public static CommandManager Instance; 
    public List<CommandModel> commands = new List<CommandModel>();


    //khu vực khởi tạo
    [SerializeField] TMP_InputField runValue;
    [SerializeField] TMP_Dropdown valueTypeDropDown;
    [SerializeField] TMP_Text commandStatus;
    //nơi chứa các command ui đã tạo
    [SerializeField] Animator commandSetupUIGroup; //đống hud khi run sẽ được ẩn đi
    [SerializeField] GameObject commandContainer;
    [SerializeField] GameObject commandUIPrefabs;
    [SerializeField] GameObject btnRun;
    [SerializeField] GameObject btnCancel;
    public Color[] commandUIBackground;

    //validate
    //chạy
    public bool isExcuting = false;
    float excuteTime = 0f;
    private void Awake()
    {
        Instance = this;
    }

    public void OnAdd()
    {
        if(!Regex.IsMatch(runValue.text, @"^*[0-9\.,-]+$"))
        {
            //Debug.LogError("Chỉ số và số thực");
            return;
        }
        CommandType type = CommandType.VectorX;
        switch (valueTypeDropDown.value)
        {
            case 0: //vector x
                type = CommandType.VectorX;
                break;
            case 1: //vector y
                type = CommandType.VectorY;
                break;
            case 2: //wait milisecond
                type = CommandType.WaitMilliseconds;
                break;
        }
        float value = float.Parse(runValue.text.Replace(".", ",")); //float chỉ nhận dấu phẩy
        CommandModel cmd = new CommandModel(type, Guid.NewGuid(), value, UnityEngine.Random.Range(0, commandUIBackground.Length));
        commands.Add(cmd);
        UpdateCommandList();
    }    
    public void UpdateCommandList()
    {
        //hủy hết các command trong srollview để update lại từ list
        foreach (Transform child in commandContainer.transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i < commands.Count; i++)
        {
            var slot = Instantiate(commandUIPrefabs, commandContainer.transform).GetComponent<CommandSlot>();
            slot.id = commands[i].commandId;
            slot.index.text = i.ToString();
            slot.commandType = commands[i].commandType;
            slot.SetBackgroundColor();
            slot.description.text = $"{commands[i].commandType} = {commands[i].value}";
            slot.gameObject.GetComponent<Image>().color = commandUIBackground[commands[i].background];

        }    
    }    
    public void SwapIndex(Guid id, bool isUp)
    {
        //item ở đầu nhất thì không thể chuyển lên
        //item ở cuối nhất thì không thể chuyển xuống
        //item là duy nhất thì không thể làm gì

        if (commands.Count < 2)
            return;

        for (int i = 0; i < commands.Count; i++)
        {
            if(commands[i].commandId == id)
            {
                if(isUp) //người chơi muốn chuyển lên
                {
                    if (i == 0)
                        return;

                    var temp = commands[i-1]; //lưu người ta lại
                    commands[i-1] = commands[i];
                    commands[i] = temp;
                    break;
                }   
                else //chuyển xuống
                {
                    if (i == commands.Count - 1)
                        return;

                    var temp = commands[i + 1]; //lưu người ta lại
                    commands[i + 1] = commands[i];
                    commands[i] = temp;
                    break;
                }    
            }    
        }    
    }

    public void OnRun()
    {
        if (isExcuting == false)
        {
            if (commands.Count < 1) return;

            StartCoroutine(RunCommand());
            //tính thời gian chạy
            for(int i = 0; i < commands.Count; i++)
            {
                if (commands[i].commandType == CommandType.WaitMilliseconds)
                {
                    excuteTime += commands[i].value*0.001f;
                }    
            }
            //thêm 3s cuối danh sách để không bị kết thúc dở
            excuteTime += 3000 * 0.001f;
        }    
    }

    IEnumerator RunCommand()
    {
        isExcuting = true;
        btnRun.GetComponent<Button>().enabled = false;
        btnRun.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        commandSetupUIGroup.SetTrigger("Hide");
        btnCancel.SetActive(true);

        for (int i = 0; i < commands.Count; i++)
        {
            commandStatus.text = $"{commands[i].commandType}: {commands[i].value}";
            if (commands[i].commandType == CommandType.WaitMilliseconds)
            {
                yield return new WaitForSeconds(commands[i].value * 0.001f);
            }
            else
            {
                switch (commands[i].commandType)
                {
                    case CommandType.VectorX: //vector x
                        BallMovement.Instance.ballRb.AddForce(transform.right * commands[i].value, ForceMode2D.Impulse);
                        break;
                    case CommandType.VectorY: //vector y
                        BallMovement.Instance.ballRb.AddForce(transform.up * commands[i].value, ForceMode2D.Impulse);
                        break;
                }
                //yield return new WaitForSeconds(0.5f);
            }
        }
        //khi kết thúc list command nên đợi 3s để kết thúc đẹp
        yield return new WaitForSeconds(3);

        BallMovement.Instance.ballRb.velocity = Vector2.zero;
        commandStatus.text = "";
        isExcuting = false;
        btnRun.GetComponent<Button>().enabled = true;
        btnRun.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        commandSetupUIGroup.SetTrigger("Enable");
        btnCancel.SetActive(false);
    }

    //Nhấn nút hủy để sắp xếp lại
    public void OnCancel()
    {
        BallMovement.Instance.transform.position = new Vector3(0, 0, 0);
        BallMovement.Instance.ballRb.velocity = Vector2.zero;

        commandStatus.text = "";
        isExcuting = false;
        btnRun.GetComponent<Button>().enabled = true;
        btnRun.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        commandSetupUIGroup.SetTrigger("Enable");
        btnCancel.SetActive(false);
        StopCoroutine(RunCommand());
    }    
    private void Update()
    {
        if(isExcuting)
        {
            btnRun.GetComponentInChildren<TMP_Text>().text = $"{excuteTime.ToString("0.00")}s";
            excuteTime -= Time.deltaTime;
        }    
        else
        {
            btnRun.GetComponentInChildren<TMP_Text>().text = "Run";
        }    
    }

}
