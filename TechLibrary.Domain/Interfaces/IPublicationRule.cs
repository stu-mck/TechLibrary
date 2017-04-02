﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Domain.Interfaces
{
    public interface IPublicationRule
    { 
   
        string RuleName { get; }

        bool EvaluateRule(IEntity entity);
    }
}