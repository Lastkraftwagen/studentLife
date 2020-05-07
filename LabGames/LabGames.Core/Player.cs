using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{

    public enum GenderType
    {
        Man = 1, Woman = 2
    }

    public enum PlaceType
    {
        Home = 1,
        Universitat = 2,
        Outside = 3,
        Place = 4
    }
    public enum DistanceType
    {
        Home = 0,
        Low = 1,
        Medium = 2,
        Large = 3
    }

    public enum CompanyType
    {
        Alone = 1,
        WithGF = 2,
        WithFriends = 3
    }
    [Flags]
    public enum ReasonsToDeath
    {
        None = 1,
        NoMoney = 2,
        NoHappy = 3,
        NoPower = 4
    }
    public class Player
    {
        public Player()
        {
            Theory = 0;
            Practic = 0;
            TeacherRaiting = 0;
            Money = 2500;
            Happines = 60;
            Power = 60;
            FriendsRaiting = 50;
            FollowerRaiting = 50;
            hasFollower = true;
            isDrunk = false;
        }

        public string Name { get; set; }
        public GenderType Gender { get; set; }


        public uint Theory { get; set; }
        public uint Practic { get; set; }
        public int TeacherRaiting { get; protected set; }
        public int Money { get; protected set; }
        public int Happines { get; protected set; }
        public int Power { get; protected set; }
        public bool hasFollower { get; private set; }
        public int FriendsRaiting { get; protected set; }
        public int FollowerRaiting { get; protected set; }
        public bool isDrunk { get; protected set; }
        public DistanceType DistanceFromHome{ get; set; }
        public PlaceType Place { get; set; }
        public CompanyType Company { get; set; }
        public uint LabMarks { get; set; } = 0;
        public uint CountLabs { get; set; } = 0;
        public int DrunkLevel { get; set; } = 0;

        public string GetDrunk(int value)
        {
            this.isDrunk = true;
            this.DrunkLevel+=value;
            switch (DrunkLevel)
            {
                case 1:
                    return $"{Name} відчуває алкогольне сп'яніння. Продуктивність знижено.";
                case 2:
                    return $"{Name} сильно напивається. Продуктивність значно знижено.";
                case 3:
                    return $"{Name} вже на грані. Треба зробити перерву, бо вже нудить.";
                default:
                    return $"{Name} втрачає свідомість від алкогольної інтоксикації.";
            }

        }

        public string ResetDrunk(int value)
        {
            this.DrunkLevel-=value;
            if (DrunkLevel < 0) DrunkLevel = 0;
            if (DrunkLevel == 0) this.isDrunk = false;
            switch (DrunkLevel)
            {
                case 0:
                    return $"{Name}  остаточно тверезіє. Продуктивність відновлена.";
                case 1:
                    string genderword = this.Gender == GenderType.Man ? "п'яненький" : "п'яненька";
                    return $"{Name} трохи тверезіє, але все ще {genderword}. Продуктивність покращена.";
                case 2:
                    return $"Слава богу, не знудило. {Name} повертається до життя, проте ровно стояти все ще не може.";
                default:
                    return $"Бяліь не трабв будо так наждватисюю....";
            }
        }

        public ReasonsToDeath IsWantToLive()
        {
            if (Money < 0) return ReasonsToDeath.NoMoney;
            if (Happines < 0) return ReasonsToDeath.NoHappy;
            if (Power < 0) return ReasonsToDeath.NoPower;
            return ReasonsToDeath.None;
        }

        public void ChangePower(int value)
        {
            this.Power += value;
        }
        public void ChangeHappines(int value)
        {
            this.Happines += value;
        }
        public void ChangeMoney(int value)
        {
            this.Money += value;
        }
        public void ChangeFriendsRait(int value)
        {
            this.FriendsRaiting += value;
        }
        public void ChangeFollowerRait(int value)
        {
            this.FollowerRaiting += value;
        }
        public void ChangeOP(int value)
        {
            this.TeacherRaiting += value;
        }

        public bool isLabaReady = false;

        public int _power;
        public int _agility;
        public int _intelligence;
        public int _speek;
        public int _attention;
        public int _glamor;

    }
}

  