using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public interface IAction
    {
        // everything in interface is public
        // only methods or properties

        void Cancel();
    }
}

