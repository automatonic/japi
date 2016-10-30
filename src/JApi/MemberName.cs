using System;
using System.Linq;

namespace JApi
{
    /// <summary>
    /// http://jsonapi.org/format/#document-member-names
    /// </summary>
    public static class MemberName
    {
        /// <summary>
        /// Checks to see if the specified member name is valid
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public static bool IsValid(string memberName)
        {
            if (memberName == null)
            {
                return false;
            }
            switch (memberName.Length)
            {
                case 0: return false;
                case 1:
                    return
                GloballyAllowed(memberName[0]);
                case 2:
                    return
                GloballyAllowed(memberName[0]) &&
                GloballyAllowed(memberName[1]);
                default:
                    return
               GloballyAllowed(memberName[0]) && //Must start with a globally allowed character
               GloballyAllowed(memberName[memberName.Length - 1]) && //Must end with a globally allowed character
               memberName.ToCharArray().Skip(1).Take(memberName.Length - 2).All(Allowed);
            }
        }

        private static bool Allowed(char c)
        {
            switch (c)
            {
                case '-':
                case '_':
                case ' ':
                    return true;
                default:
                    return GloballyAllowed(c);
            }
        }

        private static bool GloballyAllowed(char c)
        {
            switch (c)
            {
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;

                default:
                    return c > '\x0080';
            }
        }
    }
}