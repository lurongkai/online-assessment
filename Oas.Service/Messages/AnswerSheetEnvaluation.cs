using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Service.Messages
{
    public class AnswerSheetEnvaluation
    {
        public AnswerSheetEnvaluation()
        {
            Items = new List<AnswerSheetEvaluationItem>();
        }

        public IEnumerable<AnswerSheetEvaluationItem> Items { get; set; }
        internal int GetScore(Guid questionId)
        {
            var item = Items.SingleOrDefault(i => i.QuestionId == questionId);
            if (item == null)
            {
                return 0;
            }
            return item.Score;
        }
    }

    public class AnswerSheetEvaluationItem
    {
        public Guid QuestionId { get; set; }
        public int Score { get; set; }
    }
}
