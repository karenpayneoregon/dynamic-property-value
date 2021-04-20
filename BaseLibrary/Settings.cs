using System;

namespace BaseLibrary
{
    public class Settings
    {
        public string UserName { get; set; }
        public int ContactIdentifier { get; set; }
        public MemberType MemberType { get; set; }
        public bool Active { get; set; }
        public DateTime Joined { get; set; }
    }
}
