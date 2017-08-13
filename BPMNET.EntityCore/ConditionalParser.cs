using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.EntityCore
{
    public enum TOKEN_TYPE
    {
        NOTHING, DELIMETER, NUMBER, VARIABLE, FUNCTION, STRING, UNKNOWN, COMPOUND
    }

    public class ConditionalParser
    {
        private TOKEN_TYPE tokenType;
        private string token;
        private int exprPos;
        private char exprC;
        private string formula;
        private bool group;
        private char[] chrs;
        private string text;

        public ConditionalParser(string condition)
        {
            chrs = condition.ToCharArray();
            exprPos = -1;
            exprC = '\0';
            token = "";
            tokenType = TOKEN_TYPE.NOTHING;
        }

        /// <summary>
        /// checks if the given char c is whitespace
        /// whitespace when space chr(32) or tab chr(9)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool IsWhiteSpace(char c)
        {
            return c == 32 || c == 9;
        }

        private bool IsDelimeter(char c)
        {
            return "&|<>=+/*%^!".IndexOf(c) != -1;
        }

        private bool IsDigitDot(char c)
        {
            return "0123456789.".IndexOf(c) != -1;
        }

        private bool IsDigit( char c)
        {
            return "0123456789".IndexOf(c) != -1;
        }

        private bool IsAlpha(char c)
        {
            char cUpper = char.ToUpperInvariant(c);
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ_".IndexOf(cUpper) != -1;
        }

        private bool IsCompound(string token)
        {
            return token.ToUpperInvariant().Equals("AND") || token.ToUpperInvariant().Equals("OR");
        }

        private bool IsQuote(char c)
        {
            char cUpper = char.ToUpperInvariant(c);
            return "\"\'".IndexOf(cUpper) != -1;
        }


        private void GetChar()
        {
            exprPos++;
            if (exprPos < text.Length)
            {
                exprC = chrs[exprPos];
            }
            else
            {
                exprC = '\0';
            }
        }
        public string GetNextToken()
        {
            tokenType = TOKEN_TYPE.NOTHING;
            StringBuilder sb = new StringBuilder();

            // skip over whitespaces
            while (IsWhiteSpace(exprC))     // space or tab
                GetChar();

            // check for end of expression
            if (exprC == '\0')
            {
                // token is empty
                tokenType = TOKEN_TYPE.DELIMETER;
                return sb.ToString();
            }

            // check for minus
            if (exprC == '-')
            {
                tokenType = TOKEN_TYPE.DELIMETER;
                sb.Append(exprC);
                return sb.ToString();
            }

            // check for group and comma
            if (exprC == '(' || exprC == ')' || exprC == ',' || exprC == '.')
            {
                if (exprC == '(')
                {
                    group = true;
                }
                else if (exprC == ')')
                {
                    group = false;
                }
                tokenType = TOKEN_TYPE.DELIMETER;
                sb.Append(exprC);
                GetChar();
                return sb.ToString();
            }

            // check for operators (delimiters)
            if (IsDelimeter(exprC))
            {
                tokenType = TOKEN_TYPE.DELIMETER;
                while (IsDelimeter(exprC))
                {
                    sb.Append(exprC);
                    GetChar();
                }
                return sb.ToString();
            }

            // check for a value
            if (IsDigitDot(exprC))
            {
                tokenType = TOKEN_TYPE.NUMBER;
                while (IsDigitDot(exprC))
                {
                    sb.Append(exprC);
                    GetChar();
                }

                // check for scientific notation like "2.3e-4" or "1.23e50"
                if (exprC == 'e' || exprC == 'E')
                {
                    sb.Append(exprC);
                    GetChar();

                    if (exprC == '+' || exprC == '-')
                    {
                        sb.Append(exprC);
                        GetChar();
                    }

                    while (IsDigit(exprC))
                    {
                        sb.Append(exprC);
                        GetChar();
                    }
                }
                return sb.ToString();
            }

            // check for variables or functions
            if (IsAlpha(exprC))
            {
                while (IsAlpha(exprC) || IsDigit(exprC))
                {
                    sb.Append(exprC);
                    GetChar();
                }

                // skip whitespaces
                while (IsWhiteSpace(exprC)) // space or tab
                {
                    GetChar();
                }


                // check the next non-whitespace character
                if (sb.ToString().ToUpperInvariant().Equals("NOT"))
                {
                    sb.Append(' ');
                    while (IsAlpha(exprC))
                    {
                        sb.Append(exprC);
                        GetChar();
                    }
                    while (IsWhiteSpace(exprC)) // space or tab
                    {
                        GetChar();
                    }
                }

                if (IsCompound(token))
                {
                    tokenType = TOKEN_TYPE.COMPOUND;
                }
                else if (exprC == '(')
                {
                    group = true;
                    tokenType = TOKEN_TYPE.FUNCTION;
                }
                else
                {
                    tokenType = TOKEN_TYPE.VARIABLE;
                }

                return sb.ToString();
            }

            // check for quote variables
            if (IsQuote(exprC))
            {
                char quoteStr = exprC;
                GetChar();
                while (true)
                {
                    if (quoteStr == exprC) break;
                    sb.Append(exprC);
                    GetChar();
                }
                GetChar();
                tokenType = TOKEN_TYPE.STRING;
                return sb.ToString();
            }

            // something unknown is found, wrong characters -> a syntax error
            tokenType = TOKEN_TYPE.UNKNOWN;
            while (exprC != '\0')
            {
                sb.Append(exprC);
                GetChar();
            }

            return sb.ToString();
        }
    }
}
