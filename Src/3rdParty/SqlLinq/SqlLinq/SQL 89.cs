enum SymbolConstants : int
{
   SYMBOL_EOF            =  0, // (EOF)
   SYMBOL_ERROR          =  1, // (Error)
   SYMBOL_WHITESPACE     =  2, // (Whitespace)
   SYMBOL_COMMENTEND     =  3, // (Comment End)
   SYMBOL_COMMENTLINE    =  4, // (Comment Line)
   SYMBOL_COMMENTSTART   =  5, // (Comment Start)
   SYMBOL_MINUS          =  6, // '-'
   SYMBOL_EXCLAMEQ       =  7, // '!='
   SYMBOL_LPARAN         =  8, // '('
   SYMBOL_RPARAN         =  9, // ')'
   SYMBOL_TIMES          = 10, // '*'
   SYMBOL_COMMA          = 11, // ','
   SYMBOL_DIV            = 12, // '/'
   SYMBOL_PLUS           = 13, // '+'
   SYMBOL_LT             = 14, // '<'
   SYMBOL_LTEQ           = 15, // '<='
   SYMBOL_LTGT           = 16, // '<>'
   SYMBOL_EQ             = 17, // '='
   SYMBOL_GT             = 18, // '>'
   SYMBOL_GTEQ           = 19, // '>='
   SYMBOL_ALL            = 20, // ALL
   SYMBOL_AND            = 21, // AND
   SYMBOL_AS             = 22, // AS
   SYMBOL_ASC            = 23, // ASC
   SYMBOL_AVG            = 24, // Avg
   SYMBOL_BETWEEN        = 25, // BETWEEN
   SYMBOL_BOOLEANLITERAL = 26, // BooleanLiteral
   SYMBOL_BY             = 27, // BY
   SYMBOL_COUNT          = 28, // Count
   SYMBOL_DATELITERAL    = 29, // DateLiteral
   SYMBOL_DESC           = 30, // DESC
   SYMBOL_DISTINCT       = 31, // DISTINCT
   SYMBOL_FROM           = 32, // FROM
   SYMBOL_FUNCTION       = 33, // Function
   SYMBOL_GROUP          = 34, // GROUP
   SYMBOL_HAVING         = 35, // HAVING
   SYMBOL_ID             = 36, // Id
   SYMBOL_IN             = 37, // IN
   SYMBOL_INNER          = 38, // INNER
   SYMBOL_INTEGERLITERAL = 39, // IntegerLiteral
   SYMBOL_INTO           = 40, // INTO
   SYMBOL_IS             = 41, // IS
   SYMBOL_JOIN           = 42, // JOIN
   SYMBOL_LEFT           = 43, // LEFT
   SYMBOL_LIKE           = 44, // LIKE
   SYMBOL_MAX            = 45, // Max
   SYMBOL_MIN            = 46, // Min
   SYMBOL_NOT            = 47, // NOT
   SYMBOL_NULL           = 48, // NULL
   SYMBOL_ON             = 49, // ON
   SYMBOL_OR             = 50, // OR
   SYMBOL_ORDER          = 51, // ORDER
   SYMBOL_REALLITERAL    = 52, // RealLiteral
   SYMBOL_RIGHT          = 53, // RIGHT
   SYMBOL_SELECT         = 54, // SELECT
   SYMBOL_STDEV          = 55, // StDev
   SYMBOL_STDEVP         = 56, // StDevP
   SYMBOL_STRINGLITERAL  = 57, // StringLiteral
   SYMBOL_SUM            = 58, // Sum
   SYMBOL_VAR            = 59, // Var
   SYMBOL_VARP           = 60, // VarP
   SYMBOL_WHERE          = 61, // WHERE
   SYMBOL_ADDEXP         = 62, // <Add Exp>
   SYMBOL_AGGREGATE      = 63, // <Aggregate>
   SYMBOL_ANDEXP         = 64, // <And Exp>
   SYMBOL_COLUMNALIAS    = 65, // <Column Alias>
   SYMBOL_COLUMNITEM     = 66, // <Column Item>
   SYMBOL_COLUMNLIST     = 67, // <Column List>
   SYMBOL_COLUMNSOURCE   = 68, // <Column Source>
   SYMBOL_COLUMNS        = 69, // <Columns>
   SYMBOL_EXPRLIST       = 70, // <Expr List>
   SYMBOL_EXPRESSION     = 71, // <Expression>
   SYMBOL_FROMCLAUSE     = 72, // <From Clause>
   SYMBOL_GROUPCLAUSE    = 73, // <Group Clause>
   SYMBOL_HAVINGCLAUSE   = 74, // <Having Clause>
   SYMBOL_IDLIST         = 75, // <Id List>
   SYMBOL_IDMEMBER       = 76, // <Id Member>
   SYMBOL_INLIST         = 77, // <In List>
   SYMBOL_INTOCLAUSE     = 78, // <Into Clause>
   SYMBOL_JOIN2          = 79, // <Join>
   SYMBOL_JOINCHAIN      = 80, // <Join Chain>
   SYMBOL_MULTEXP        = 81, // <Mult Exp>
   SYMBOL_NEGATEEXP      = 82, // <Negate Exp>
   SYMBOL_NOTEXP         = 83, // <Not Exp>
   SYMBOL_ORDERCLAUSE    = 84, // <Order Clause>
   SYMBOL_ORDERLIST      = 85, // <Order List>
   SYMBOL_ORDERTYPE      = 86, // <Order Type>
   SYMBOL_PREDEXP        = 87, // <Pred Exp>
   SYMBOL_QUERY          = 88, // <Query>
   SYMBOL_RESTRICTION    = 89, // <Restriction>
   SYMBOL_SELECTSTM      = 90, // <Select Stm>
   SYMBOL_TUPLE          = 91, // <Tuple>
   SYMBOL_VALUE          = 92, // <Value>
   SYMBOL_VALUELIST      = 93, // <Value List>
   SYMBOL_WHERECLAUSE    = 94  // <Where Clause>
};

