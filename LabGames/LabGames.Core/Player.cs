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
        public bool IsDrunk { get; set; }
        //TODO: ???
        public PlaceType Place { get; set; }
        public CompanyType Company { get; set; }
        public uint LabMarks { get; set; } = 0;
        public uint CountLabs { get; set; } = 0;
        
    }
}
