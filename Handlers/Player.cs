using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;

namespace HelloMyNameIs.Handlers
{
    public class Player
    {
        public List<string> names = null;
        public List<string> usedNames = null;
        public Dictionary<int, string> scps = new Dictionary<int, string>();
        Random rnd = new Random();

        public void OnLeft(LeftEventArgs ev)
        {
            if (Plugin.Instance.Config.CanRepeat) return;
            if (usedNames.Contains(ev.Player.DisplayNickname))
            {
                usedNames.Remove(ev.Player.DisplayNickname);
                if (!usedNames.Contains(ev.Player.DisplayNickname)) // In case the names were used more than once
                {
                    names.Add(ev.Player.DisplayNickname);
                }
            }
        }

        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.RoleType.GetTeam() == Team.SCP)
            {
                bool wasSCP = scps.ContainsKey(ev.Player.Id);
                if (!wasSCP) scps.Add(ev.Player.Id, ev.Player.DisplayNickname);
                string name = "";
                switch (ev.RoleType)
                {
                    case RoleType.Scp173:
                        name = Plugin.Instance.Config.Scp173Name;
                        break;

                    case RoleType.Scp106:
                        name = Plugin.Instance.Config.Scp106Name;
                        break;

                    case RoleType.Scp049:
                        name = Plugin.Instance.Config.Scp049Name;
                        break;

                    case RoleType.Scp0492:
                        name = Plugin.Instance.Config.Scp0492Name.Replace("{name}", GetRandomName());
                        break;

                    case RoleType.Scp079:
                        name = Plugin.Instance.Config.Scp079Name;
                        break;

                    case RoleType.Scp096:
                        name = Plugin.Instance.Config.Scp096Name;
                        break;

                    case RoleType.Scp93989:
                        name = Plugin.Instance.Config.Scp939_89Name;
                        break;

                    case RoleType.Scp93953:
                        name = Plugin.Instance.Config.Scp939_53Name;
                        break;
                }

                ev.Player.DisplayNickname = name;
            }
            else if (scps.ContainsKey(ev.Player.Id) && ev.RoleType != RoleType.Spectator && ev.RoleType != RoleType.Tutorial)
            {
                ev.Player.DisplayNickname = scps[ev.Player.Id];
                scps.Remove(ev.Player.Id);
                if (names == null && !Plugin.Instance.Config.CanRepeat)
                {
                    usedNames = new List<string>();
                }
                if (names == null || names.Count == 0) names = new List<string>(Plugin.Instance.Config.Names);
                string name = names[rnd.Next(names.Count)];
                if (!Plugin.Instance.Config.CanRepeat)
                {
                    names.Remove(name);
                    usedNames.Add(name);
                }
                ev.Player.DisplayNickname = name;
            }
            else if (ev.RoleType != RoleType.Spectator && ev.RoleType != RoleType.Tutorial)
            {
                if (names == null && !Plugin.Instance.Config.CanRepeat)
                {
                    usedNames = new List<string>();
                }
                if (names == null || names.Count == 0) names = new List<string>(Plugin.Instance.Config.Names);
                string name = names[rnd.Next(names.Count)];
                if (!Plugin.Instance.Config.CanRepeat)
                {
                    names.Remove(name);
                    usedNames.Add(name);
                }
                ev.Player.DisplayNickname = name;
            }
            else if (ev.RoleType == RoleType.Spectator || ev.RoleType == RoleType.Tutorial)
            {
                string name = ev.Player.DisplayNickname;
                if (!Plugin.Instance.Config.CanRepeat)
                {
                    usedNames.Remove(name);
                    if (!usedNames.Contains(name)) // In case the names were used more than once
                    {
                        names.Add(ev.Player.DisplayNickname);
                    }
                }
                ev.Player.DisplayNickname = null;
            }
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole.GetTeam() == Team.SCP)
            {
                bool wasSCP = scps.ContainsKey(ev.Player.Id);
                if (!wasSCP) scps.Add(ev.Player.Id, ev.Player.DisplayNickname);
                string name = "";
                switch (ev.NewRole)
                {
                    case RoleType.Scp173:
                        name = Plugin.Instance.Config.Scp173Name;
                        break;

                    case RoleType.Scp106:
                        name = Plugin.Instance.Config.Scp106Name;
                        break;

                    case RoleType.Scp049:
                        name = Plugin.Instance.Config.Scp049Name;
                        break;

                    case RoleType.Scp0492:
                        name = Plugin.Instance.Config.Scp0492Name.Replace("{name}", GetRandomName());
                        break;

                    case RoleType.Scp079:
                        name = Plugin.Instance.Config.Scp079Name;
                        break;

                    case RoleType.Scp096:
                        name = Plugin.Instance.Config.Scp096Name;
                        break;

                    case RoleType.Scp93989:
                        name = Plugin.Instance.Config.Scp939_89Name;
                        break;

                    case RoleType.Scp93953:
                        name = Plugin.Instance.Config.Scp939_53Name;
                        break;
                }

                ev.Player.DisplayNickname = name;
            }
            else if (scps.ContainsKey(ev.Player.Id) && ev.NewRole != RoleType.Spectator && ev.NewRole != RoleType.Tutorial)
            {
                ev.Player.DisplayNickname = scps[ev.Player.Id];
                scps.Remove(ev.Player.Id);
                if (names == null && !Plugin.Instance.Config.CanRepeat)
                {
                    usedNames = new List<string>();
                }
                if (names == null || names.Count == 0) names = new List<string>(Plugin.Instance.Config.Names);
                string name = names[rnd.Next(names.Count)];
                if (!Plugin.Instance.Config.CanRepeat)
                {
                    names.Remove(name);
                    usedNames.Add(name);
                }
                ev.Player.DisplayNickname = name;
            } 
            else if (ev.NewRole != RoleType.Spectator && ev.NewRole != RoleType.Tutorial)
            {
                if (names == null && !Plugin.Instance.Config.CanRepeat)
                {
                    usedNames = new List<string>();
                }
                if (names == null || names.Count == 0) names = new List<string>(Plugin.Instance.Config.Names);
                string name = names[rnd.Next(names.Count)];
                if (!Plugin.Instance.Config.CanRepeat)
                {
                    names.Remove(name);
                    usedNames.Add(name);
                }
                ev.Player.DisplayNickname = name;
            }
            else if(ev.NewRole == RoleType.Spectator || ev.NewRole == RoleType.Tutorial)
            {
                string name = ev.Player.DisplayNickname;
                if (!Plugin.Instance.Config.CanRepeat)
                {
                    usedNames.Remove(name);
                    if (!usedNames.Contains(name)) // In case the names were used more than once
                    {
                        names.Add(ev.Player.DisplayNickname);
                    }
                }
                ev.Player.DisplayNickname = null;
            }
        }

        public void OnDied(DiedEventArgs ev)
        {
            if (scps.ContainsKey(ev.Target.Id)) scps.Remove(ev.Target.Id);
            string name = ev.Target.DisplayNickname;
            if (!Plugin.Instance.Config.CanRepeat)
            {
                usedNames.Remove(name);
                if (!usedNames.Contains(name)) // In case the names were used more than once
                {
                    names.Add(ev.Target.DisplayNickname);
                }
            }
            ev.Target.DisplayNickname = null;
        }

        public string GetRandomName()
        {
            if (names == null && !Plugin.Instance.Config.CanRepeat)
            {
                usedNames = new List<string>();
            }
            if (names == null || names.Count == 0) names = new List<string>(Plugin.Instance.Config.Names);
            string name = names[rnd.Next(names.Count)];
            if (!Plugin.Instance.Config.CanRepeat)
            {
                names.Remove(name);
                usedNames.Add(name);
            }
            return name;
        }
    }
}
