
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace TPA.Reflection.DynamicType
{
    public enum StringSearchOption
    {
        Contains,
        StartsWith,
        EndsWith
    }

    public class ReadOnlyFile : DynamicObject
    {
        private string p_filePath;
        
        public ReadOnlyFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileLoadException("File path does not exist.");
            }

            p_filePath = filePath;
        }
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {           
            result = GetPropertyValue(binder.Name);
            return result == null ? false : true;
        }
        
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            StringSearchOption StringSearchOption = StringSearchOption.StartsWith;
            bool trimSpaces = true;

            try
            {
                if (args.Length > 0) { StringSearchOption = (StringSearchOption)args[0]; }
            }
            catch
            {
                throw new ArgumentException("StringSearchOption argument must be a StringSearchOption enum value.");
            }

            try
            {
                if (args.Length > 1)
                {
                    trimSpaces = (bool)args[1];
                }
            }
            catch
            {
                throw new ArgumentException("trimSpaces argument must be a Boolean value.");
            }

            result = GetPropertyValue(binder.Name, StringSearchOption, trimSpaces);

            return result == null ? false : true;
        }

        private IEnumerable<string> GetPropertyValue(string propertyName, StringSearchOption StringSearchOption = StringSearchOption.StartsWith, bool trimSpaces = true)
        {
            StreamReader sr = null;
            List<string> results = new List<string>();
            string line = "";
            string testLine = "";

            try
            {
                sr = new StreamReader(p_filePath);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    
                    testLine = line.ToUpper();
                    if (trimSpaces)
                    {
                        testLine = testLine.Trim();
                    }

                    switch (StringSearchOption)
                    {
                        case StringSearchOption.StartsWith:
                            if (testLine.StartsWith(propertyName.ToUpper())) { results.Add(line); }
                            break;
                        case StringSearchOption.Contains:
                            if (testLine.Contains(propertyName.ToUpper())) { results.Add(line); }
                            break;
                        case StringSearchOption.EndsWith:
                            if (testLine.EndsWith(propertyName.ToUpper())) { results.Add(line); }
                            break;
                    }
                }
            }
            catch
            {
                results = null;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return results;
        }
    }
}
