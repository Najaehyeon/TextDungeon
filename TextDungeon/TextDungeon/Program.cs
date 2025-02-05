using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

class Program
{
    static void Main()
    {
        StartStage startStage = new StartStage(); // 시작 스테이지 객체 생성
        StateStage stateStage = new StateStage(); // 상태 보기 스테이지 객체 생성
        InventoryStage inventoryStage = new InventoryStage(); // 인벤토리 스테이지 객체 생성
        StoreStage storeStage = new StoreStage(); // 상점 스테이지 객체 생성
        BuyItemStage buyItemStage = new BuyItemStage(); // 아이템 구매 스테이지 객체 생성
        EquipmentStage equipmentStage = new EquipmentStage(); // 장착 관리 스테이지 객체 생성
        Warrior warrior = new Warrior(); // 캐릭터 객체 생성

        // 아이템 객체 생성
        IItem oldSword = new OldSword();
        IItem spartanSpear = new SpartanSpear();
        IItem noviceArmor = new NoviceArmor();
        IItem spartanArmor = new SpartanArmor();

        // 아이템 리스트로 모으기
        List<IItem> itemList = new List<IItem>();
        itemList.Add(oldSword);
        itemList.Add(spartanSpear);
        itemList.Add(noviceArmor);
        itemList.Add(spartanArmor);

        startStage.Info(); // 시작 스테이지 소개
        startStage.Choice(); // 선택지 보여주기
        // 선택하기
        while (true)
        {
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                // 상태보기 스테이지
                Console.Clear();
                // 상태 보기 스테이지 설명
                stateStage.Info();
                // 캐릭터 상태 보여주기
                // 장착 아이템에 따라 능력치 갱신해주기
                warrior.str += oldSword.IsEquipped == true ? oldSword.Str : 0;
                warrior.str += spartanSpear.IsEquipped == true ? spartanSpear.Str : 0;
                warrior.def += noviceArmor.IsEquipped == true ? noviceArmor.Def : 0;
                warrior.def += spartanArmor.IsEquipped == true ? spartanArmor.Def : 0;
                warrior.StateInfo();
                // 상태 보기 스테이지에서 선택지 보여주기
                stateStage.Choice();
                while (true)
                {
                    string choice1 = Console.ReadLine();
                    if (choice1 == "1")
                    {
                        Console.Clear();
                        startStage.Info();
                        startStage.Choice();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력했습니다.");
                        Console.Write(">> ");
                    }
                }
            }
            else if (choice == "2")
            {
                // 인벤토리 스테이지
                Console.Clear();
                inventoryStage.Info();

                // 보유 중인 아이템 목록 나와야함
                if (warrior.items.Count == 0)
                {
                    Console.WriteLine("보유 중인 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < warrior.items.Count; i++)
                    {
                        string equipped = warrior.items[i].IsEquipped == true ? "[장착됨] " : "[장착안됨] ";
                        Console.WriteLine("- " + equipped + warrior.items[i].Name + "   | 공격력: " + warrior.items[i].Str + "   | 방어력: " + warrior.items[i].Def + "   | " + warrior.items[i].Description + "   | " + warrior.items[i].Gold + "G");
                    }
                }
                Console.WriteLine();

                inventoryStage.Choice();
                while (true)
                {
                    string choice1 = Console.ReadLine();
                    if (choice1 == "1")
                    {
                        // 장착 관리 스테이지 나와야됨
                        Console.Clear();
                        equipmentStage.Info();

                        ShowItems();// 보유 중인 아이템 목록 보여주는 메서드
                        Console.WriteLine("원하시는 행동의 번호를 입력해주세요.(아이템 목록에 해당하는 번호를 입력하여 장착할 수 있습니다.)");
                        Console.Write(">> ");
                        while (true)
                        {
                            string choice2 = Console.ReadLine();
                            if (choice2 == "1")
                            {
                                if (warrior.items[0] != null)
                                {
                                    if (warrior.items[0].Str > 0)
                                    {
                                        JudgeAtkType();
                                    }
                                    else
                                    {
                                        JudgeDefType();
                                    }
                                    warrior.items[0].IsEquipped = true;
                                    Console.Clear();
                                    equipmentStage.Info();
                                    ShowItems();// 보유 중인 아이템 목록 보여주는 메서드
                                    Console.WriteLine("원하시는 행동의 번호를 입력해주세요.(아이템 목록에 해당하는 번호를 입력하여 장착할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("잘못 입력했습니다.");
                                }
                            }
                            else if (choice2 == "2")
                            {
                                if (warrior.items[1] != null)
                                {
                                    if (warrior.items[1].Str > 0)
                                    {
                                        JudgeAtkType();
                                    }
                                    else
                                    {
                                        JudgeDefType();
                                    }
                                    warrior.items[1].IsEquipped = true;
                                    Console.Clear();
                                    equipmentStage.Info();
                                    ShowItems();// 보유 중인 아이템 목록 보여주는 메서드
                                    Console.WriteLine("아이템을 장착했습니다.");
                                    Console.WriteLine("원하시는 행동의 번호를 입력해주세요.(아이템 목록에 해당하는 번호를 입력하여 장착할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("잘못 입력했습니다.");
                                }
                            }
                            else if (choice2 == "3")
                            {
                                if (warrior.items[2] != null)
                                {
                                    if (warrior.items[2].Str > 0)
                                    {
                                        JudgeAtkType();
                                    }
                                    else
                                    {
                                        JudgeDefType();
                                    }
                                    warrior.items[2].IsEquipped = true;
                                    Console.Clear();
                                    equipmentStage.Info();
                                    ShowItems();// 보유 중인 아이템 목록 보여주는 메서드
                                    Console.WriteLine("원하시는 행동의 번호를 입력해주세요.(아이템 목록에 해당하는 번호를 입력하여 장착할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("잘못 입력했습니다.");
                                }
                            }
                            else if (choice2 == "4")
                            {
                                if (warrior.items[3] != null)
                                {
                                    if (warrior.items[3].Str > 0)
                                    {
                                        JudgeAtkType();
                                    }
                                    else
                                    {
                                        JudgeDefType();
                                    }
                                    warrior.items[3].IsEquipped = true;
                                    Console.Clear();
                                    equipmentStage.Info();
                                    ShowItems();// 보유 중인 아이템 목록 보여주는 메서드
                                    Console.WriteLine("원하시는 행동의 번호를 입력해주세요.(아이템 목록에 해당하는 번호를 입력하여 장착할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("잘못 입력했습니다.");
                                }
                            }
                            else if (choice2 == "0")
                            {
                                Console.Clear();
                                inventoryStage.Info();

                                // 보유 중인 아이템 목록 나와야함
                                if (warrior.items.Count == 0)
                                {
                                    Console.WriteLine("보유 중인 아이템이 없습니다.");
                                }
                                else
                                {
                                    for (int i = 0; i < warrior.items.Count; i++)
                                    {
                                        string equipped = warrior.items[i].IsEquipped == true ? "[장착됨] " : "[장착안됨] ";
                                        Console.WriteLine("- " + equipped + warrior.items[i].Name + "   | 공격력: " + warrior.items[i].Str + "   | 방어력: " + warrior.items[i].Def + "   | " + warrior.items[i].Description + "   | " + warrior.items[i].Gold + "G");
                                    }
                                }
                                Console.WriteLine();

                                inventoryStage.Choice();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못 입력했습니다.");
                                Console.Write(">> ");
                            }
                        }
                    }
                    else if (choice1 == "2")
                    {
                        Console.Clear();
                        startStage.Info();
                        startStage.Choice();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력했습니다.");
                        Console.Write(">> ");
                    }
                }
            }
            else if (choice == "3")
            {
                // 상점 스테이지
                Console.Clear();
                storeStage.Info();

                // 아이템 목록 나열
                Console.WriteLine("[아이템 목록]");
                foreach (IItem item in itemList)
                {
                    Console.WriteLine("- " + item.Name + "   | 공격력: " + item.Str + "   | 방어력: " + item.Def + "   | " + item.Description + "   | " + item.Gold + "G");
                }
                Console.WriteLine();

                storeStage.Choice();
                while (true)
                {
                    string choice1 = Console.ReadLine();
                    if (choice1 == "1")
                    {
                        // 아이템 구매 스테이지로 넘어가야 됨
                        Console.Clear();
                        buyItemStage.Info();

                        // 아이템 목록 나열하고 해당 번호 누르면 구매 가능
                        Console.WriteLine("[아이템 목록]");
                        for (int i = 1; i <= itemList.Count; i++)
                        {
                            Console.WriteLine(i + ". " + itemList[i - 1].Name + "   | 공격력: " + itemList[i - 1].Str + "   | 방어력: " + itemList[i - 1].Def + "   | " + itemList[i - 1].Description + "   | " + itemList[i - 1].Gold + "G");
                        }
                        Console.WriteLine();
                        Console.WriteLine("보유 골드: " + warrior.gold);
                        Console.WriteLine();
                        buyItemStage.Choice();
                        Console.WriteLine("원하시는 행동의 번호를 입력해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                        Console.Write(">> ");
                        while (true)
                        {
                            string choice2 = Console.ReadLine();
                            if (choice2 == "1")
                            {
                                // 아이템 구매 = 보유 아이템에 추가
                                if (warrior.gold >= oldSword.Gold)
                                {
                                    warrior.items.Add(oldSword);
                                    oldSword.IsHave = true;
                                    warrior.gold -= oldSword.Gold;
                                    Console.Clear();
                                    buyItemStage.Info();

                                    // 아이템 목록 나열하고 해당 번호 누르면 구매 가능
                                    Console.WriteLine("[아이템 목록]");
                                    for (int i = 1; i <= itemList.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + itemList[i - 1].Name + "   | 공격력: " + itemList[i - 1].Str + "   | 방어력: " + itemList[i - 1].Def + "   | " + itemList[i - 1].Description + "   | " + itemList[i - 1].Gold + "G");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("보유 골드: " + warrior.gold);
                                    Console.WriteLine();
                                    buyItemStage.Choice();
                                    Console.WriteLine("낡은 검을 구매했습니다!");
                                    Console.WriteLine("원하시는 행동의 번호를 입력해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("골드가 부족합니다.");
                                    Console.WriteLine("원하시는 행동의 번호를 선택해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                            }
                            else if (choice2 == "2")
                            {
                                if (warrior.gold >= spartanSpear.Gold)
                                {
                                    warrior.items.Add(spartanSpear);
                                    spartanSpear.IsHave = true;
                                    warrior.gold -= spartanSpear.Gold;
                                    Console.Clear();
                                    buyItemStage.Info();

                                    // 아이템 목록 나열하고 해당 번호 누르면 구매 가능
                                    Console.WriteLine("[아이템 목록]");
                                    for (int i = 1; i <= itemList.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + itemList[i - 1].Name + "   | 공격력: " + itemList[i - 1].Str + "   | 방어력: " + itemList[i - 1].Def + "   | " + itemList[i - 1].Description + "   | " + itemList[i - 1].Gold + "G");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("보유 골드: " + warrior.gold);
                                    Console.WriteLine();
                                    buyItemStage.Choice();
                                    Console.WriteLine("스파르타의 창을 구매했습니다!");
                                    Console.WriteLine("원하시는 행동의 번호를 선택해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("골드가 부족합니다.");
                                    Console.WriteLine("원하시는 행동의 번호를 선택해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                            }
                            else if (choice2 == "3")
                            {
                                if (warrior.gold >= noviceArmor.Gold)
                                {
                                    warrior.items.Add(noviceArmor);
                                    noviceArmor.IsHave = true;
                                    warrior.gold -= noviceArmor.Gold;
                                    Console.Clear();
                                    buyItemStage.Info();

                                    // 아이템 목록 나열하고 해당 번호 누르면 구매 가능
                                    Console.WriteLine("[아이템 목록]");
                                    for (int i = 1; i <= itemList.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + itemList[i - 1].Name + "   | 공격력: " + itemList[i - 1].Str + "   | 방어력: " + itemList[i - 1].Def + "   | " + itemList[i - 1].Description + "   | " + itemList[i - 1].Gold + "G");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("보유 골드: " + warrior.gold);
                                    Console.WriteLine();
                                    buyItemStage.Choice();
                                    Console.WriteLine("수련자의 갑옷을 구매했습니다!");
                                    Console.WriteLine("원하시는 행동의 번호를 선택해주세요(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.).");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("골드가 부족합니다.");
                                    Console.WriteLine("원하시는 행동의 번호를 선택해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                            }
                            else if (choice2 == "4")
                            {
                                if (warrior.gold >= spartanArmor.Gold)
                                {
                                    warrior.items.Add(spartanArmor);
                                    spartanArmor.IsHave = true;
                                    warrior.gold -= spartanArmor.Gold;
                                    Console.Clear();
                                    buyItemStage.Info();

                                    // 아이템 목록 나열하고 해당 번호 누르면 구매 가능
                                    Console.WriteLine("[아이템 목록]");
                                    for (int i = 1; i <= itemList.Count; i++)
                                    {
                                        Console.WriteLine(i + ". " + itemList[i - 1].Name + "   | 공격력: " + itemList[i - 1].Str + "   | 방어력: " + itemList[i - 1].Def + "   | " + itemList[i - 1].Description + "   | " + itemList[i - 1].Gold + "G");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("보유 골드: " + warrior.gold);
                                    Console.WriteLine();
                                    buyItemStage.Choice();
                                    Console.WriteLine("스파르타의 갑옷을 구매했습니다!");
                                    Console.WriteLine("원하시는 행동의 번호를 선택해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                                else
                                {
                                    Console.WriteLine("골드가 부족합니다.");
                                    Console.WriteLine("원하시는 행동의 번호를 선택해주세요.(아이템 목록에 해당하는 번호를 입력하여 구매할 수 있습니다.)");
                                    Console.Write(">> ");
                                }
                            }
                            else if (choice2 == "5")
                            {
                                // 나가기
                                Console.Clear();

                                // 아이템 스테이지 다시 보여주기
                                storeStage.Info();

                                // 아이템 목록 나열
                                Console.WriteLine("[아이템 목록]");
                                foreach (IItem item in itemList)
                                {
                                    Console.WriteLine("- " + item.Name + "   | 공격력: " + item.Str + "   | 방어력: " + item.Def + "   | " + item.Description + "   | " + item.Gold + "G");
                                }
                                Console.WriteLine();

                                storeStage.Choice();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못 입력했습니다.");
                                Console.Write(">> ");
                            }
                        }
                    }
                    else if (choice1 == "2")
                    {
                        Console.Clear();
                        startStage.Info();
                        startStage.Choice();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력했습니다.");
                        Console.Write(">> ");
                    }
                }
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                Console.Write(">> ");
            }
        }

        // 보유 아이템 보여주는 메서드
        void ShowItems()
        {
            if (warrior.items.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < warrior.items.Count; i++)
                {
                    string equipped = warrior.items[i].IsEquipped == true ? "[장착됨] " : "[장착안됨] ";
                    Console.WriteLine($"- {i + 1}. " + equipped + warrior.items[i].Name + "   | 공격력: " + warrior.items[i].Str + "   | 방어력: " + warrior.items[i].Def + "   | " + warrior.items[i].Description + "   | " + warrior.items[i].Gold + "G");
                }
            }
            Console.WriteLine();
            equipmentStage.Choice();
        }

        void JudgeAtkType()
        {
            if (oldSword.IsEquipped || spartanSpear.IsEquipped)
            {
                oldSword.IsEquipped = false;
                spartanSpear.IsEquipped = false;
            }
        }

        void JudgeDefType()
        {
            if (noviceArmor.IsEquipped || spartanArmor.IsEquipped)
            {
                noviceArmor.IsEquipped = false;
                spartanArmor.IsEquipped = false;
            }
        }
    }
}

// 스테이지 인터페이스
public interface IStage
{
    public string Title { get; }
    public string Description { get; }
    public List<string> Choices { get; }

    // 스테이지 설명해주는 메서드
    public void Info();

    // 선택지 보여주는 메서드
    public void Choice();

    // 선택하는 메서드

}

// 시작 스테이지 클래스
public class StartStage : IStage
{
    public string Title { get; } = "스파르타 마을에 오신 여러분 환영합니다.";
    public string Description { get; } = "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.";
    public List<string> Choices { get; } = new List<string>() { "상태 보기", "인벤토리", "상점" };

    // 스테이지 설명 메서드
    public void Info()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Description);
        Console.WriteLine();
    }

    // 선택지 보여주는 메서드
    public void Choice()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + Choices[i]);
        }
        Console.WriteLine();
        Console.WriteLine("원하시는 행동의 번호를 입력해주세요.");
        Console.Write(">> ");
    }
}

// 상태보기 스테이지 클래스
public class StateStage : IStage
{
    public string Title { get; } = "상태 보기";
    public string Description { get; } = "캐릭터의 정보가 표시됩니다.";
    public List<string> Choices { get; } = new List<string>() { "나가기" };

    // 스테이지 설명 메서드
    public void Info()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Description);
        Console.WriteLine();
    }

    // 선택지 보여주는 메서드
    public void Choice()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + Choices[i]);
        }
        Console.WriteLine();
        Console.WriteLine("원하시는 행동의 번호를 입력해주세요.");
        Console.Write(">> ");
    }
}

// 인벤토리 스테이지
public class InventoryStage : IStage
{
    public string Title { get; } = "인벤토리";
    public string Description { get; } = "보유 중인 아이템을 관리할 수 있습니다.";
    public List<string> Choices { get; } = new List<string> { "장착 관리", "나가기" };

    public void Info()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Description);
        Console.WriteLine();
    }

    public void Choice()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + Choices[i]);
        }
        Console.WriteLine();
        Console.WriteLine("원하시는 행동의 번호를 입력해주세요.");
        Console.Write(">> ");
    }
}

// 상점 스테이지
public class StoreStage : IStage
{
    public string Title { get; } = "상점";
    public string Description { get; } = "필요한 아이템을 얻을 수 있는 상점입니다.";
    public List<string> Choices { get; } = new List<string> { "아이템 구매", "나가기" };

    // 스테이지 설명해주는 메서드
    public void Info()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Description);
        Console.WriteLine();
    }

    // 선택지 보여주는 메서드
    public void Choice()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + Choices[i]);
        }
        Console.WriteLine();
        Console.WriteLine("원하시는 행동의 번호를 입력해주세요.");
        Console.Write(">> ");
    }
}

