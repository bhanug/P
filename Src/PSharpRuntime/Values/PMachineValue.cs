﻿using Microsoft.Coyote.Machines;
using System.Collections.Generic;
using System.Linq;

namespace Plang.PrtSharp.Values
{
    public class I_Main : PMachineValue
    {
        public I_Main(MachineId machine, List<string> permissions) : base(machine, permissions)
        {
        }
    }

    public class PMachineValue : IPrtValue
    {
        public PMachineValue(MachineId machine, List<string> permissions)
        {
            Id = machine;
            Permissions = permissions.ToList();
        }

        public PMachineValue(PMachineValue mValue)
        {
            Id = mValue.Id;
            Permissions = mValue.Permissions.ToList();
        }

        public MachineId Id { get; }
        public List<string> Permissions { get; }

        public bool Equals(IPrtValue other)
        {
            return other is PMachineValue machine && Equals(Id, machine.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public IPrtValue Clone()
        {
            return new PMachineValue(Id, new List<string>(Permissions));
        }

        public override string ToString()
        {
            return Id.Name.Split('.').Last();
        }
    }
}