using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeighted = false) : base(name)
        {
            Type = GradeBookType.Standard;
            IsWeighted = isWeighted;
        }
    }
}