// 아이템 구매 스테이지
public class BuyItemStage : IStage
{
    public string Title { get; } = "상점 - 아이템 구매";
    public string Description { get; } = "필요한 아이템을 얻을 수 있는 상점입니다.";
    public List<string> Choices { get; } = new List<string> { "나가기" };

    // 스테이지 설명해주는 메서드
    public void Info()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Description);
        Console.WriteLine();
    }

    // 선택지 보여주는 메서드
    public void Choice()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine(i + 5 + ". " + Choices[i]);
        }
        Console.WriteLine();
    }
}

// 장착 관리 스테이지
public class EquipmentStage : IStage
{
    public string Title { get; } = "인벤토리 - 장착 관리";
    public string Description { get; } = "보유 중인 아이템을 관리할 수 있습니다.";
    public List<string> Choices { get; } = new List<string> { "나가기" };

    // 스테이지 설명해주는 메서드
    public void Info()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Description);
        Console.WriteLine();
    }

    // 선택지 보여주는 메서드
    public void Choice()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Console.WriteLine(i + ". " + Choices[i]);
        }
        Console.WriteLine();
    }
}



// 캐릭터 객체를 만들기 위한 캐릭터 클래스
public class Warrior
{
    public int lv = 1;
    public string Chad { get; } = "전사";
    public int str = 10;
    public int def = 5;
    public int hp = 100;
    public int gold = 3500;
    public List<IItem> items = new List<IItem>(); // 보유 중인 아이템 리스트

