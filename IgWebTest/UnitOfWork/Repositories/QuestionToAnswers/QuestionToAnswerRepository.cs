using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.QuestionToAnswers
{
    internal class QuestionToAnswerRepository : BaseRepository, IQuestionToAnswerRepository
    {
        public QuestionToAnswerRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
