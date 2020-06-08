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

    public enum Places
    {
        Bar = 1,
        Cafe = 2, 
        Cinema = 3,
        Park = 4,
        City = 5
    }
    public enum DistanceType
    {
        InPlace = 0,
        Low = 1,
        Medium = 2,
        Large = 3
    }

    public enum RandomSkill
    {
        Reach = 0,
        Happy = 1,
        Strong = 2
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
    [Serializable]
    public class Player
    {
        public Player()
        {
            Theory = 0;
            Practic = 0;
            TeacherRaiting = 20;
            Money = 2500;
            Happines = 60;
            Power = 60;
            FriendsRaiting = 50;
            FollowerRaiting = 50;
            hasFollower = true;
            isDrunk = false;
            DistanceFromHome = DistanceType.InPlace;
            DistanceFromUniver = DistanceType.Medium;
            Labs.Add(new Laba(true));
            Labs.Add(new Laba(true));
            Labs.Add(new Laba(true));
            CurrentLaba = Labs[0];
        }

        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public uint Theory { get; set; }
        public uint Practic { get; set; }
        public double TeacherRaiting { get; protected set; }
        public double Money { get; protected set; }
        public double Happines { get; protected set; }
        public double Power { get; protected set; }
        public bool hasFollower { get; private set; }
        public double FriendsRaiting { get; protected set; }
        public double FollowerRaiting { get; protected set; }
        public bool isDrunk { get; protected set; }
        public bool hasJob { get; set; } = false;
        public DistanceType DistanceFromHome{ get; set; }
        public DistanceType DistanceFromUniver{ get; set; }
        public PlaceType Place { get; set; }
        public RandomSkill RandomSkill { get; set; } = RandomSkill.Strong;
        public Places PlaceDescription { get; set; }
        public CompanyType Company { get; set; }
        public Laba  CurrentLaba { get; set; }
        public uint LabMarks { get; set; } = 0;
        public int DrunkLevel { get; set; } = 0;
        public int WorkTiles { get; set; } = 0;
        public int AssignedWork { get; set; } = 0;
        public List<Laba> Labs { get; set; } = new List<Laba>();
        public int CountLabs
        {
            get => Labs.Where(x => x.Own).Where(x => x.Passed).Count();
        }

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
                    return $"Слава богу, не знудило. {Name} повертається до життя, проте рівно стояти все ще не може.";
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
            double res = value < 0 ? value + value * this._power * 0.25 : value;
            this.Power += res;
        }
        public void ChangeHappines(int value)
        {
            this.Happines += value;
        }
        public void ChangeMoney(int value)
        {
            double res = value < 0 ? value + value * this._attention * 0.25 : value;
            this.Money += res;
        }
        public void ChangeFriendsRait(int value)
        {
            double res = value < 0 ? value + value * this._speek * 0.25 : value;
            this.FriendsRaiting += res;
        }
        public void ChangeFollowerRait(int value)
        {
            double res = value < 0 ? value + value * this._glamor * 0.25 : value;
            this.FollowerRaiting += res;
        }
        public void ChangeOP(int value)
        {
            double res = value < 0 ? value + value * this._intelligence * 0.25 : value;
            this.TeacherRaiting += res;
        }

        public bool IsOkWithLabs
        {
            get
            {
                return Labs.Where(x=>x.Own).Where(x => x.Ready == false).Count() > 0;
            }
        }

        public int _power; //ChangePower
        public int _attention; //ChangeMoney
        public int _glamor; //ChangeFollowerRait
        public int _agility; //Необхідно для екзаменів
        public int _intelligence; // ChangeOP
        public int _speek; //ChangeFriendsRait
    }
}

  