    public void StateInfo()
    {
        Console.WriteLine("Lv." + lv);
        Console.WriteLine("직업: " + Chad);
        Console.WriteLine("공격력: " + str);
        Console.WriteLine("방어력: " + def);
        Console.WriteLine("체력: " + hp);
        Console.WriteLine("Gold: " + gold);
        Console.WriteLine();
    }
}



// 아이템 객체를 만들기 위한 인터페이스
public interface IItem
{
    public string Name { get; }
    public string Description { get; }
    public int Def { get; }
    public int Str { get; }
    public int Gold { get; }
    public bool IsHave { get; set; }
    public bool IsEquipped { get; set; }
}

// 낡은 검 클래스
public class OldSword : IItem
{
    public string Name { get; } = "낡은 검";
    public string Description { get; } = "쉽게 볼 수 있는 낡은 검입니다.";
    public int Def { get; } = 0;
    public int Str { get; } = 3;
    public int Gold { get; } = 1000;
    public bool IsHave { get; set; }
    public bool IsEquipped { get; set; }
}

// 스파르타의 창 클래스
public class SpartanSpear : IItem
{
    public string Name { get; } = "스파르타의 창";
    public string Description { get; } = "스파르타의 전사들이 사용한 전설의 창입니다.";
    public int Def { get; } = 0;
    public int Str { get; } = 8;
    public int Gold { get; } = 2000;
    public bool IsHave { get; set; }
    public bool IsEquipped { get; set; }
}

// 수련자의 갑옷 클래스
public class NoviceArmor : IItem
{
    public string Name { get; } = "수련자의 갑옷";
    public string Description { get; } = "수련자의 갑옷 수련에 도움을 주는 갑옷입니다.";
    public int Def { get; } = 5;
    public int Str { get; } = 0;
    public int Gold { get; } = 1000;
    public bool IsHave { get; set; }
    public bool IsEquipped { get; set; }
}

// 무쇠 갑옷
public class SpartanArmor : IItem
{
    public string Name { get; } = "스파르타의 갑옷";
    public string Description { get; } = "스파르타의 전사들이 사용한 전설의 갑옷입니다.";
    public int Def { get; } = 10;
    public int Str { get; } = 0;
    public int Gold { get; } = 2000;
    public bool IsHave { get; set; }
    public bool IsEquipped { get; set; }
}