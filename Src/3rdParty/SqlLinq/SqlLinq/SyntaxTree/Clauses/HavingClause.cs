
namespace SqlLinq.SyntaxTree.Clauses
{
    [SyntaxNode(RuleConstants.RULE_HAVINGCLAUSE_HAVING)]
    public class HavingClause : WhereClause
    {
        public HavingClause()
        {
        }

        internal override void CheckSyntax()
        {
        }
    }
}
