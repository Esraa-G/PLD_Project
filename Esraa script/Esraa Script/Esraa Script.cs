
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =  0, // (EOF)
        SYMBOL_ERROR              =  1, // (Error)
        SYMBOL_WHITESPACE         =  2, // Whitespace
        SYMBOL_MINUS              =  3, // '-'
        SYMBOL_MINUSMINUS         =  4, // '--'
        SYMBOL_EXCLAMEQ           =  5, // '!='
        SYMBOL_PERCENT            =  6, // '%'
        SYMBOL_LPAREN             =  7, // '('
        SYMBOL_RPAREN             =  8, // ')'
        SYMBOL_TIMES              =  9, // '*'
        SYMBOL_TIMESTIMES         = 10, // '**'
        SYMBOL_DIV                = 11, // '/'
        SYMBOL_COLON              = 12, // ':'
        SYMBOL_SEMI               = 13, // ';'
        SYMBOL_PLUS               = 14, // '+'
        SYMBOL_PLUSPLUS           = 15, // '++'
        SYMBOL_LT                 = 16, // '<'
        SYMBOL_LTEQ               = 17, // '<='
        SYMBOL_EQ                 = 18, // '='
        SYMBOL_EQEQ               = 19, // '=='
        SYMBOL_GT                 = 20, // '>'
        SYMBOL_GTEQ               = 21, // '>='
        SYMBOL_BYEEXCLAM          = 22, // 'Bye!'
        SYMBOL_DEF                = 23, // def
        SYMBOL_DIGIT              = 24, // Digit
        SYMBOL_DO                 = 25, // do
        SYMBOL_ELIF               = 26, // elif
        SYMBOL_ELSE               = 27, // else
        SYMBOL_FOR                = 28, // for
        SYMBOL_HIEXCLAM           = 29, // 'Hi!'
        SYMBOL_IF                 = 30, // if
        SYMBOL_PRINT              = 31, // print
        SYMBOL_RETURN             = 32, // return
        SYMBOL_STRING             = 33, // String
        SYMBOL_VAR                = 34, // Var
        SYMBOL_WHILE              = 35, // while
        SYMBOL_ASSIGN_STATEMENT   = 36, // <Assign_Statement>
        SYMBOL_BODY               = 37, // <body>
        SYMBOL_COND               = 38, // <cond>
        SYMBOL_DIGIT2             = 39, // <digit>
        SYMBOL_DO_WHILE_STATEMENT = 40, // <do_while_statement>
        SYMBOL_ELIF2              = 41, // <elif>
        SYMBOL_ELIF_LIST          = 42, // <elif_List>
        SYMBOL_ELSE_STATEMENT     = 43, // <Else_Statement>
        SYMBOL_EXP                = 44, // <exp>
        SYMBOL_EXPR               = 45, // <expr>
        SYMBOL_EXPR_LIST          = 46, // <expr_List>
        SYMBOL_FACTOR             = 47, // <factor>
        SYMBOL_FOR_STATEMENT      = 48, // <for_statement>
        SYMBOL_FUNCTION_CALL      = 49, // <function_call>
        SYMBOL_FUNCTION_DEF       = 50, // <Function_Def>
        SYMBOL_IF_STATEMENT       = 51, // <If_Statement>
        SYMBOL_INITIALIZER        = 52, // <Initializer>
        SYMBOL_OP                 = 53, // <op>
        SYMBOL_PARAMETER_LIST     = 54, // <Parameter_List>
        SYMBOL_PRINT_STATEMENT    = 55, // <print_statement>
        SYMBOL_PROGRAM            = 56, // <program>
        SYMBOL_RETURN_STATEMENT   = 57, // <Return_Statement>
        SYMBOL_SCRIPT             = 58, // <script>
        SYMBOL_STEP               = 59, // <step>
        SYMBOL_STMT_LIST          = 60, // <stmt_list>
        SYMBOL_STRING2            = 61, // <string>
        SYMBOL_TERM               = 62, // <term>
        SYMBOL_VAR2               = 63, // <var>
        SYMBOL_WHILE_STATEMENT    = 64  // <While_Statement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_HIEXCLAM_BYEEXCLAM                      =  0, // <program> ::= 'Hi!' <body> 'Bye!'
        RULE_BODY                                            =  1, // <body> ::= <stmt_list>
        RULE_STMT_LIST                                       =  2, // <stmt_list> ::= <stmt_list> <script>
        RULE_STMT_LIST2                                      =  3, // <stmt_list> ::= <script>
        RULE_SCRIPT                                          =  4, // <script> ::= <Assign_Statement>
        RULE_SCRIPT2                                         =  5, // <script> ::= <print_statement>
        RULE_SCRIPT3                                         =  6, // <script> ::= <If_Statement>
        RULE_SCRIPT4                                         =  7, // <script> ::= <While_Statement>
        RULE_SCRIPT5                                         =  8, // <script> ::= <do_while_statement>
        RULE_SCRIPT6                                         =  9, // <script> ::= <for_statement>
        RULE_SCRIPT7                                         = 10, // <script> ::= <Function_Def>
        RULE_SCRIPT8                                         = 11, // <script> ::= <Return_Statement>
        RULE_SCRIPT9                                         = 12, // <script> ::= <function_call>
        RULE_ASSIGN_STATEMENT_EQ                             = 13, // <Assign_Statement> ::= <var> '=' <expr>
        RULE_VAR_VAR                                         = 14, // <var> ::= Var
        RULE_EXPR_PLUS                                       = 15, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                      = 16, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                            = 17, // <expr> ::= <term>
        RULE_TERM_TIMES                                      = 18, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                        = 19, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                    = 20, // <term> ::= <term> '%' <factor>
        RULE_TERM                                            = 21, // <term> ::= <factor>
        RULE_TERM_PLUSPLUS                                   = 22, // <term> ::= <factor> '++'
        RULE_TERM_MINUSMINUS                                 = 23, // <term> ::= <factor> '--'
        RULE_FACTOR_TIMESTIMES                               = 24, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                          = 25, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                               = 26, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                             = 27, // <exp> ::= <var>
        RULE_EXP2                                            = 28, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                     = 29, // <digit> ::= Digit
        RULE_EXPR_LIST                                       = 30, // <expr_List> ::= <expr>
        RULE_EXPR_LIST2                                      = 31, // <expr_List> ::= <expr> <expr_List>
        RULE_PRINT_STATEMENT_PRINT_LPAREN_RPAREN             = 32, // <print_statement> ::= print '(' <expr_List> ')'
        RULE_PRINT_STATEMENT_PRINT_LPAREN_RPAREN2            = 33, // <print_statement> ::= print '(' <string> ')'
        RULE_STRING_STRING                                   = 34, // <string> ::= String
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON             = 35, // <If_Statement> ::= if '(' <cond> ')' ':' <stmt_list>
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON2            = 36, // <If_Statement> ::= if '(' <cond> ')' ':' <stmt_list> <elif_List>
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON3            = 37, // <If_Statement> ::= if '(' <cond> ')' ':' <stmt_list> <Else_Statement>
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON4            = 38, // <If_Statement> ::= if '(' <cond> ')' ':' <stmt_list> <elif_List> <Else_Statement>
        RULE_COND                                            = 39, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                           = 40, // <op> ::= '<'
        RULE_OP_GT                                           = 41, // <op> ::= '>'
        RULE_OP_LTEQ                                         = 42, // <op> ::= '<='
        RULE_OP_GTEQ                                         = 43, // <op> ::= '>='
        RULE_OP_EQEQ                                         = 44, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                     = 45, // <op> ::= '!='
        RULE_ELIF_LIST                                       = 46, // <elif_List> ::= <elif_List> <elif>
        RULE_ELIF_LIST2                                      = 47, // <elif_List> ::= <elif>
        RULE_ELIF_ELIF_LPAREN_RPAREN_COLON                   = 48, // <elif> ::= elif '(' <cond> ')' ':' <stmt_list>
        RULE_ELSE_STATEMENT_ELSE_COLON                       = 49, // <Else_Statement> ::= else ':' <stmt_list>
        RULE_WHILE_STATEMENT_WHILE_LPAREN_RPAREN_COLON       = 50, // <While_Statement> ::= while '(' <cond> ')' ':' <stmt_list>
        RULE_DO_WHILE_STATEMENT_DO_COLON_WHILE_LPAREN_RPAREN = 51, // <do_while_statement> ::= do ':' <stmt_list> while '(' <cond> ')'
        RULE_FOR_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN_COLON = 52, // <for_statement> ::= for '(' <Initializer> ';' <cond> ';' <step> ')' ':' <stmt_list>
        RULE_INITIALIZER                                     = 53, // <Initializer> ::= <Assign_Statement>
        RULE_STEP                                            = 54, // <step> ::= <expr>
        RULE_FUNCTION_DEF_DEF_LPAREN_RPAREN_COLON            = 55, // <Function_Def> ::= def <var> '(' <Parameter_List> ')' ':' <stmt_list>
        RULE_PARAMETER_LIST                                  = 56, // <Parameter_List> ::= <var>
        RULE_PARAMETER_LIST2                                 = 57, // <Parameter_List> ::= <var> <Parameter_List>
        RULE_RETURN_STATEMENT_RETURN                         = 58, // <Return_Statement> ::= return <expr>
        RULE_FUNCTION_CALL_LPAREN_RPAREN                     = 59  // <function_call> ::= <var> '(' <expr_List> ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;
        public MyParser(string filename, ListBox lst,ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            this.ls = ls;
            this.lst = lst;
            Init(stream);
            stream.Close();
        }


        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BYEEXCLAM :
                //'Bye!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEF :
                //def
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF :
                //elif
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HIEXCLAM :
                //'Hi!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //Var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN_STATEMENT :
                //<Assign_Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BODY :
                //<body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE_STATEMENT :
                //<do_while_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF2 :
                //<elif>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF_LIST :
                //<elif_List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE_STATEMENT :
                //<Else_Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR_LIST :
                //<expr_List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STATEMENT :
                //<for_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CALL :
                //<function_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_DEF :
                //<Function_Def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STATEMENT :
                //<If_Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INITIALIZER :
                //<Initializer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER_LIST :
                //<Parameter_List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STATEMENT :
                //<print_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_STATEMENT :
                //<Return_Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SCRIPT :
                //<script>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING2 :
                //<string>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR2 :
                //<var>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STATEMENT :
                //<While_Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_HIEXCLAM_BYEEXCLAM :
                //<program> ::= 'Hi!' <body> 'Bye!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BODY :
                //<body> ::= <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <stmt_list> <script>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <script>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT :
                //<script> ::= <Assign_Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT2 :
                //<script> ::= <print_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT3 :
                //<script> ::= <If_Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT4 :
                //<script> ::= <While_Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT5 :
                //<script> ::= <do_while_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT6 :
                //<script> ::= <for_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT7 :
                //<script> ::= <Function_Def>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT8 :
                //<script> ::= <Return_Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SCRIPT9 :
                //<script> ::= <function_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_STATEMENT_EQ :
                //<Assign_Statement> ::= <var> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_VAR :
                //<var> ::= Var
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PLUSPLUS :
                //<term> ::= <factor> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_MINUSMINUS :
                //<term> ::= <factor> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_LIST :
                //<expr_List> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_LIST2 :
                //<expr_List> ::= <expr> <expr_List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STATEMENT_PRINT_LPAREN_RPAREN :
                //<print_statement> ::= print '(' <expr_List> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STATEMENT_PRINT_LPAREN_RPAREN2 :
                //<print_statement> ::= print '(' <string> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRING_STRING :
                //<string> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON :
                //<If_Statement> ::= if '(' <cond> ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON2 :
                //<If_Statement> ::= if '(' <cond> ')' ':' <stmt_list> <elif_List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON3 :
                //<If_Statement> ::= if '(' <cond> ')' ':' <stmt_list> <Else_Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_COLON4 :
                //<If_Statement> ::= if '(' <cond> ')' ':' <stmt_list> <elif_List> <Else_Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_LIST :
                //<elif_List> ::= <elif_List> <elif>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_LIST2 :
                //<elif_List> ::= <elif>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_ELIF_LPAREN_RPAREN_COLON :
                //<elif> ::= elif '(' <cond> ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSE_STATEMENT_ELSE_COLON :
                //<Else_Statement> ::= else ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STATEMENT_WHILE_LPAREN_RPAREN_COLON :
                //<While_Statement> ::= while '(' <cond> ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_STATEMENT_DO_COLON_WHILE_LPAREN_RPAREN :
                //<do_while_statement> ::= do ':' <stmt_list> while '(' <cond> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN_COLON :
                //<for_statement> ::= for '(' <Initializer> ';' <cond> ';' <step> ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITIALIZER :
                //<Initializer> ::= <Assign_Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_DEF_DEF_LPAREN_RPAREN_COLON :
                //<Function_Def> ::= def <var> '(' <Parameter_List> ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_LIST :
                //<Parameter_List> ::= <var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_LIST2 :
                //<Parameter_List> ::= <var> <Parameter_List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_STATEMENT_RETURN :
                //<Return_Statement> ::= return <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CALL_LPAREN_RPAREN :
                //<function_call> ::= <var> '(' <expr_List> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + " in line " + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = " The Expected token is: " + args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }
        private void TokenReadEvent(LALRParser pr, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "     \t \t" + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);

        }
    }
}
