using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Rate
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Key { get; set; }

        public List<Rate> GetRates(DataAccess.Tables.ConditionAssessment conditionAssessment)
        {
            List<Rate> rates = new List<Rate>
            {
                new Rate()
                {
                    Value = conditionAssessment.RequiredPerformanceStandard,
                    Name = "Required Performance Standard",
                    Key = 1
                },

                new Rate()
                {
                    Value = conditionAssessment.AccessibilityRating,
                    Name = "Accessibility Rating",
                    Key = 2
                },

                new Rate()
                {
                    Value = conditionAssessment.ConditionRating,
                    Name = "Condition Rating",
                    Key = 3
                },

                new Rate()
                {
                    Value = conditionAssessment.SuitabilityIndex,
                    Name = "Suitability Index",
                    Key = 4
                },

                new Rate()
                {
                    Value = conditionAssessment.OperatingPerformanceIndex,
                    Name = "Operating Performance Index",
                    Key = 5
                },

                new Rate()
                {
                    Value = conditionAssessment.FunctionalPerformanceStandard,
                    Name = "Functional Performance Standard",
                    Key = 6
                }
            };

            return rates;
        }
    }
}