public enum RuleConstants : int
{
   RULE_QUERY                               =  0, // <Query> ::= <Select Stm>
   RULE_SELECTSTM_SELECT                    =  1, // <Select Stm> ::= SELECT <Columns> <Into Clause> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause>
   RULE_COLUMNS_TIMES                       =  2, // <Columns> ::= <Restriction> '*'
   RULE_COLUMNS                             =  3, // <Columns> ::= <Restriction> <Column List>
   RULE_COLUMNLIST_COMMA                    =  4, // <Column List> ::= <Column Item> ',' <Column List>
   RULE_COLUMNLIST                          =  5, // <Column List> ::= <Column Item>
   RULE_COLUMNITEM                          =  6, // <Column Item> ::= <Column Source>
   RULE_COLUMNSOURCE                        =  7, // <Column Source> ::= <Aggregate>
   RULE_COLUMNSOURCE_ID                     =  8, // <Column Source> ::= Id
   RULE_COLUMNSOURCE2                       =  9, // <Column Source> ::= <Aggregate> <Column Alias>
   RULE_COLUMNSOURCE_ID2                    = 10, // <Column Source> ::= Id <Column Alias>
   RULE_COLUMNALIAS_AS_ID                   = 11, // <Column Alias> ::= AS Id
   RULE_RESTRICTION_ALL                     = 12, // <Restriction> ::= ALL
   RULE_RESTRICTION_DISTINCT                = 13, // <Restriction> ::= DISTINCT
   RULE_RESTRICTION                         = 14, // <Restriction> ::= 
   RULE_AGGREGATE_COUNT_LPARAN_TIMES_RPARAN = 15, // <Aggregate> ::= Count '(' '*' ')'
   RULE_AGGREGATE_COUNT_LPARAN_RPARAN       = 16, // <Aggregate> ::= Count '(' <Expression> ')'
   RULE_AGGREGATE_AVG_LPARAN_RPARAN         = 17, // <Aggregate> ::= Avg '(' <Expression> ')'
   RULE_AGGREGATE_MIN_LPARAN_RPARAN         = 18, // <Aggregate> ::= Min '(' <Expression> ')'
   RULE_AGGREGATE_MAX_LPARAN_RPARAN         = 19, // <Aggregate> ::= Max '(' <Expression> ')'
   RULE_AGGREGATE_STDEV_LPARAN_RPARAN       = 20, // <Aggregate> ::= StDev '(' <Expression> ')'
   RULE_AGGREGATE_STDEVP_LPARAN_RPARAN      = 21, // <Aggregate> ::= StDevP '(' <Expression> ')'
   RULE_AGGREGATE_SUM_LPARAN_RPARAN         = 22, // <Aggregate> ::= Sum '(' <Expression> ')'
   RULE_AGGREGATE_VAR_LPARAN_RPARAN         = 23, // <Aggregate> ::= Var '(' <Expression> ')'
   RULE_AGGREGATE_VARP_LPARAN_RPARAN        = 24, // <Aggregate> ::= VarP '(' <Expression> ')'
   RULE_INTOCLAUSE_INTO_ID                  = 25, // <Into Clause> ::= INTO Id
   RULE_INTOCLAUSE                          = 26, // <Into Clause> ::= 
   RULE_FROMCLAUSE_FROM                     = 27, // <From Clause> ::= FROM <Id List> <Join Chain>
   RULE_JOINCHAIN                           = 28, // <Join Chain> ::= <Join> <Join Chain>
   RULE_JOINCHAIN2                          = 29, // <Join Chain> ::= 
   RULE_JOIN_INNER_JOIN_ON_ID_EQ_ID         = 30, // <Join> ::= INNER JOIN <Id List> ON Id '=' Id
   RULE_JOIN_LEFT_JOIN_ON_ID_EQ_ID          = 31, // <Join> ::= LEFT JOIN <Id List> ON Id '=' Id
   RULE_JOIN_RIGHT_JOIN_ON_ID_EQ_ID         = 32, // <Join> ::= RIGHT JOIN <Id List> ON Id '=' Id
   RULE_JOIN_JOIN_ON_ID_EQ_ID               = 33, // <Join> ::= JOIN <Id List> ON Id '=' Id
   RULE_WHERECLAUSE_WHERE                   = 34, // <Where Clause> ::= WHERE <Expression>
   RULE_WHERECLAUSE                         = 35, // <Where Clause> ::= 
   RULE_GROUPCLAUSE_GROUP_BY                = 36, // <Group Clause> ::= GROUP BY <Id List>
   RULE_GROUPCLAUSE                         = 37, // <Group Clause> ::= 
   RULE_ORDERCLAUSE_ORDER_BY                = 38, // <Order Clause> ::= ORDER BY <Order List>
   RULE_ORDERCLAUSE                         = 39, // <Order Clause> ::= 
   RULE_ORDERLIST_ID_COMMA                  = 40, // <Order List> ::= Id <Order Type> ',' <Order List>
   RULE_ORDERLIST_ID                        = 41, // <Order List> ::= Id <Order Type>
   RULE_ORDERLIST_FUNCTION                  = 42, // <Order List> ::= Function <Order Type>
   RULE_ORDERTYPE_ASC                       = 43, // <Order Type> ::= ASC
   RULE_ORDERTYPE_DESC                      = 44, // <Order Type> ::= DESC
   RULE_ORDERTYPE                           = 45, // <Order Type> ::= 
   RULE_HAVINGCLAUSE_HAVING                 = 46, // <Having Clause> ::= HAVING <Expression>
   RULE_HAVINGCLAUSE                        = 47, // <Having Clause> ::= 
   RULE_EXPRESSION_OR                       = 48, // <Expression> ::= <And Exp> OR <Expression>
   RULE_EXPRESSION                          = 49, // <Expression> ::= <And Exp>
   RULE_ANDEXP_AND                          = 50, // <And Exp> ::= <Not Exp> AND <And Exp>
   RULE_ANDEXP                              = 51, // <And Exp> ::= <Not Exp>
   RULE_NOTEXP_NOT                          = 52, // <Not Exp> ::= NOT <Pred Exp>
   RULE_NOTEXP                              = 53, // <Not Exp> ::= <Pred Exp>
   RULE_PREDEXP_BETWEEN_AND                 = 54, // <Pred Exp> ::= <Add Exp> BETWEEN <Add Exp> AND <Add Exp>
   RULE_PREDEXP_NOT_BETWEEN_AND             = 55, // <Pred Exp> ::= <Add Exp> NOT BETWEEN <Add Exp> AND <Add Exp>
   RULE_PREDEXP_IS_NOT_NULL                 = 56, // <Pred Exp> ::= <Value> IS NOT NULL
   RULE_PREDEXP_IS_NULL                     = 57, // <Pred Exp> ::= <Value> IS NULL
   RULE_PREDEXP_LIKE_STRINGLITERAL          = 58, // <Pred Exp> ::= <Add Exp> LIKE StringLiteral
   RULE_PREDEXP_NOT_LIKE_STRINGLITERAL      = 59, // <Pred Exp> ::= <Add Exp> NOT LIKE StringLiteral
   RULE_PREDEXP_IN                          = 60, // <Pred Exp> ::= <Add Exp> IN <In List>
   RULE_PREDEXP_NOT_IN                      = 61, // <Pred Exp> ::= <Add Exp> NOT IN <In List>
   RULE_PREDEXP_EQ                          = 62, // <Pred Exp> ::= <Add Exp> '=' <Add Exp>
   RULE_PREDEXP_LTGT                        = 63, // <Pred Exp> ::= <Add Exp> '<>' <Add Exp>
   RULE_PREDEXP_EXCLAMEQ                    = 64, // <Pred Exp> ::= <Add Exp> '!=' <Add Exp>
   RULE_PREDEXP_GT                          = 65, // <Pred Exp> ::= <Add Exp> '>' <Add Exp>
   RULE_PREDEXP_GTEQ                        = 66, // <Pred Exp> ::= <Add Exp> '>=' <Add Exp>
   RULE_PREDEXP_LT                          = 67, // <Pred Exp> ::= <Add Exp> '<' <Add Exp>
   RULE_PREDEXP_LTEQ                        = 68, // <Pred Exp> ::= <Add Exp> '<=' <Add Exp>
   RULE_PREDEXP                             = 69, // <Pred Exp> ::= <Add Exp>
   RULE_ADDEXP_PLUS                         = 70, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
   RULE_ADDEXP_MINUS                        = 71, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
   RULE_ADDEXP                              = 72, // <Add Exp> ::= <Mult Exp>
   RULE_ADDEXP2                             = 73, // <Add Exp> ::= <Aggregate>
   RULE_MULTEXP_TIMES                       = 74, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
   RULE_MULTEXP_DIV                         = 75, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
   RULE_MULTEXP                             = 76, // <Mult Exp> ::= <Negate Exp>
   RULE_NEGATEEXP_MINUS                     = 77, // <Negate Exp> ::= '-' <Value>
   RULE_NEGATEEXP                           = 78, // <Negate Exp> ::= <Value>
   RULE_VALUE                               = 79, // <Value> ::= <Tuple>
   RULE_VALUE_ID                            = 80, // <Value> ::= Id
   RULE_VALUE_INTEGERLITERAL                = 81, // <Value> ::= IntegerLiteral
   RULE_VALUE_REALLITERAL                   = 82, // <Value> ::= RealLiteral
   RULE_VALUE_STRINGLITERAL                 = 83, // <Value> ::= StringLiteral
   RULE_VALUE_NULL                          = 84, // <Value> ::= NULL
   RULE_VALUE_BOOLEANLITERAL                = 85, // <Value> ::= BooleanLiteral
   RULE_VALUE_DATELITERAL                   = 86, // <Value> ::= DateLiteral
   RULE_VALUE_FUNCTION                      = 87, // <Value> ::= Function
   RULE_TUPLE_LPARAN_RPARAN                 = 88, // <Tuple> ::= '(' <Select Stm> ')'
   RULE_TUPLE_LPARAN_RPARAN2                = 89, // <Tuple> ::= '(' <Expr List> ')'
   RULE_INLIST_LPARAN_RPARAN                = 90, // <In List> ::= '(' <Value List> ')'
   RULE_VALUELIST_COMMA                     = 91, // <Value List> ::= <Value> ',' <Value List>
   RULE_VALUELIST                           = 92, // <Value List> ::= <Value>
   RULE_EXPRLIST_COMMA                      = 93, // <Expr List> ::= <Expression> ',' <Expr List>
   RULE_EXPRLIST                            = 94, // <Expr List> ::= <Expression>
   RULE_IDLIST_COMMA                        = 95, // <Id List> ::= <Id Member> ',' <Id List>
   RULE_IDLIST                              = 96, // <Id List> ::= <Id Member>
   RULE_IDMEMBER_ID                         = 97, // <Id Member> ::= Id
   RULE_IDMEMBER_ID_ID                      = 98  // <Id Member> ::= Id Id
};
