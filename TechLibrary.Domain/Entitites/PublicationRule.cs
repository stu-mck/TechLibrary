using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Interfaces;

namespace TechLibrary.Domain.Entitites
{
    public class PublicationRule
    {
        public Guid RuleId { get; set; }

        public string   RuleName { get; set; }

        public bool EvaluateRule(IEntity entity)
        {
            return true;
        }
    }
}
