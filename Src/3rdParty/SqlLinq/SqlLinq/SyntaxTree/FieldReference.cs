
namespace SqlLinq.SyntaxTree
{
    class FieldReference
    {
        public FieldReference()
        {
        }

        public string SourceId { get; set; }

        public string EvaluationId { get; set; }

        public string Alias { get; set; }
    
        public string LookupId { get; set; }
    }
}
