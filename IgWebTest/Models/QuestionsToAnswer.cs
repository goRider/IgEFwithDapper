using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class QuestionsToAnswer
    {
        public int QuestionAnswerId { get; set; }
        public string FirstPreQualQuestion { get; set; }
        public string FirstPreQualAnswer { get; set; }
        public string SecondPreQualQuestion { get; set; }
        public string SecondPreQualAnswer { get; set; }
        public string ThirdPreQualQuestion { get; set; }
        public string ThirdPreQualAnswer { get; set; }
        public string FourthPreQualQuestion { get; set; }
        public string FourthPreQualAnswer { get; set; }
        public string FifthPreQualQuestion { get; set; }
        public bool FifthPreQualAnswer { get; set; }
        public string SixthPreQualQuestion { get; set; }
        public bool SixthPreQualAnswer { get; set; }
        public string FirstQualQuestion { get; set; }
        public string FirstQualAnswer { get; set; }
        public string SecondQualQuestion { get; set; }
        public string SecondQualAnswer { get; set; }
        public string ThirdQualQuestion { get; set; }
        public string ThirdQualAnswer { get; set; }
        public string FourthQualQuestion { get; set; }
        public string FourthQualAnswer { get; set; }
        public DateTime? CompletePreQualificationQuestionsDate { get; set; }
        public DateTime? CompleteQualificationQuestionsDate { get; set; }
        public int FkIgniteApplicationId { get; set; }

        public virtual IgniteUserApplication FkIgniteApplication { get; set; }
    }
}
